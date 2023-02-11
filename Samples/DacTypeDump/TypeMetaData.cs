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

        public void AddMethod(string name)
        {
            Members.Add(
                new Member
                {
                    Name = name,
                    Type = "Method"
                }
            );
        }

        public void AddField(string name)
        {
            Members.Add(
                new Member
                {
                    Name = name,
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
