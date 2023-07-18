using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using static Microsoft.CodeAnalysis.CSharp.SyntaxFactory;

namespace ClrDebug.SourceGenerator
{
    [Generator]
    public class StructSourceGenerator : IIncrementalGenerator
    {
        public void Initialize(IncrementalGeneratorInitializationContext context)
        {
#if DEBUG
            if (!Debugger.IsAttached)
            {
                //Debugger.Launch();
            }
#endif

            var syntaxTrees = GetSyntaxTrees();

            var structs = syntaxTrees.SelectMany(s => s.GetCompilationUnitRoot().DescendantNodes().OfType<StructDeclarationSyntax>()).ToArray();

            var structsToMonitor = new List<string>();

            foreach (var @struct in @structs)
            {
                var analysis = new StructSyntaxInfo(@struct);

                if (analysis.RequiresMarshalling)
                    structsToMonitor.Add(@struct.Identifier.ToString());
            }

            context.RegisterPostInitializationOutput(ctx =>
            {
                foreach (var @struct in structs)
                {
                    var info = new StructSyntaxInfo(@struct);

                    if (info.RequiresMarshalling)
                    {
                        var builder = new StringBuilder();

                        builder.AppendLine("#pragma warning disable CS0649 //Field is never assigned to, and will always have its default value");
                        builder.AppendLine(GenerateCompilationUnit(info).ToFullString());
                        builder.AppendLine("#pragma warning restore CS0649 //Field is never assigned to, and will always have its default value");

                        ctx.AddSource($"{info.Name}.g.cs", builder.ToString());
                    }
                }
            });

            var items = context.SyntaxProvider.CreateSyntaxProvider((syntax, _) => syntax is StructDeclarationSyntax s && structsToMonitor.Contains(s.Identifier.ToString()), (ctx, _) => (StructDeclarationSyntax) ctx.Node).Where(v => v != null);

            context.RegisterSourceOutput(items, (ctx, syntax) =>
            {
                var info = new StructSyntaxInfo(syntax);

                if (info.RequiresMarshalling && !info.HasPartial)
                {
                    var descriptor = new DiagnosticDescriptor(
                        "CLRDEBUG001",
                        "Structs requiring custom marshalling must be partial",
                        "Structs requiring custom marshalling must be partial",
                        "ClrDebug",
                        DiagnosticSeverity.Error,
                        true
                    );
                    var location = syntax.GetLocation();

                    var diagnostic = Diagnostic.Create(
                        descriptor,
                        location
                    );

                    ctx.ReportDiagnostic(diagnostic);
                }
            });
        }

        #region Generation

        private CompilationUnitSyntax GenerateCompilationUnit(StructSyntaxInfo info)
        {
            var marshallerType = GenerateMarshallerType(info);
            var nativeType = GenerateNativeStructType(info);

            var outerType = GenerateOuterStructType(info, marshallerType, nativeType);

            var usings = info.Syntax.SyntaxTree.GetCompilationUnitRoot().Usings.Select(v => v.WithoutTrivia()).ToList();

            if (!usings.Any(u => u.Name.ToString() == "System.Runtime.InteropServices.Marshalling"))
                usings.Add(UsingDirective(IdentifierName("System.Runtime.InteropServices.Marshalling")));

            var ns = info.Syntax.SyntaxTree.GetRoot().DescendantNodes().OfType<NamespaceDeclarationSyntax>().First();

            var syntax = CompilationUnit()
                .WithUsings(List(usings))
                .AddMembers(
                    NamespaceDeclaration(ns.Name).AddMembers(outerType)
                 );

            return syntax.NormalizeWhitespace();
        }

        #region Marshaller

        private ClassDeclarationSyntax GenerateMarshallerType(StructSyntaxInfo info)
        {
            var customMarshallerAttribute = Attribute(
                IdentifierName("CustomMarshaller"),
                AttributeArgumentList().AddArguments(
                    AttributeArgument(TypeOfExpression(IdentifierName(info.Name))),
                    AttributeArgument(MemberAccessExpression(SyntaxKind.SimpleMemberAccessExpression, IdentifierName("MarshalMode"), IdentifierName("Default"))),
                    AttributeArgument(TypeOfExpression(IdentifierName("Marshaller")))
                )
            );

            var methods = new List<MemberDeclarationSyntax>
            {
                GenerateConvertToUnmanaged(info),
                GenerateConvertToManaged(info)
            };

            var free = GenerateFree(info);

            if (free != null)
                methods.Add(free);

            var modifiers = new List<SyntaxToken>
            {
                Token(SyntaxKind.InternalKeyword)
            };

            //Attempting to touch a void* member in the native type requires that method touching it is unsafe as well
            if (info.Fields.Any(f => f.Marshaller.IsUnsafe))
                modifiers.Add(Token(SyntaxKind.UnsafeKeyword));

            modifiers.Add(Token(SyntaxKind.StaticKeyword));

            var marshaller = ClassDeclaration("Marshaller")
                .WithModifiers(TokenList(modifiers))
                .AddMembers(methods.ToArray())
                .AddAttributeLists(AttributeList().AddAttributes(customMarshallerAttribute));

            return marshaller;
        }

        private MethodDeclarationSyntax GenerateConvertToUnmanaged(StructSyntaxInfo info)
        {
            return GenerateMarshallerMethod(
                inputType: info.Name,
                inputName: "managed",
                outputType: info.NativeName,
                outputName: "unmanaged",
                methodName: "ConvertToUnmanaged",
                fields: info.Fields,
                marshaller: (m, input) => m.ToUnmanaged(input),
                complexMarshaller: (complex, input, output) => complex.GetAdditionalToUnmanagedStatements(input, output)
            );
        }

        private MethodDeclarationSyntax GenerateConvertToManaged(StructSyntaxInfo info)
        {
            return GenerateMarshallerMethod(
                inputType: info.NativeName,
                inputName: "unmanaged",
                outputType: info.Name,
                outputName: "managed",
                methodName: "ConvertToManaged",
                fields: info.Fields,
                marshaller: (m, input) => m.ToManaged(input),
                complexMarshaller: (complex, input, output) => complex.GetAdditionalToManagedStatements(input, output)
            );
        }

        private static MethodDeclarationSyntax GenerateMarshallerMethod(
            string inputType,
            string inputName,
            string outputType,
            string outputName,
            string methodName,
            FieldSyntaxInfo[] fields,
            Func<FieldMarshaller, MemberAccessExpressionSyntax, ExpressionSyntax> marshaller,
            Func<IComplexMarshaller, MemberAccessExpressionSyntax, MemberAccessExpressionSyntax, StatementSyntax[]> complexMarshaller)
        {
            var method = MethodDeclaration(IdentifierName(outputType), methodName)
                .AddModifiers(Token(SyntaxKind.PublicKeyword), Token(SyntaxKind.StaticKeyword))
                .AddParameterListParameters(Parameter(Identifier(inputName)).WithType(IdentifierName(inputType)));

            var outputVariable = LocalDeclarationStatement(VariableDeclaration(IdentifierName(outputType)).AddVariables(VariableDeclarator(
                Identifier(outputName)
            ).WithInitializer(EqualsValueClause(ObjectCreationExpression(IdentifierName(outputType)).AddArgumentListArguments()))));

            var statements = new List<StatementSyntax>
            {
                outputVariable
            };

            var additionalStatements = new List<StatementSyntax>();

            foreach (var field in fields)
            {
                var inputFieldToMarshal = MemberAccessExpression(SyntaxKind.SimpleMemberAccessExpression, IdentifierName(inputName), IdentifierName(field.Name));

                var statement = ExpressionStatement(
                    AssignmentExpression(
                        SyntaxKind.SimpleAssignmentExpression,
                        MemberAccessExpression(
                            SyntaxKind.SimpleMemberAccessExpression,
                            IdentifierName(outputName),
                            IdentifierName(field.Name)
                        ),
                        marshaller(field.Marshaller, inputFieldToMarshal)
                    )
                );

                statements.Add(statement);

                if (field.Marshaller is IComplexMarshaller c)
                {
                    var outputFieldToMarshal = MemberAccessExpression(SyntaxKind.SimpleMemberAccessExpression, IdentifierName(outputName), IdentifierName(field.Name));

                    additionalStatements.AddRange(complexMarshaller(c, inputFieldToMarshal, outputFieldToMarshal));
                }
            }

            statements.AddRange(additionalStatements);

            statements.Add(ReturnStatement(IdentifierName(outputName)));

            method = method.WithBody(Block(List(statements)));

            return method;
        }

        private static MethodDeclarationSyntax GenerateFree(StructSyntaxInfo info)
        {
            var statements = new List<StatementSyntax>();

            foreach (var field in info.Fields)
            {
                var unmanagedMember = MemberAccessExpression(
                    SyntaxKind.SimpleMemberAccessExpression,
                    IdentifierName("unmanaged"),
                    IdentifierName(field.Name)
                );

                var statement = field.Marshaller.Free(unmanagedMember);

                if (statement != null)
                    statements.Add(statement);
            }

            if (statements.Count == 0)
                return null;

            var method = MethodDeclaration(IdentifierName("void"), "Free")
                .AddModifiers(Token(SyntaxKind.PublicKeyword), Token(SyntaxKind.StaticKeyword))
                .AddParameterListParameters(Parameter(Identifier("unmanaged")).WithType(IdentifierName(info.NativeName)))
                .WithBody(Block(statements));

            return method;
        }

        #endregion

        private StructDeclarationSyntax GenerateNativeStructType(StructSyntaxInfo info)
        {
            var nativeTypeModifiers = info.Syntax.Modifiers.Where(m => !m.IsKind(SyntaxKind.PublicKeyword) && !m.IsKind(SyntaxKind.PartialKeyword)).ToList();
            nativeTypeModifiers.Insert(0, Token(SyntaxKind.InternalKeyword));

            if (info.Fields.Any(f => f.Marshaller.IsUnsafe) && !nativeTypeModifiers.Any(m => m.IsKind(SyntaxKind.UnsafeKeyword)))
                nativeTypeModifiers.Insert(1, Token(SyntaxKind.UnsafeKeyword));

            var nativeType = StructDeclaration(info.NativeName).WithModifiers(TokenList(nativeTypeModifiers)).WithMembers(
                List(
                    info.Fields.Select(
                        f =>
                        {
                            var newField = FieldDeclaration(
                                VariableDeclaration(
                                    IdentifierName(f.Marshaller.UnmanagedType)
                                ).AddVariables(
                                    VariableDeclarator(f.Name)
                                )
                            ).WithModifiers(TokenList(Token(SyntaxKind.PublicKeyword)));

                            if (f.FieldOffset != null)
                                newField = newField.AddAttributeLists(AttributeList().AddAttributes(f.FieldOffset));

                            return (MemberDeclarationSyntax) newField;
                        }
                    )
                )
            );

            if (info.StructLayout != null)
                nativeType = nativeType.AddAttributeLists(AttributeList().AddAttributes(info.StructLayout));

            return nativeType;
        }

        private StructDeclarationSyntax GenerateOuterStructType(StructSyntaxInfo info, ClassDeclarationSyntax marshaller, StructDeclarationSyntax nativeType)
        {
            var nativeMarshallingAttribute = Attribute(
                IdentifierName("NativeMarshalling"),
                AttributeArgumentList(
                    SingletonSeparatedList(
                        AttributeArgument(
                            TypeOfExpression(IdentifierName("Marshaller"))
                        )
                    )
                )
            );

            var outerStruct = StructDeclaration(info.Name)
                .WithModifiers(info.Syntax.Modifiers)
                .WithoutLeadingTrivia()
                .AddMembers(marshaller, nativeType)
                .AddAttributeLists(AttributeList().AddAttributes(nativeMarshallingAttribute));

            return outerStruct;
        }

        #endregion

        private SyntaxTree[] GetSyntaxTrees()
        {
            var dll = typeof(StructSourceGenerator).Assembly.Location;
            var solution = FileVersionInfo.GetVersionInfo(dll).FileDescription;
            var structDir = Path.GetFullPath(Path.Combine(solution, "..", "ClrDebug", "Native", "Struct"));

            var files = Directory.EnumerateFiles(structDir, "*.cs", SearchOption.AllDirectories).Where(f => Path.GetFileName(Path.GetDirectoryName(f)) != "DbgEng").ToArray();

            var trees = files.Select(f => CSharpSyntaxTree.ParseText(File.ReadAllText(f), CSharpParseOptions.Default.WithPreprocessorSymbols("GENERATED_MARSHALLING"))).ToArray();

            return trees;
        }
    }
}
