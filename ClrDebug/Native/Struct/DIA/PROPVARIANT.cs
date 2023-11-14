using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using ClrDebug.TypeLib;

namespace ClrDebug.DIA
{
    [DebuggerDisplay("vt = {vt}")]
    [StructLayout(LayoutKind.Explicit, Pack = 8)]
    public unsafe partial struct PROPVARIANT
    {
        [FieldOffset(0)]
        public VARENUM vt;

        [FieldOffset(2)]
        public short wReserved1;

        [FieldOffset(4)]
        public short wReserved2;

        [FieldOffset(6)]
        public short wReserved3;

        [FieldOffset(8)]
        public sbyte cVal;

        [FieldOffset(8)]
        public byte bVal;

        [FieldOffset(8)]
        public short iVal;

        [FieldOffset(8)]
        public ushort uiVal;

        [FieldOffset(8)]
        public int lVal;

        [FieldOffset(8)]
        public uint ulVal;

        [FieldOffset(8)]
        public int intVal;

        [FieldOffset(8)]
        public uint uintVal;

        [FieldOffset(8)]
        public LARGE_INTEGER hVal;

        [FieldOffset(8)]
        public ULARGE_INTEGER uhVal;

        [FieldOffset(8)]
        public float fltVal;

        [FieldOffset(8)]
        public double dblVal;

        [FieldOffset(8)]
        [MarshalAs(UnmanagedType.VariantBool)]
        public bool boolVal;

        [FieldOffset(8)]
        [MarshalAs(UnmanagedType.VariantBool)]
        public bool __OBSOLETE__VARIANT_BOOL;

        [FieldOffset(8)]
        public HRESULT scode;

        [FieldOffset(8)]
        public CY cyVal;

        [FieldOffset(8)]
        public double date;

        [FieldOffset(8)]
        public FILETIME filetime;

        //CLSID* puuid;

        [FieldOffset(8)]
        public CLIPDATA* pclipdata;

        //BSTR bstrVal;

        [FieldOffset(8)]
        public BSTRBLOB bstrblobVal;

        [FieldOffset(8)]
        public BLOB blob;

        //LPSTR pszVal;
        //LPWSTR pwszVal;
        //IUnknown* punkVal;
        //IDispatch* pdispVal;
        //IStream* pStream;
        //IStorage* pStorage;

        [FieldOffset(8)]
        public VERSIONEDSTREAM* pVersionedStream;

        //LPSAFEARRAY parray;

        [FieldOffset(8)]
        public CAC cac;

        [FieldOffset(8)]
        public CAUB caub;

        [FieldOffset(8)]
        public CAI cai;

        [FieldOffset(8)]
        public CAUI caui;

        [FieldOffset(8)]
        public CAL cal;

        [FieldOffset(8)]
        public CAUL caul;

        [FieldOffset(8)]
        public CAH cah;

        [FieldOffset(8)]
        public CAUH cauh;

        [FieldOffset(8)]
        public CAFLT caflt;

        [FieldOffset(8)]
        public CADBL cadbl;

        [FieldOffset(8)]
        public CABOOL cabool;

        [FieldOffset(8)]
        public CASCODE cascode;

        [FieldOffset(8)]
        public CACY cacy;

        [FieldOffset(8)]
        public CADATE cadate;

        [FieldOffset(8)]
        public CAFILETIME cafiletime;

        [FieldOffset(8)]
        public CACLSID cauuid;

        [FieldOffset(8)]
        public CACLIPDATA caclipdata;

        [FieldOffset(8)]
        public CABSTR cabstr;

        [FieldOffset(8)]
        public CABSTRBLOB cabstrblob;

        [FieldOffset(8)]
        public CALPSTR calpstr;

        [FieldOffset(8)]
        public CALPWSTR calpwstr;

        [FieldOffset(8)]
        public CAPROPVARIANT capropvar;

        [FieldOffset(8)]
        public sbyte* pcVal;

        [FieldOffset(8)]
        public byte* pbVal;

        [FieldOffset(8)]
        public short* piVal;

        [FieldOffset(8)]
        public ushort* puiVal;

        [FieldOffset(8)]
        public int* plVal;

        [FieldOffset(8)]
        public uint* pulVal;

        [FieldOffset(8)]
        public int pintVal;

        [FieldOffset(8)]
        public uint* puintVal;

        [FieldOffset(8)]
        public float* pfltVal;

        [FieldOffset(8)]
        public double* pdblVal;

        [FieldOffset(8)]
        public short* pboolVal; //VARIANT_BOOL

        //DECIMAL* pdecVal;

        [FieldOffset(8)]
        public HRESULT* pscode;

        //CY *pcyVal;
        //DATE *pdate;
        //BSTR *pbstrVal;
        //IUnknown **ppunkVal;
        //IDispatch **ppdispVal;
        //LPSAFEARRAY *pparray;
        //PROPVARIANT *pvarVal;
    }
}
