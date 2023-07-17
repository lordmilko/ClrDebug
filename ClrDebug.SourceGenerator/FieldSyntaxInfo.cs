using System.Linq;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace ClrDebug.SourceGenerator
{
    internal class FieldSyntaxInfo
    {
        public string Name { get; }

        public string Type { get; }

        public bool RequiresMarshalling => Marshaller.GetType() != typeof(FieldMarshaller);

        public FieldMarshaller Marshaller { get; }

        public FieldSyntaxInfo(FieldDeclarationSyntax field)
        {
            Name = field.Declaration.Variables.Single().Identifier.ToString();
            Type = field.Declaration.Type.ToString();

            if (Type == "bool")
                Marshaller = new BoolFieldMarshaller(Name, Type, "int");
            else
                Marshaller = new FieldMarshaller(Name, Type, Type);
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
