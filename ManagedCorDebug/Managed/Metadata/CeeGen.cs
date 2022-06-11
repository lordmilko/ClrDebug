using System;
using System.Runtime.InteropServices;

namespace ManagedCorDebug
{
    public class CeeGen : ComObject<ICeeGen>
    {
        public CeeGen(ICeeGen raw) : base(raw)
        {
        }

        #region ICeeGen
        #region GetIMapTokenIface

        [Obsolete]
        public object IMapTokenIface
        {
            get
            {
                HRESULT hr;
                object pIMapToken = default(object);

                if ((hr = TryGetIMapTokenIface(ref pIMapToken)) != HRESULT.S_OK)
                    Marshal.ThrowExceptionForHR((int) hr);

                return pIMapToken;
            }
        }

        [Obsolete]
        public HRESULT TryGetIMapTokenIface(ref object pIMapToken)
        {
            /*HRESULT GetIMapTokenIface(
            [In, Out, MarshalAs(UnmanagedType.Interface)] ref object pIMapToken);*/
            return Raw.GetIMapTokenIface(ref pIMapToken);
        }

        #endregion
        #region GetStringSection

        [Obsolete]
        public IntPtr StringSection
        {
            get
            {
                HRESULT hr;
                IntPtr section = default(IntPtr);

                if ((hr = TryGetStringSection(ref section)) != HRESULT.S_OK)
                    Marshal.ThrowExceptionForHR((int) hr);

                return section;
            }
        }

        [Obsolete]
        public HRESULT TryGetStringSection(ref IntPtr section)
        {
            /*HRESULT GetStringSection([In, Out] ref IntPtr section);*/
            return Raw.GetStringSection(ref section);
        }

        #endregion
        #region EmitString

        [Obsolete]
        public uint EmitString(string lpString)
        {
            HRESULT hr;
            uint rVA;

            if ((hr = TryEmitString(lpString, out rVA)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return rVA;
        }

        [Obsolete]
        public HRESULT TryEmitString(string lpString, out uint rVA)
        {
            /*HRESULT EmitString(
            [In, MarshalAs(UnmanagedType.LPWStr)] string lpString,
            [Out] out uint RVA);*/
            return Raw.EmitString(lpString, out rVA);
        }

        #endregion
        #region GetString

        [Obsolete]
        public string GetString(ulong rVA)
        {
            HRESULT hr;
            string lpString = default(string);

            if ((hr = TryGetString(rVA, ref lpString)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return lpString;
        }

        [Obsolete]
        public HRESULT TryGetString(ulong rVA, ref string lpString)
        {
            /*HRESULT GetString(
            [In] ulong RVA,
            [Out, MarshalAs(UnmanagedType.LPWStr)] string lpString);*/
            return Raw.GetString(rVA, lpString);
        }

        #endregion
        #region AllocateMethodBuffer

        [Obsolete]
        public AllocateMethodBufferResult AllocateMethodBuffer(uint cchBuffer)
        {
            HRESULT hr;
            AllocateMethodBufferResult result;

            if ((hr = TryAllocateMethodBuffer(cchBuffer, out result)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return result;
        }

        [Obsolete]
        public HRESULT TryAllocateMethodBuffer(uint cchBuffer, out AllocateMethodBufferResult result)
        {
            /*HRESULT AllocateMethodBuffer(
            [In] uint cchBuffer,
            [Out] IntPtr lpBuffer,
            [Out] out uint RVA);*/
            IntPtr lpBuffer = default(IntPtr);
            uint rVA;
            HRESULT hr = Raw.AllocateMethodBuffer(cchBuffer, lpBuffer, out rVA);

            if (hr == HRESULT.S_OK)
                result = new AllocateMethodBufferResult(lpBuffer, rVA);
            else
                result = default(AllocateMethodBufferResult);

            return hr;
        }

        #endregion
        #region GetMethodBuffer

        [Obsolete]
        public IntPtr GetMethodBuffer(uint rVA)
        {
            HRESULT hr;
            IntPtr lpBuffer = default(IntPtr);

            if ((hr = TryGetMethodBuffer(rVA, ref lpBuffer)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return lpBuffer;
        }

        [Obsolete]
        public HRESULT TryGetMethodBuffer(uint rVA, ref IntPtr lpBuffer)
        {
            /*HRESULT GetMethodBuffer(
            [In] uint RVA,
            [Out] IntPtr lpBuffer);*/
            return Raw.GetMethodBuffer(rVA, lpBuffer);
        }

        #endregion
        #region GenerateCeeFile

        [Obsolete]
        public void GenerateCeeFile()
        {
            HRESULT hr;

            if ((hr = TryGenerateCeeFile()) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);
        }

        [Obsolete]
        public HRESULT TryGenerateCeeFile()
        {
            /*HRESULT GenerateCeeFile();*/
            return Raw.GenerateCeeFile();
        }

        #endregion
        #region GetIlSection

        [Obsolete]
        public void GetIlSection(IntPtr section)
        {
            HRESULT hr;

            if ((hr = TryGetIlSection(section)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);
        }

        [Obsolete]
        public HRESULT TryGetIlSection(IntPtr section)
        {
            /*HRESULT GetIlSection([In] IntPtr section);*/
            return Raw.GetIlSection(section);
        }

        #endregion
        #region AddSectionReloc

        [Obsolete]
        public void AddSectionReloc(IntPtr section, uint offset, IntPtr relativeTo, CeeSectionRelocType relocType)
        {
            HRESULT hr;

            if ((hr = TryAddSectionReloc(section, offset, relativeTo, relocType)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);
        }

        [Obsolete]
        public HRESULT TryAddSectionReloc(IntPtr section, uint offset, IntPtr relativeTo, CeeSectionRelocType relocType)
        {
            /*HRESULT AddSectionReloc(
            [In] IntPtr section,
            [In] uint offset,
            [In] IntPtr relativeTo,
            [In] CeeSectionRelocType relocType);*/
            return Raw.AddSectionReloc(section, offset, relativeTo, relocType);
        }

        #endregion
        #region GetSectionCreate

        [Obsolete]
        public IntPtr GetSectionCreate(string name, uint flags)
        {
            HRESULT hr;
            IntPtr section = default(IntPtr);

            if ((hr = TryGetSectionCreate(name, flags, ref section)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return section;
        }

        [Obsolete]
        public HRESULT TryGetSectionCreate(string name, uint flags, ref IntPtr section)
        {
            /*HRESULT GetSectionCreate(
            [In] string name,
            [In] uint flags,
            [Out] IntPtr section);*/
            return Raw.GetSectionCreate(name, flags, section);
        }

        #endregion
        #region GetSectionDataLen

        [Obsolete]
        public uint GetSectionDataLen(IntPtr section)
        {
            HRESULT hr;
            uint dataLen;

            if ((hr = TryGetSectionDataLen(section, out dataLen)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return dataLen;
        }

        [Obsolete]
        public HRESULT TryGetSectionDataLen(IntPtr section, out uint dataLen)
        {
            /*HRESULT GetSectionDataLen(
            [In] IntPtr section,
            [Out] out uint dataLen);*/
            return Raw.GetSectionDataLen(section, out dataLen);
        }

        #endregion
        #region GetSectionBlock

        [Obsolete]
        public IntPtr GetSectionBlock(IntPtr section, uint len, uint align)
        {
            HRESULT hr;
            IntPtr ppBytes = default(IntPtr);

            if ((hr = TryGetSectionBlock(section, len, align, ref ppBytes)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return ppBytes;
        }

        [Obsolete]
        public HRESULT TryGetSectionBlock(IntPtr section, uint len, uint align, ref IntPtr ppBytes)
        {
            /*HRESULT GetSectionBlock(
            [In] IntPtr section,
            [In] uint len,
            [In] uint align,
            [Out] IntPtr ppBytes);*/
            return Raw.GetSectionBlock(section, len, align, ppBytes);
        }

        #endregion
        #region TruncateSection

        [Obsolete]
        public void TruncateSection(IntPtr section, uint len)
        {
            HRESULT hr;

            if ((hr = TryTruncateSection(section, len)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);
        }

        [Obsolete]
        public HRESULT TryTruncateSection(IntPtr section, uint len)
        {
            /*HRESULT TruncateSection(
            [In] IntPtr section,
            [In] uint len);*/
            return Raw.TruncateSection(section, len);
        }

        #endregion
        #region GenerateCeeMemoryImage

        [Obsolete]
        public IntPtr GenerateCeeMemoryImage()
        {
            HRESULT hr;
            IntPtr ppImage = default(IntPtr);

            if ((hr = TryGenerateCeeMemoryImage(ref ppImage)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return ppImage;
        }

        [Obsolete]
        public HRESULT TryGenerateCeeMemoryImage(ref IntPtr ppImage)
        {
            /*HRESULT GenerateCeeMemoryImage(
            [Out] IntPtr ppImage);*/
            return Raw.GenerateCeeMemoryImage(ppImage);
        }

        #endregion
        #region ComputePointer

        [Obsolete]
        public IntPtr ComputePointer(IntPtr section, uint rVA)
        {
            HRESULT hr;
            IntPtr lpBuffer = default(IntPtr);

            if ((hr = TryComputePointer(section, rVA, ref lpBuffer)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return lpBuffer;
        }

        [Obsolete]
        public HRESULT TryComputePointer(IntPtr section, uint rVA, ref IntPtr lpBuffer)
        {
            /*HRESULT ComputePointer(
            [In] IntPtr section,
            [In] uint RVA,
            [Out] IntPtr lpBuffer);*/
            return Raw.ComputePointer(section, rVA, lpBuffer);
        }

        #endregion
        #endregion
    }
}