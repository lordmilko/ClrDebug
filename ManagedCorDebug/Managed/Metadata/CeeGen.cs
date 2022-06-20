using System;
using System.Text;

namespace ManagedCorDebug
{
    /// <summary>
    /// Provides methods for dynamic code compilation. This interface is obsolete and should not be used.
    /// </summary>
    public class CeeGen : ComObject<ICeeGen>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CeeGen"/> class.
        /// </summary>
        /// <param name="raw">The raw COM interface that should be contained in this object.</param>
        public CeeGen(ICeeGen raw) : base(raw)
        {
        }

        #region ICeeGen
        #region IMapTokenIface

        /// <summary>
        /// Gets the interface referenced by the specified token. This method is obsolete and should not be used.
        /// </summary>
        [Obsolete]
        public object IMapTokenIface
        {
            get
            {
                object pIMapToken;
                TryGetIMapTokenIface(out pIMapToken).ThrowOnNotOK();

                return pIMapToken;
            }
        }

        /// <summary>
        /// Gets the interface referenced by the specified token. This method is obsolete and should not be used.
        /// </summary>
        /// <param name="pIMapToken">[in, out] The metadata token for the interface to be returned.</param>
        [Obsolete]
        public HRESULT TryGetIMapTokenIface(out object pIMapToken)
        {
            /*HRESULT GetIMapTokenIface(
            [Out, MarshalAs(UnmanagedType.Interface)] out object pIMapToken);*/
            return Raw.GetIMapTokenIface(out pIMapToken);
        }

        #endregion
        #region EmitString

        /// <summary>
        /// Emits the specified string into the code base. This method is obsolete and should not be used.
        /// </summary>
        /// <param name="lpString">[in] The string to emit.</param>
        /// <returns>[out] The relative virtual address of the emitted string.</returns>
        [Obsolete]
        public int EmitString(string lpString)
        {
            int RVA;
            TryEmitString(lpString, out RVA).ThrowOnNotOK();

            return RVA;
        }

        /// <summary>
        /// Emits the specified string into the code base. This method is obsolete and should not be used.
        /// </summary>
        /// <param name="lpString">[in] The string to emit.</param>
        /// <param name="RVA">[out] The relative virtual address of the emitted string.</param>
        [Obsolete]
        public HRESULT TryEmitString(string lpString, out int RVA)
        {
            /*HRESULT EmitString(
            [In, MarshalAs(UnmanagedType.LPWStr)] string lpString,
            [Out] out int RVA);*/
            return Raw.EmitString(lpString, out RVA);
        }

        #endregion
        #region GetString

        /// <summary>
        /// Gets the string stored at the specified relative virtual address. This method is obsolete and should not be used.
        /// </summary>
        /// <param name="RVA">[in] The relative virtual address of the string to return.</param>
        /// <returns>[out] The returned string.</returns>
        [Obsolete]
        public string GetString(long RVA)
        {
            string lpStringResult;
            TryGetString(RVA, out lpStringResult).ThrowOnNotOK();

            return lpStringResult;
        }

        /// <summary>
        /// Gets the string stored at the specified relative virtual address. This method is obsolete and should not be used.
        /// </summary>
        /// <param name="RVA">[in] The relative virtual address of the string to return.</param>
        /// <param name="lpStringResult">[out] The returned string.</param>
        [Obsolete]
        public HRESULT TryGetString(long RVA, out string lpStringResult)
        {
            /*HRESULT GetString(
            [In] long RVA,
            [Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder lpString);*/
            StringBuilder lpString = null;
            HRESULT hr = Raw.GetString(RVA, lpString);

            if (hr == HRESULT.S_OK)
                lpStringResult = lpString.ToString();
            else
                lpStringResult = default(string);

            return hr;
        }

        #endregion
        #region AllocateMethodBuffer

        /// <summary>
        /// Creates a buffer of the specified size for a method, and gets the relative virtual address of the method. This method is obsolete and should not be used.
        /// </summary>
        /// <param name="cchBuffer">[in] The length of the buffer to create.</param>
        /// <returns>The values that were emitted from the COM method.</returns>
        [Obsolete]
        public AllocateMethodBufferResult AllocateMethodBuffer(int cchBuffer)
        {
            AllocateMethodBufferResult result;
            TryAllocateMethodBuffer(cchBuffer, out result).ThrowOnNotOK();

            return result;
        }

        /// <summary>
        /// Creates a buffer of the specified size for a method, and gets the relative virtual address of the method. This method is obsolete and should not be used.
        /// </summary>
        /// <param name="cchBuffer">[in] The length of the buffer to create.</param>
        /// <param name="result">The values that were emitted from the COM method.</param>
        [Obsolete]
        public HRESULT TryAllocateMethodBuffer(int cchBuffer, out AllocateMethodBufferResult result)
        {
            /*HRESULT AllocateMethodBuffer(
            [In] int cchBuffer,
            [Out] out IntPtr lpBuffer,
            [Out] out int RVA);*/
            IntPtr lpBuffer;
            int RVA;
            HRESULT hr = Raw.AllocateMethodBuffer(cchBuffer, out lpBuffer, out RVA);

            if (hr == HRESULT.S_OK)
                result = new AllocateMethodBufferResult(lpBuffer, RVA);
            else
                result = default(AllocateMethodBufferResult);

            return hr;
        }

        #endregion
        #region GetMethodBuffer

        /// <summary>
        /// Gets a buffer of the appropriate size for the method at the specified relative virtual address. This method is obsolete and should not be used.
        /// </summary>
        /// <param name="RVA">[in] The relative virtual address of the method for which to return a buffer.</param>
        /// <returns>[out] A pointer to the returned buffer.</returns>
        [Obsolete]
        public IntPtr GetMethodBuffer(int RVA)
        {
            IntPtr lpBuffer;
            TryGetMethodBuffer(RVA, out lpBuffer).ThrowOnNotOK();

            return lpBuffer;
        }

        /// <summary>
        /// Gets a buffer of the appropriate size for the method at the specified relative virtual address. This method is obsolete and should not be used.
        /// </summary>
        /// <param name="RVA">[in] The relative virtual address of the method for which to return a buffer.</param>
        /// <param name="lpBuffer">[out] A pointer to the returned buffer.</param>
        [Obsolete]
        public HRESULT TryGetMethodBuffer(int RVA, out IntPtr lpBuffer)
        {
            /*HRESULT GetMethodBuffer(
            [In] int RVA,
            [Out] out IntPtr lpBuffer);*/
            return Raw.GetMethodBuffer(RVA, out lpBuffer);
        }

        #endregion
        #region GenerateCeeFile

        /// <summary>
        /// Generates a code-base file that contains the code base currently loaded into this <see cref="ICeeGen"/> interface.<para/>
        /// This method is obsolete and should not be used.
        /// </summary>
        [Obsolete]
        public void GenerateCeeFile()
        {
            TryGenerateCeeFile().ThrowOnNotOK();
        }

        /// <summary>
        /// Generates a code-base file that contains the code base currently loaded into this <see cref="ICeeGen"/> interface.<para/>
        /// This method is obsolete and should not be used.
        /// </summary>
        [Obsolete]
        public HRESULT TryGenerateCeeFile()
        {
            /*HRESULT GenerateCeeFile();*/
            return Raw.GenerateCeeFile();
        }

        #endregion
        #region GetIlSection

        /// <summary>
        /// Gets the section of the intermediate language code base referenced by the specified handle. This method is obsolete and should not be used.
        /// </summary>
        /// <param name="section">[in] The handle to the section to get.</param>
        [Obsolete]
        public void GetIlSection(IntPtr section)
        {
            TryGetIlSection(section).ThrowOnNotOK();
        }

        /// <summary>
        /// Gets the section of the intermediate language code base referenced by the specified handle. This method is obsolete and should not be used.
        /// </summary>
        /// <param name="section">[in] The handle to the section to get.</param>
        [Obsolete]
        public HRESULT TryGetIlSection(IntPtr section)
        {
            /*HRESULT GetIlSection([In] IntPtr section);*/
            return Raw.GetIlSection(section);
        }

        #endregion
        #region GetStringSection

        /// <summary>
        /// Gets a string representation of the code section referenced by the specified handle. This method is obsolete and should not be used.
        /// </summary>
        /// <param name="section">[in, out] The handle to the code section.</param>
        [Obsolete]
        public void GetStringSection(ref IntPtr section)
        {
            TryGetStringSection(ref section).ThrowOnNotOK();
        }

        /// <summary>
        /// Gets a string representation of the code section referenced by the specified handle. This method is obsolete and should not be used.
        /// </summary>
        /// <param name="section">[in, out] The handle to the code section.</param>
        [Obsolete]
        public HRESULT TryGetStringSection(ref IntPtr section)
        {
            /*HRESULT GetStringSection([In, Out] ref IntPtr section);*/
            return Raw.GetStringSection(ref section);
        }

        #endregion
        #region AddSectionReloc

        /// <summary>
        /// Adds a .reloc instruction to the code base. This method is obsolete and should not be used.
        /// </summary>
        /// <param name="section">[in] The section of in-memory code to which to add a .reloc instruction.</param>
        /// <param name="offset">[in] The offset of the section.</param>
        /// <param name="relativeTo">[in] The section to which offset refers.</param>
        /// <param name="relocType">[in] One of the <see cref="CeeSectionRelocType"/> values, indicating the kind of .reloc instruction to add.</param>
        [Obsolete]
        public void AddSectionReloc(IntPtr section, int offset, IntPtr relativeTo, CeeSectionRelocType relocType)
        {
            TryAddSectionReloc(section, offset, relativeTo, relocType).ThrowOnNotOK();
        }

        /// <summary>
        /// Adds a .reloc instruction to the code base. This method is obsolete and should not be used.
        /// </summary>
        /// <param name="section">[in] The section of in-memory code to which to add a .reloc instruction.</param>
        /// <param name="offset">[in] The offset of the section.</param>
        /// <param name="relativeTo">[in] The section to which offset refers.</param>
        /// <param name="relocType">[in] One of the <see cref="CeeSectionRelocType"/> values, indicating the kind of .reloc instruction to add.</param>
        [Obsolete]
        public HRESULT TryAddSectionReloc(IntPtr section, int offset, IntPtr relativeTo, CeeSectionRelocType relocType)
        {
            /*HRESULT AddSectionReloc(
            [In] IntPtr section,
            [In] int offset,
            [In] IntPtr relativeTo,
            [In] CeeSectionRelocType relocType);*/
            return Raw.AddSectionReloc(section, offset, relativeTo, relocType);
        }

        #endregion
        #region GetSectionCreate

        /// <summary>
        /// Generates and gets a code section using the specified name and flag values. This method is obsolete and should not be used.
        /// </summary>
        /// <param name="name">[in] A pointer to a string that specifies the name of the section to be created.</param>
        /// <param name="flags">[in] Flags that specify options.</param>
        /// <returns>[out] A pointer to the newly created code section.</returns>
        /// <remarks>
        /// Call GetSectionCreate only if you have special section requirements that are not handled by other methods.
        /// </remarks>
        [Obsolete]
        public IntPtr GetSectionCreate(string name, int flags)
        {
            IntPtr section;
            TryGetSectionCreate(name, flags, out section).ThrowOnNotOK();

            return section;
        }

        /// <summary>
        /// Generates and gets a code section using the specified name and flag values. This method is obsolete and should not be used.
        /// </summary>
        /// <param name="name">[in] A pointer to a string that specifies the name of the section to be created.</param>
        /// <param name="flags">[in] Flags that specify options.</param>
        /// <param name="section">[out] A pointer to the newly created code section.</param>
        /// <remarks>
        /// Call GetSectionCreate only if you have special section requirements that are not handled by other methods.
        /// </remarks>
        [Obsolete]
        public HRESULT TryGetSectionCreate(string name, int flags, out IntPtr section)
        {
            /*HRESULT GetSectionCreate(
            [In, MarshalAs(UnmanagedType.LPWStr)] string name,
            [In] int flags,
            [Out] out IntPtr section);*/
            return Raw.GetSectionCreate(name, flags, out section);
        }

        #endregion
        #region GetSectionDataLen

        /// <summary>
        /// Gets the length of the specified section. This method is obsolete and should not be used.
        /// </summary>
        /// <param name="section">[in] The data section whose length will be retrieved.</param>
        /// <returns>[out] The returned length of the specified section.</returns>
        /// <remarks>
        /// Call GetSectionDataLen only if you have special section requirements that are not handled by other methods.
        /// </remarks>
        [Obsolete]
        public int GetSectionDataLen(IntPtr section)
        {
            int dataLen;
            TryGetSectionDataLen(section, out dataLen).ThrowOnNotOK();

            return dataLen;
        }

        /// <summary>
        /// Gets the length of the specified section. This method is obsolete and should not be used.
        /// </summary>
        /// <param name="section">[in] The data section whose length will be retrieved.</param>
        /// <param name="dataLen">[out] The returned length of the specified section.</param>
        /// <remarks>
        /// Call GetSectionDataLen only if you have special section requirements that are not handled by other methods.
        /// </remarks>
        [Obsolete]
        public HRESULT TryGetSectionDataLen(IntPtr section, out int dataLen)
        {
            /*HRESULT GetSectionDataLen(
            [In] IntPtr section,
            [Out] out int dataLen);*/
            return Raw.GetSectionDataLen(section, out dataLen);
        }

        #endregion
        #region GetSectionBlock

        /// <summary>
        /// Gets a section block of the code base. This method is obsolete and should not be used.
        /// </summary>
        /// <param name="section">[in] The section from which to retrieve a block of the code base.</param>
        /// <param name="len">[in] The length of the block to be retrieved.</param>
        /// <param name="align">[in] The byte, relative to the beginning of the section, with which to align the first byte of the block. This is the position of the block within the section.</param>
        /// <returns>[out] A pointer to a location that receives the address of the retrieved block.</returns>
        /// <remarks>
        /// Call GetSectionBlock only if you have special section requirements that are not handled by other methods.
        /// </remarks>
        [Obsolete]
        public IntPtr GetSectionBlock(IntPtr section, int len, int align)
        {
            IntPtr ppBytes;
            TryGetSectionBlock(section, len, align, out ppBytes).ThrowOnNotOK();

            return ppBytes;
        }

        /// <summary>
        /// Gets a section block of the code base. This method is obsolete and should not be used.
        /// </summary>
        /// <param name="section">[in] The section from which to retrieve a block of the code base.</param>
        /// <param name="len">[in] The length of the block to be retrieved.</param>
        /// <param name="align">[in] The byte, relative to the beginning of the section, with which to align the first byte of the block. This is the position of the block within the section.</param>
        /// <param name="ppBytes">[out] A pointer to a location that receives the address of the retrieved block.</param>
        /// <remarks>
        /// Call GetSectionBlock only if you have special section requirements that are not handled by other methods.
        /// </remarks>
        [Obsolete]
        public HRESULT TryGetSectionBlock(IntPtr section, int len, int align, out IntPtr ppBytes)
        {
            /*HRESULT GetSectionBlock(
            [In] IntPtr section,
            [In] int len,
            [In] int align,
            [Out] out IntPtr ppBytes);*/
            return Raw.GetSectionBlock(section, len, align, out ppBytes);
        }

        #endregion
        #region TruncateSection

        /// <summary>
        /// Truncates the specified code section by the specified length. This method is obsolete and should not be used.
        /// </summary>
        /// <param name="section">[in] The section to truncate.</param>
        /// <param name="len">[in] The length, in bytes, by which to truncate the section.</param>
        /// <remarks>
        /// Call TruncateSection only if you have special section requirements that are not handled by other methods.
        /// </remarks>
        [Obsolete]
        public void TruncateSection(IntPtr section, int len)
        {
            TryTruncateSection(section, len).ThrowOnNotOK();
        }

        /// <summary>
        /// Truncates the specified code section by the specified length. This method is obsolete and should not be used.
        /// </summary>
        /// <param name="section">[in] The section to truncate.</param>
        /// <param name="len">[in] The length, in bytes, by which to truncate the section.</param>
        /// <remarks>
        /// Call TruncateSection only if you have special section requirements that are not handled by other methods.
        /// </remarks>
        [Obsolete]
        public HRESULT TryTruncateSection(IntPtr section, int len)
        {
            /*HRESULT TruncateSection(
            [In] IntPtr section,
            [In] int len);*/
            return Raw.TruncateSection(section, len);
        }

        #endregion
        #region GenerateCeeMemoryImage

        /// <summary>
        /// Generates an image in memory for the code base. This method is obsolete and should not be used.
        /// </summary>
        /// <returns>[out] A pointer to the generated image.</returns>
        [Obsolete]
        public IntPtr GenerateCeeMemoryImage()
        {
            IntPtr ppImage;
            TryGenerateCeeMemoryImage(out ppImage).ThrowOnNotOK();

            return ppImage;
        }

        /// <summary>
        /// Generates an image in memory for the code base. This method is obsolete and should not be used.
        /// </summary>
        /// <param name="ppImage">[out] A pointer to the generated image.</param>
        [Obsolete]
        public HRESULT TryGenerateCeeMemoryImage(out IntPtr ppImage)
        {
            /*HRESULT GenerateCeeMemoryImage(
            [Out] out IntPtr ppImage);*/
            return Raw.GenerateCeeMemoryImage(out ppImage);
        }

        #endregion
        #region ComputePointer

        /// <summary>
        /// Determines the buffer for the specified code section. This method is obsolete and should not be used.
        /// </summary>
        /// <param name="section">[in] The code section for which to return a buffer.</param>
        /// <param name="RVA">[in] The relative virtual address of the method for which to get a pointer.</param>
        /// <returns>[out] A pointer to the returned buffer.</returns>
        [Obsolete]
        public IntPtr ComputePointer(IntPtr section, int RVA)
        {
            IntPtr lpBuffer;
            TryComputePointer(section, RVA, out lpBuffer).ThrowOnNotOK();

            return lpBuffer;
        }

        /// <summary>
        /// Determines the buffer for the specified code section. This method is obsolete and should not be used.
        /// </summary>
        /// <param name="section">[in] The code section for which to return a buffer.</param>
        /// <param name="RVA">[in] The relative virtual address of the method for which to get a pointer.</param>
        /// <param name="lpBuffer">[out] A pointer to the returned buffer.</param>
        [Obsolete]
        public HRESULT TryComputePointer(IntPtr section, int RVA, out IntPtr lpBuffer)
        {
            /*HRESULT ComputePointer(
            [In] IntPtr section,
            [In] int RVA,
            [Out] out IntPtr lpBuffer);*/
            return Raw.ComputePointer(section, RVA, out lpBuffer);
        }

        #endregion
        #endregion
    }
}