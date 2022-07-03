using System.Collections.Generic;
using System.Diagnostics;
using ClrDebug;

namespace DacTypeDump
{
    [DebuggerDisplay("{Name,nq}")]
    public class TypeMetaData
    {
        public string Name { get; }

        public List<Member> Members { get; } = new List<Member>();

        public TypeMetaData(string name)
        {
            Name = name;
        }

        public void AddMethod(MetaDataImport_GetMethodPropsResult methodProps)
        {
            Members.Add(
                new Member
                {
                    Name = methodProps.szMethod,
                    Type = "Method"
                }
            );
        }

        public void AddField(GetFieldPropsResult fieldProps)
        {
            Members.Add(
                new Member
                {
                    Name = fieldProps.szField,
                    Type = "Field"
                }
            );
        }
    }

    [DebuggerDisplay("{Name,nq} ({Type,nq})")]
    public struct Member
    {
        public string Name;
        public string Type;
    }
}
