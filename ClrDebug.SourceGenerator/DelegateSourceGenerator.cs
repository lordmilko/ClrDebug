using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics;
using System.IO;
using System.Linq;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using static Microsoft.CodeAnalysis.CSharp.SyntaxFactory;

namespace ClrDebug.SourceGenerator
{
    [Generator]
    public class DelegateSourceGenerator : IIncrementalGenerator
    {
        private static SpecialType[] specialTypes =
        {
            SpecialType.System_Int32,
            SpecialType.System_Int64,
            SpecialType.System_IntPtr
        };

        private static string[] numericWrappers =
        {
            "CLRDATA_ADDRESS",
            "FunctionID",
            "FunctionIDOrClientID",
            "ObjectID",
            "COR_PRF_FRAME_INFO",
            "COR_PRF_ELT_INFO"
        };

        private static string[] validFiles =
        {
            //All delegates are assumed to be stdcall. If this is not the case,
            //this generator should be modified accordingly
            "Extensions.cs",
            "Extensions.DbgShim.cs"
        };

        public void Initialize(IncrementalGeneratorInitializationContext context)
        {
#if DEBUG
            if (!Debugger.IsAttached)
            {
                //Debugger.Launch();
            }
#endif

            var classDeclarations = context.SyntaxProvider.CreateSyntaxProvider(
                predicate: (s, _) => s is DelegateDeclarationSyntax,
                transform: (ctx, _) => TransformSyntax(ctx)
            ).Where(v => v != null);

            var merged = context.CompilationProvider.Combine(classDeclarations.Collect());

            context.RegisterSourceOutput(merged, (ctx, source) => Execute(source.Left, source.Right, ctx));
        }

        private static void Execute(Compilation compilation, ImmutableArray<DelegateDeclarationSyntax> delegates, SourceProductionContext context)
        {
            if (delegates.IsDefaultOrEmpty)
                return;

            var methods = new List<MethodDeclarationSyntax>();

            foreach (var @delegate in delegates)
            {
                var model = compilation.GetSemanticModel(@delegate.SyntaxTree);

                var symbol = model.GetDeclaredSymbol(@delegate);
                var method = CreateDelegateHandler(symbol);

                methods.Add(method);
            }

            StructDeclarationSyntax classSyntax = StructDeclaration("DelegateHolder")
                .AddModifiers(Token(SyntaxKind.InternalKeyword), Token(SyntaxKind.UnsafeKeyword), Token(SyntaxKind.PartialKeyword))
                .AddMembers(methods.ToArray());

            var compilationUnit = CompilationUnit()
                .AddMembers(
                    NamespaceDeclaration(
                        IdentifierName("ClrDebug")
                    ).AddMembers(classSyntax)
                )
                .AddUsings(
                    UsingDirective(IdentifierName("System")),
                    UsingDirective(IdentifierName("System.Runtime.InteropServices")),
                    UsingDirective(IdentifierName("System.Runtime.InteropServices.Marshalling")),
                    UsingDirective(IdentifierName("ClrDebug.Extensions")).WithStaticKeyword(Token(SyntaxKind.StaticKeyword))
                );

            context.AddSource("DelegateHolder.g.cs", compilationUnit.NormalizeWhitespace().ToFullString());
        }

        private static MethodDeclarationSyntax CreateDelegateHandler(INamedTypeSymbol @delegate)
        {
            var delegateMethod = @delegate.DelegateInvokeMethod;

            var parameters = delegateMethod.Parameters.Select(p => ((ParameterSyntax) p.DeclaringSyntaxReferences[0].GetSyntax()).WithAttributeLists(List<AttributeListSyntax>())).ToList();

            var method = MethodDeclaration(IdentifierName(delegateMethod.ReturnType.ToNiceString()), @delegate.Name.Replace("Delegate", string.Empty))
                .WithParameterList(ParameterList(SeparatedList(parameters)))
                .AddModifiers(Token(SyntaxKind.InternalKeyword));

            var callingConv = FunctionPointerCallingConvention(
                    Token(SyntaxKind.UnmanagedKeyword),
                    FunctionPointerUnmanagedCallingConventionList()
                    .AddCallingConventions(FunctionPointerUnmanagedCallingConvention(Identifier("Stdcall"))));

            var fnPtrParameterTypes = new List<FunctionPointerParameterSyntax>();
            var fnPtrArgs = new List<ExpressionSyntax>();
            var preInvokeStatements = new List<StatementSyntax>();
            var postInvokeStatements = new List<StatementSyntax>();
            var finallyStatements = new List<StatementSyntax>();
            var pinnableReferences = new List<VariableDeclarationSyntax>();

            foreach (var parameter in delegateMethod.Parameters)
            {
                var info = GetDelegateParameterInfo(parameter);

                fnPtrParameterTypes.Add(FunctionPointerParameter(info.UnmanagedArgumentType));
                fnPtrArgs.Add(info.UnmanagedArgument);

                var inputStatements = info.ConvertToUnmanaged;
                var outputStatements = info.ConvertToManaged;
                var freeStatements = info.Free;
                var pinnable = info.GetPinnableReference();

                if (inputStatements != null)
                    preInvokeStatements.AddRange(inputStatements);

                if (outputStatements != null)
                    postInvokeStatements.AddRange(outputStatements);

                if (freeStatements != null)
                    finallyStatements.AddRange(freeStatements);

                if (pinnable != null)
                    pinnableReferences.Add(pinnable);
            }

            var ptrType = FunctionPointerType(
                callingConv,
                FunctionPointerParameterList()
                .AddParameters(fnPtrParameterTypes.ToArray())
                .AddParameters(FunctionPointerParameter(IdentifierName(delegateMethod.ReturnType.ToNiceString())))
            );

            var proc = IdentifierName("proc");

            var invocation = InvocationExpression(
                ParenthesizedExpression(
                    CastExpression(ptrType, proc)
                )
            ).AddArgumentListArguments(fnPtrArgs.Select(v => Argument(v)).ToArray());

            var executeStatement = delegateMethod.ReturnType.SpecialType == SpecialType.System_Void ? (StatementSyntax) ExpressionStatement(invocation) : ReturnStatement(invocation);

            var statements = new List<StatementSyntax>();

            statements.AddRange(preInvokeStatements);

            if (postInvokeStatements.Count == 0 && finallyStatements.Count == 0 && pinnableReferences.Count == 0)
            {
                if (delegateMethod.ReturnType.SpecialType == SpecialType.System_Void)
                    statements.Add(ExpressionStatement(invocation));
                else
                    statements.Add(ReturnStatement(invocation));
            }
            else
            {
                var innerStatements = new List<StatementSyntax>();

                var returnType = delegateMethod.ReturnType.ToNiceString();
                var returnName = "__retVal";

                if (delegateMethod.ReturnType.SpecialType != SpecialType.System_Void)
                {
                    var variable = SimpleVariable(IdentifierName(delegateMethod.ReturnType.ToNiceString()), returnName);
                    statements.Add(variable);
                }

                StatementSyntax innerStatement;

                if (delegateMethod.ReturnType.SpecialType == SpecialType.System_Void)
                    innerStatement = ExpressionStatement(invocation);
                else
                {
                    var expr = ExpressionStatement(
                        AssignmentExpression(SyntaxKind.SimpleAssignmentExpression, IdentifierName(returnName), invocation)
                    );

                    if (pinnableReferences.Count == 0)
                        innerStatement = expr;
                    else
                        innerStatement = Block().AddStatements(expr);
                }

                if (pinnableReferences.Count == 0)
                {
                    innerStatements.Add(innerStatement);
                }
                else
                {
                    pinnableReferences.Reverse();

                    foreach (var item in pinnableReferences)
                    {
                        innerStatement = FixedStatement(item, innerStatement);
                    }

                    innerStatements.Add(innerStatement);
                }

                innerStatements.AddRange(postInvokeStatements);

                if (finallyStatements.Count == 0)
                    statements.AddRange(innerStatements);
                else
                {
                    var tryFinally = TryStatement().WithBlock(Block(innerStatements)).WithFinally(FinallyClause().AddBlockStatements(finallyStatements.ToArray()));

                    statements.Add(tryFinally);
                }

                if (delegateMethod.ReturnType.SpecialType != SpecialType.System_Void)
                    statements.Add(ReturnStatement(IdentifierName(returnName)));
            }

            method = method.AddBodyStatements(statements.ToArray());

            return method;
        }

        private static DelegateParameterMarshaller GetDelegateParameterInfo(IParameterSymbol parameter)
        {
            var type = parameter.Type;

            if (type.Name == "Guid")
                return new  GuidDelegateParameterMarshaller(parameter);

            if (specialTypes.Contains(type.SpecialType) || type.TypeKind == TypeKind.Enum || numericWrappers.Contains(type.Name) || type.TypeKind == TypeKind.Pointer)
                return new LiteralDelegateParameterMarshaller(parameter);

            if (type.SpecialType == SpecialType.System_String || type.SpecialType == SpecialType.System_Boolean)
                return new RelayDelegateParameterMarshaller(parameter);

            if (type.TypeKind == TypeKind.Array)
                return new ArrayDelegateParameterMarshaller(parameter);

            if (type.TypeKind == TypeKind.Interface || type.SpecialType == SpecialType.System_Object)
                return new RelayDelegateParameterMarshaller(parameter);

            if (type.TypeKind == TypeKind.Delegate)
                return new FunctionPointerDelegateParameterMarshaller(parameter);

            if (type.Name == "DACEHInfo")
                return new MarshalledStructDelegateParameterMarshaller(parameter);

            throw new NotImplementedException($"Don't know how to handle parameter type '{type}'");
        }

        private static LocalDeclarationStatementSyntax SimpleVariable(TypeSyntax type, string name, ExpressionSyntax initializer = null)
        {
            return LocalDeclarationStatement(
                VariableDeclaration(type).AddVariables(
                    VariableDeclarator(name).WithInitializer(initializer == null ? null : EqualsValueClause(initializer))
                )
            );
        }

        private static DelegateDeclarationSyntax TransformSyntax(GeneratorSyntaxContext context)
        {
            //In this method we may either convert the syntax node matched by the predicate to the actual
            //node we want to operate against, or we can just return our existing node as is

            //We don't care about delegates inside the DbgEng namespace

            var node = (DelegateDeclarationSyntax) context.Node;

            if (node.Identifier.Text == "RuntimeStartupCallback")
                return null;

            var ns = node.SyntaxTree.GetCompilationUnitRoot().DescendantNodes().OfType<NamespaceDeclarationSyntax>().First();

            var name = ns.Name.ToString();

            if (name == "ClrDebug.DbgEng")
                return null;

            var parentType = node.Ancestors().OfType<ClassDeclarationSyntax>().FirstOrDefault();

            if (parentType != null && parentType.Identifier.Text == "RuntimeCallableWrapper")
                return null;

            var fileName = Path.GetFileName(node.SyntaxTree.FilePath);

            if (!validFiles.Contains(fileName))
                return null;

            return node;
        }
    }
}
