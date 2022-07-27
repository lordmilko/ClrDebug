using System;
using System.Text;
using ClrDebug.DbgEng;

namespace DbgEngTypedData.Custom
{
    class DbgUnicodeString : DbgObject
    {
        public string String { get; }

        public DbgUnicodeString(long address, DbgType type) : base(address, type)
        {
            var length = Convert.ToInt32(this["Length"].Value);
            var buffer = this["Buffer"].Address;
            var maxLength = Convert.ToInt32(this["MaximumLength"].Value);

            if (buffer != 0 && length < maxLength)
            {
                //LDR_DATA_TABLE_ENTRY.FullDllName can contain garbage data (and a length longer than max length which is bogus)
                if (client.DataSpaces.TryReadVirtual(buffer, length, out var bytes) == ClrDebug.HRESULT.S_OK)
                    String = Encoding.Unicode.GetString(bytes);
            }
        }

        public override string ToString()
        {
            return String ?? base.ToString();
        }
    }
}
