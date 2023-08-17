using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using static Microsoft.CodeAnalysis.CSharp.SyntaxFactory;

namespace ClrDebug.SourceGenerator
{
    class DelegateReturnTypeInfo
    {
        public string ManagedName { get; set; }
        public string ManagedType { get; set; }
        public string UnmanagedName { get; set; }
        public string UnmanagedType { get; set; }
        public ExpressionSyntax Expression { get; set; }
    }

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
            "Extensions.DbgShim.cs",
            "Extensions.HostFxr.cs"
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

            var method = MethodDeclaration(IdentifierName(delegateMethod.ReturnType.ToNiceString()), CleanDelegateName(@delegate.Name))
                .WithParameterList(ParameterList(SeparatedList(parameters)))
                .AddModifiers(Token(SyntaxKind.InternalKeyword));

            var callingConv = FunctionPointerCallingConvention(
                    Token(SyntaxKind.UnmanagedKeyword),
                    FunctionPointerUnmanagedCallingConventionList()
                    .AddCallingConventions(FunctionPointerUnmanagedCallingConvention(Identifier(GetCallingConvention(@delegate)))));

            var fnPtrParameterTypes = new List<FunctionPointerParameterSyntax>();
            var fnPtrArgs = new List<ExpressionSyntax>();
            var preInvokeStatements = new List<StatementSyntax>();
            var extraInnerStatements = new List<StatementSyntax>();
            var postInvokeStatements = new List<StatementSyntax>();
            var finallyStatements = new List<StatementSyntax>();
            var pinnableReferences = new List<VariableDeclarationSyntax>();
            var insideFixedStatements = new List<StatementSyntax>();

            foreach (var parameter in delegateMethod.Parameters)
            {
                var info = GetDelegateParameterInfo(parameter);

                fnPtrParameterTypes.Add(FunctionPointerParameter(info.UnmanagedArgumentType));
                fnPtrArgs.Add(info.UnmanagedArgument);

                var inputStatements = info.ConvertToUnmanaged;
                var inner = info.InnerStatements;
                var outputStatements = info.ConvertToManaged;
                var freeStatements = info.Free;
                var pinnable = info.GetPinnableReference();
                var insideFixed = info.GetInsideFixedStatements();

                if (inputStatements != null)
                    preInvokeStatements.AddRange(inputStatements);

                if (inner != null)
                    extraInnerStatements.AddRange(inner);

                if (outputStatements != null)
                    postInvokeStatements.AddRange(outputStatements);

                if (freeStatements != null)
                    finallyStatements.AddRange(freeStatements);

                if (pinnable != null)
                    pinnableReferences.Add(pinnable);

                if (insideFixed != null)
                    insideFixedStatements.AddRange(insideFixed);
            }

            var returnTypeInfo = GetDelegateReturnTypeInfo(delegateMethod);

            var ptrType = FunctionPointerType(
                callingConv,
                FunctionPointerParameterList()
                .AddParameters(fnPtrParameterTypes.ToArray())
                .AddParameters(FunctionPointerParameter(IdentifierName(returnTypeInfo.UnmanagedType)))
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

                innerStatements.AddRange(extraInnerStatements);

                if (delegateMethod.ReturnType.SpecialType != SpecialType.System_Void)
                {
                    var variable = SimpleVariable(IdentifierName(returnTypeInfo.ManagedType), returnTypeInfo.ManagedName);
                    statements.Add(variable);

                    if (returnTypeInfo.ManagedName != returnTypeInfo.UnmanagedName)
                    {
                        var nativeVariable = SimpleVariable(IdentifierName(returnTypeInfo.UnmanagedType), returnTypeInfo.UnmanagedName);
                        statements.Add(nativeVariable);
                    }
                }

                StatementSyntax innerStatement;

                if (delegateMethod.ReturnType.SpecialType == SpecialType.System_Void)
                    innerStatement = ExpressionStatement(invocation);
                else
                {
                    var expr = ExpressionStatement(
                        AssignmentExpression(SyntaxKind.SimpleAssignmentExpression, IdentifierName(returnTypeInfo.UnmanagedName), invocation)
                    );

                    if (pinnableReferences.Count == 0)
                        innerStatement = expr;
                    else
                    {
                        innerStatement = Block()
                            .AddStatements(insideFixedStatements.ToArray())
                            .AddStatements(expr);
                    }
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
                {
                    if (returnTypeInfo.Expression != null)
                        statements.Add(ExpressionStatement(returnTypeInfo.Expression));

                    statements.Add(ReturnStatement(IdentifierName(returnTypeInfo.ManagedName)));
                }
            }

            method = method.AddBodyStatements(statements.ToArray());

            return method;
        }

        private static string CleanDelegateName(string type)
        {
            return type.Replace("Delegate", string.Empty).Replace("_fn", string.Empty);
        }

        private static DelegateReturnTypeInfo GetDelegateReturnTypeInfo(IMethodSymbol delegateMethod)
        {
            var managedName = "__retVal";
            var managedType = delegateMethod.ReturnType.ToNiceString();
            string unmanagedName = managedName;
            string unmanagedType = managedType;
            ExpressionSyntax expr = null;

            var returnAttribs = delegateMethod.GetReturnTypeAttributes();

            if (returnAttribs.Any(a => a.AttributeClass.Name == "MarshalAsAttribute"))
            {
                var marshalAs = returnAttribs.First(a => a.AttributeClass.Name == "MarshalAsAttribute");

                var arg = (UnmanagedType)marshalAs.ConstructorArguments.First(a => a.Type.Name == "UnmanagedType").Value;

                if (arg != UnmanagedType.FunctionPtr)
                    throw new NotImplementedException();

                unmanagedName = "__retVal_native";
                unmanagedType = "IntPtr";

                expr = AssignmentExpression(
                    SyntaxKind.SimpleAssignmentExpression,
                    IdentifierName(managedName),
                    ConditionalExpression(
                        BinaryExpression(
                            SyntaxKind.NotEqualsExpression,
                            IdentifierName(unmanagedName),
                            LiteralExpression(SyntaxKind.DefaultLiteralExpression)
                        ),
                        MemberAccessExpression(
                            SyntaxKind.SimpleMemberAccessExpression,
                            ObjectCreationExpression(IdentifierName("DelegateHolder")).AddArgumentListArguments(Argument(IdentifierName(unmanagedName))),
                            IdentifierName(CleanDelegateName(delegateMethod.ReturnType.ToNiceString()))
                        ),
                        LiteralExpression(SyntaxKind.NullLiteralExpression)
                    )
                );
            }

            return new DelegateReturnTypeInfo
            {
                ManagedName = managedName,
                ManagedType = managedType,
                UnmanagedName = unmanagedName,
                UnmanagedType = unmanagedType,
                Expression = expr
            };
        }

        private static string GetCallingConvention(INamedTypeSymbol @delegate)
        {
            var attribs = @delegate.GetAttributes();

            if (attribs.Length > 0)
            {
                var attrib = attribs.FirstOrDefault(a => a.AttributeClass.Name == "UnmanagedFunctionPointerAttribute");

                if (attrib != null)
                {
                    var conv = (CallingConvention)attrib.ConstructorArguments[0].Value;

                    switch (conv)
                    {
                        case CallingConvention.StdCall:
                            return "Stdcall";

                        case CallingConvention.Cdecl:
                            return "Cdecl";

                        default:
                            throw new NotImplementedException($"Don't know how to handle calling convention '{conv}' for delegate '{@delegate.Name}'");
                    }
                }
            }

            return "Stdcall";
        }

        private static DelegateParameterMarshaller GetDelegateParameterInfo(IParameterSymbol parameter)
        {
            var type = parameter.Type;

            if (type.Name == "Guid")
                return new  GuidDelegateParameterMarshaller(parameter);

            if (specialTypes.Contains(type.SpecialType) || type.TypeKind == TypeKind.Enum || numericWrappers.Contains(type.Name) || type.TypeKind == TypeKind.Pointer)
                return new LiteralDelegateParameterMarshaller(parameter);

            if (type.Name == "hostfxr_dotnet_environment_info")
                return new LiteralDelegateParameterMarshaller(parameter);

            if (type.SpecialType == SpecialType.System_String || type.SpecialType == SpecialType.System_Boolean)
                return new RelayDelegateParameterMarshaller(parameter);

            if (type.TypeKind == TypeKind.Array)
            {
                var info = DelegateParameterMarshaller.GetMarshalAs(parameter);

                if (info.SubType == null)
                {
                    if (info.UnmanagedType == UnmanagedType.LPTStr)
                        return new RelayDelegateParameterMarshaller(parameter);

                    throw new InvalidOperationException($"Parameter {parameter.ContainingType.Name}.{parameter.Name} is missing an ArraySubType");
                }

                var subType = (UnmanagedType)info.SubType;

                if (subType == UnmanagedType.LPTStr)
                    return new ArrayElementDelegateParameterMarshaller(parameter, new CrossPlatformStringMarshaller(parameter.Name, parameter.Type.ToNiceString()));

                return new ArrayLiteralDelegateParameterMarshaller(parameter, subType);
            }

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

            var ignored = new[]
            {
                "RuntimeStartupCallback",
                "HostFxrGetAvailableSDKsDelegate",
                "HostFxrResolveSdk2Delegate",
                "HostFxrErrorWriterDelegate"
            };

            if (ignored.Contains(node.Identifier.Text))
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
