using System;
using System.Collections.Generic;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using static Microsoft.CodeAnalysis.CSharp.SyntaxFactory;

namespace ClrDebug.SourceGenerator
{
    class ArrayElementDelegateParameterMarshaller : DelegateParameterMarshaller
    {
        public override TypeSyntax UnmanagedType { get; }

        public override bool IsUnmanagedByRef { get; }

        private FieldMarshaller elementMarshaller;
        private string lastIndexMarshalledName;
        private string arrayMarshallerName;
        private string nativeSpanName;
        private TypeSyntax arrayMarshallerType;
        public override bool NeedUnmanagedTemporary => true;

        public ArrayElementDelegateParameterMarshaller(IParameterSymbol parameter, FieldMarshaller elementMarshaller) : base(parameter)
        {
            this.elementMarshaller = elementMarshaller;

            ManagedType = IdentifierName(((IArrayTypeSymbol)parameter.Type).ElementType.ToNiceString());
            UnmanagedType = PointerType(IdentifierName("IntPtr"));

            lastIndexMarshalledName = $"__{ManagedName}_native__lastIndexMarshalled";
            arrayMarshallerName = $"__{ManagedName}_native__marshaller";
            nativeSpanName = $"__{ManagedName}_native__nativeSpan";
            arrayMarshallerType = QualifiedName(GenericName("ArrayMarshaller")
                .AddTypeArgumentListArguments(ManagedType, IdentifierName("IntPtr")), IdentifierName("ManagedToUnmanagedIn"));
        }

        public override StatementSyntax[] ConvertToUnmanaged
        {
            get
            {
                var arrayMarshaller = CreateManagedToUnmanagedMarshaller(arrayMarshallerType, arrayMarshallerName);
                var lastIndexMarshalledVariable = CreateLastIndexMarshalledVariable(lastIndexMarshalledName);

                return new StatementSyntax[]
                {
                    SimpleVariable(UnmanagedType, UnmanagedName.ToString(), LiteralExpression(SyntaxKind.DefaultLiteralExpression)),
                    arrayMarshaller,
                    lastIndexMarshalledVariable
                };
            }
        }

        public override VariableDeclarationSyntax GetPinnableReference()
        {
            return VariableDeclaration(PointerType(IdentifierName("void")))
                .AddVariables(
                VariableDeclarator($"{UnmanagedName}__unused")
                    .WithInitializer(EqualsValueClause(IdentifierName(arrayMarshallerName))));
        }

        public override StatementSyntax[] GetInsideFixedStatements()
        {
            return new[]
            {
                ExpressionStatement(
                    AssignmentExpression(
                        SyntaxKind.SimpleAssignmentExpression,
                        UnmanagedName,
                        InvocationExpression(
                            MemberAccessExpression(
                                SyntaxKind.SimpleMemberAccessExpression,
                                IdentifierName(arrayMarshallerName),
                                IdentifierName("ToUnmanaged")
                            )
                        )
                    )
                )
            };
        }

        public override StatementSyntax[] InnerStatements
        {
            get
            {
                var initializeManagedToUnmanaged = InitializeManagedToUnmanaged(arrayMarshallerType, arrayMarshallerName);

                var copyToUnmanaged = CopyManagedToUnmanaged(arrayMarshallerName, lastIndexMarshalledName, nativeSpanName);

                var statements = new List<StatementSyntax>
                {
                    initializeManagedToUnmanaged
                };

                statements.AddRange(copyToUnmanaged);

                return statements.ToArray();
            }
        }

        public override StatementSyntax[] Free
        {
            get
            {
                var nativeSpan = SimpleVariable(
                GenericName("ReadOnlySpan").AddTypeArgumentListArguments(IdentifierName("IntPtr")),
                    nativeSpanName,
                    InvocationExpression(
                        MemberAccessExpression(
                            SyntaxKind.SimpleMemberAccessExpression,
                            IdentifierName(arrayMarshallerName),
                            IdentifierName("GetUnmanagedValuesDestination")
                        )
                    )
                );

                var currentIndex = IdentifierName("currentIndex");

                var forBody = elementMarshaller.Free(
                    CastExpression(
                        IdentifierName(elementMarshaller.UnmanagedType),
                        ElementAccessExpression(
                            IdentifierName(nativeSpanName)
                        ).AddArgumentListArguments(Argument(currentIndex))
                    )
                );

                if (forBody == null)
                    throw new NotImplementedException("Handling not having a free loop is not tested");

                var currentIndexVariable = VariableDeclaration(IdentifierName("int")).AddVariables(
                    VariableDeclarator(currentIndex.ToString()).WithInitializer(EqualsValueClause(LiteralExpression(SyntaxKind.NumericLiteralExpression, Literal(0))))
                );

                var currentIndexIncremetor = PostfixUnaryExpression(SyntaxKind.PostIncrementExpression, currentIndex);

                var forCondition = BinaryExpression(
                    SyntaxKind.LessThanExpression,
                    currentIndex,
                    IdentifierName(lastIndexMarshalledName)
                );

                var loop = ForStatement(forBody)
                    .WithDeclaration(currentIndexVariable)
                    .WithCondition(forCondition)
                    .AddIncrementors(currentIndexIncremetor);

                var freeMarshaller = MemberAccessExpression(
                    SyntaxKind.SimpleMemberAccessExpression,
                    IdentifierName(arrayMarshallerName),
                    IdentifierName("Free")
                );

                var freeInvocation = ExpressionStatement(InvocationExpression(freeMarshaller));

                return new StatementSyntax[]
                {
                    nativeSpan,
                    loop,
                    freeInvocation
                };
            }
        }

        #region ConvertToUnmanaged

        private LocalDeclarationStatementSyntax CreateManagedToUnmanagedMarshaller(
            TypeSyntax arrayMarshallerType,
            string arrayMarshallerName)
        {
            return SimpleVariable(
                arrayMarshallerType,
                arrayMarshallerName,
                ImplicitObjectCreationExpression()
            ).AddModifiers(Token(SyntaxKind.ScopedKeyword));
        }

        private LocalDeclarationStatementSyntax CreateLastIndexMarshalledVariable(string lastIndexMarshalledName)
        {
            return SimpleVariable(
                IdentifierName("int"),
                lastIndexMarshalledName,
                LiteralExpression(SyntaxKind.NumericLiteralExpression, Literal(0))
            );
        }

        private ExpressionStatementSyntax InitializeManagedToUnmanaged(
            TypeSyntax arrayMarshallerType,
            string arrayMarshallerName)
        {
            var fromManaged = MemberAccessExpression(
                SyntaxKind.SimpleMemberAccessExpression,
                IdentifierName(arrayMarshallerName),
                IdentifierName("FromManaged")
            );

            var bufferSize = MemberAccessExpression(
                SyntaxKind.SimpleMemberAccessExpression,
                arrayMarshallerType,
                IdentifierName("BufferSize")
            );

            var invocation = InvocationExpression(fromManaged)
                .AddArgumentListArguments(
                    Argument(ManagedName),
                    Argument(
                        StackAllocArrayCreationExpression(
                            ArrayType(IdentifierName("IntPtr"))
                            .AddRankSpecifiers(
                                ArrayRankSpecifier().AddSizes(bufferSize)
                            )
                        )
                    )
                );

            return ExpressionStatement(invocation);
        }

        private StatementSyntax[] CopyManagedToUnmanaged(
            string arrayMarshallerName,
            string lastIndexMarshalledName,
            string nativeSpanName)
        {
            var managedSpanName = $"_{ManagedName}_native__managedSpan";

            var managedSpan = SimpleVariable(
                GenericName("ReadOnlySpan").AddTypeArgumentListArguments(ManagedType),
                managedSpanName,
                InvocationExpression(
                    MemberAccessExpression(
                        SyntaxKind.SimpleMemberAccessExpression,
                        IdentifierName(arrayMarshallerName),
                        IdentifierName("GetManagedValuesSource")
                    )
                )
            );

            var nativeSpan = SimpleVariable(
                GenericName("Span").AddTypeArgumentListArguments(IdentifierName("IntPtr")),
                nativeSpanName,
                InvocationExpression(
                    MemberAccessExpression(
                        SyntaxKind.SimpleMemberAccessExpression,
                        IdentifierName(arrayMarshallerName),
                        IdentifierName("GetUnmanagedValuesDestination")
                    )
                )
            );

            var currentIndex = IdentifierName("currentIndex");

            var forBody = Block()
                .AddStatements(
                    ExpressionStatement(
                        AssignmentExpression(
                            SyntaxKind.SimpleAssignmentExpression,
                            ElementAccessExpression(
                                IdentifierName(nativeSpanName)
                            ).AddArgumentListArguments(Argument(currentIndex)),
                            CastExpression(
                                IdentifierName("IntPtr"),
                                elementMarshaller.ToUnmanaged(
                                    ElementAccessExpression(IdentifierName(managedSpanName))
                                    .AddArgumentListArguments(
                                        Argument(currentIndex)
                                    )
                                )
                            )
                        )
                    )
                ); ;

            var currentIndexVariable = VariableDeclaration(IdentifierName("int")).AddVariables(
                VariableDeclarator(currentIndex.ToString()).WithInitializer(EqualsValueClause(LiteralExpression(SyntaxKind.NumericLiteralExpression, Literal(0))))
            );

            var forCondition = BinaryExpression(
                SyntaxKind.LessThanExpression,
                currentIndex,
                MemberAccessExpression(
                    SyntaxKind.SimpleMemberAccessExpression,
                    IdentifierName(managedSpanName),
                    IdentifierName("Length")
                )
            );

            var currentIndexIncremetor = PostfixUnaryExpression(SyntaxKind.PostIncrementExpression, currentIndex);
            var lastIndexMarshalledIncrementor = PostfixUnaryExpression(SyntaxKind.PostIncrementExpression, IdentifierName(lastIndexMarshalledName));

            var loop = ForStatement(forBody)
                .WithDeclaration(currentIndexVariable)
                .WithCondition(forCondition)
                .AddIncrementors(currentIndexIncremetor, lastIndexMarshalledIncrementor);

            return new StatementSyntax[]
            {
                managedSpan,
                nativeSpan,
                loop
            };
        }

        #endregion
    }
}
