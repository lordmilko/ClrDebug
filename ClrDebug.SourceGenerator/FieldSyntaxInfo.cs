using System;
using System.Linq;
using System.Runtime.InteropServices;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace ClrDebug.SourceGenerator
{
    internal class FieldSyntaxInfo
    {
        public string Name { get; }

        public string Type { get; }

        public bool RequiresMarshalling => Marshaller.GetType() != typeof(FieldMarshaller);

        public FieldMarshaller Marshaller { get; }

        public AttributeSyntax FieldOffset { get; }

        private bool IsInterfaceLike => Type.Length > 3 && Type[0] == 'I' && char.IsUpper(Type[1]) && char.IsLower(Type[2]);

        public FieldSyntaxInfo(FieldDeclarationSyntax field)
        {
            Name = field.Declaration.Variables.Single().Identifier.ToString();
            Type = field.Declaration.Type.ToString();

            var marshalAsAttribute = field.AttributeLists.SelectMany(a => a.Attributes).SingleOrDefault(a => a.Name.ToString() == "MarshalAs");
            var unmanagedType = marshalAsAttribute == null ? null : (UnmanagedType?) Enum.Parse(typeof(UnmanagedType), ((MemberAccessExpressionSyntax)marshalAsAttribute?.ArgumentList.Arguments.First().Expression).Name.ToString());

            if (Type == "bool")
                Marshaller = new BoolFieldMarshaller(Name, Type, "int");
            else if (IsInterfaceLike)
                Marshaller = new InterfaceFieldMarshaller(Name, Type, "void*");
            else if (Type == "string")
            {
                if (marshalAsAttribute == null)
                    throw new InvalidOperationException($"Field {((StructDeclarationSyntax)field.Parent).Identifier}.{Name} is missing a MarshalAsAttribute.");

                if (unmanagedType == UnmanagedType.LPStr)
                    Marshaller = new AnsiFieldMarshaller(Name, Type, "byte*");
                else if (unmanagedType == UnmanagedType.LPWStr)
                    Marshaller = new UTF16FieldMarshaller(Name, Type, "ushort*");
                else if (unmanagedType == UnmanagedType.BStr)
                    Marshaller = new BStrFieldMarshaller(Name, Type, "ushort*");
                else if (unmanagedType == UnmanagedType.LPTStr)
                    Marshaller = new CrossPlatformStringMarshaller(Name, Type);
                else
                    throw new NotImplementedException($"Don't know how to handle string with UnmanagedType.{unmanagedType}");
            }
            else
            {
                if (unmanagedType == UnmanagedType.ByValArray)
                {
                    var elementType = ((ArrayTypeSyntax)field.Declaration.Type).ElementType.ToString();

                    var size = marshalAsAttribute.ArgumentList.Arguments.Single(a => a.NameEquals?.Name.ToString() == "SizeConst");

                    Marshaller = new ByValArrayFieldMarshaller(Name, Type, $"{elementType}*", elementType, size.Expression);
                }
                else
                    Marshaller = new FieldMarshaller(Name, Type, Type);
            }

            FieldOffset = field.AttributeLists.SelectMany(a => a.Attributes).SingleOrDefault(a => a.Name.ToString() == "FieldOffset")?.WithoutTrivia();
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
