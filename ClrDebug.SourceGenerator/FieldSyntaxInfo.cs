using System.Linq;
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

            if (Type == "bool")
                Marshaller = new BoolFieldMarshaller(Name, Type, "int");
            else if (IsInterfaceLike)
                Marshaller = new InterfaceFieldMarshaller(Name, Type, "void*");
            else
                Marshaller = new FieldMarshaller(Name, Type, Type);

            FieldOffset = field.AttributeLists.SelectMany(a => a.Attributes).SingleOrDefault(a => a.Name.ToString() == "FieldOffset")?.WithoutTrivia();
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
