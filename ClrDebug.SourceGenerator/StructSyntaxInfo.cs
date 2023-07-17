using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace ClrDebug.SourceGenerator
{
    internal class StructSyntaxInfo
    {
        public string Name { get; }

        public string NativeName => Name + "_Native";

        public bool RequiresMarshalling => Fields.Any(f => f.RequiresMarshalling);

        public bool HasPartial => Syntax.Modifiers.Any(m => m.IsKind(SyntaxKind.PartialKeyword));

        public FieldSyntaxInfo[] Fields { get; }

        public StructDeclarationSyntax Syntax { get; }

        public AttributeSyntax StructLayout { get; }

        public StructSyntaxInfo(StructDeclarationSyntax @struct)
        {
            Syntax = @struct;
            Name = @struct.Identifier.ToString();
            Fields = @struct.Members.OfType<FieldDeclarationSyntax>().Select(f => new FieldSyntaxInfo(f)).ToArray();

            StructLayout = @struct.AttributeLists.SelectMany(a => a.Attributes).SingleOrDefault(a => a.Name.ToString() == "StructLayout")?.WithoutTrivia();
        }
    }
}
