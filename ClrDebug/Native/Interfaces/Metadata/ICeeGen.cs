using System;
using System.Runtime.InteropServices;
using System.Text;

namespace ClrDebug
{
    /// <summary>
    /// Provides methods for dynamic code compilation. This interface is obsolete and should not be used.
    /// </summary>
    [Guid("7ED1BDFF-8E36-11d2-9C56-00A0C9B7CC45")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [ComImport]
    public interface ICeeGen
    {
        /// <summary>
        /// Emits the specified string into the code base. This method is obsolete and should not be used.
        /// </summary>
        /// <param name="lpString">[in] The string to emit.</param>
        /// <param name="RVA">[out] The relative virtual address of the emitted string.</param>
        [Obsolete]
        [PreserveSig]
        HRESULT EmitString(
            [In, MarshalAs(UnmanagedType.LPWStr)] string lpString,
            [Out] out int RVA);

        /// <summary>
        /// Gets the string stored at the specified relative virtual address. This method is obsolete and should not be used.
        /// </summary>
        /// <param name="RVA">[in] The relative virtual address of the string to return.</param>
        /// <param name="lpString">[out] The returned string.</param>
        [Obsolete]
        [PreserveSig]
        HRESULT GetString(
            [In] long RVA,
            [Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder lpString);

        /// <summary>
        /// Creates a buffer of the specified size for a method, and gets the relative virtual address of the method. This method is obsolete and should not be used.
        /// </summary>
        /// <param name="cchBuffer">[in] The length of the buffer to create.</param>
        /// <param name="lpBuffer">[out] The returned buffer.</param>
        /// <param name="RVA">[out] The relative virtual address of the method.</param>
        [Obsolete]
        [PreserveSig]
        HRESULT AllocateMethodBuffer(
            [In] int cchBuffer,
            [Out] out IntPtr lpBuffer,
            [Out] out int RVA);

        /// <summary>
        /// Gets a buffer of the appropriate size for the method at the specified relative virtual address. This method is obsolete and should not be used.
        /// </summary>
        /// <param name="RVA">[in] The relative virtual address of the method for which to return a buffer.</param>
        /// <param name="lpBuffer">[out] A pointer to the returned buffer.</param>
        [Obsolete]
        [PreserveSig]
        HRESULT GetMethodBuffer(
            [In] int RVA,
            [Out] out IntPtr lpBuffer);

        /// <summary>
        /// Gets the interface referenced by the specified token. This method is obsolete and should not be used.
        /// </summary>
        /// <param name="pIMapToken">[in, out] The metadata token for the interface to be returned.</param>
        [Obsolete]
        [PreserveSig]
        HRESULT GetIMapTokenIface(
            [Out, MarshalAs(UnmanagedType.Interface)] out object pIMapToken);

        /// <summary>
        /// Generates a code-base file that contains the code base currently loaded into this <see cref="ICeeGen"/> interface.<para/>
        /// This method is obsolete and should not be used.
        /// </summary>
        [Obsolete]
        [PreserveSig]
        HRESULT GenerateCeeFile();

        /// <summary>
        /// Gets the section of the intermediate language code base referenced by the specified handle. This method is obsolete and should not be used.
        /// </summary>
        /// <param name="section">[in] The handle to the section to get.</param>
        [Obsolete]
        [PreserveSig]
        HRESULT GetIlSection(
            [In] IntPtr section);

        /// <summary>
        /// Gets a string representation of the code section referenced by the specified handle. This method is obsolete and should not be used.
        /// </summary>
        /// <param name="section">[in, out] The handle to the code section.</param>
        [Obsolete]
        [PreserveSig]
        HRESULT GetStringSection(
            [In, Out] ref IntPtr section);

        /// <summary>
        /// Adds a .reloc instruction to the code base. This method is obsolete and should not be used.
        /// </summary>
        /// <param name="section">[in] The section of in-memory code to which to add a .reloc instruction.</param>
        /// <param name="offset">[in] The offset of the section.</param>
        /// <param name="relativeTo">[in] The section to which offset refers.</param>
        /// <param name="relocType">[in] One of the <see cref="CeeSectionRelocType"/> values, indicating the kind of .reloc instruction to add.</param>
        [Obsolete]
        [PreserveSig]
        HRESULT AddSectionReloc(
            [In] IntPtr section,
            [In] int offset,
            [In] IntPtr relativeTo,
            [In] CeeSectionRelocType relocType);

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
        [PreserveSig]
        HRESULT GetSectionCreate(
            [In, MarshalAs(UnmanagedType.LPWStr)] string name,
            [In] int flags,
            [Out] out IntPtr section);

        /// <summary>
        /// Gets the length of the specified section. This method is obsolete and should not be used.
        /// </summary>
        /// <param name="section">[in] The data section whose length will be retrieved.</param>
        /// <param name="dataLen">[out] The returned length of the specified section.</param>
        /// <remarks>
        /// Call GetSectionDataLen only if you have special section requirements that are not handled by other methods.
        /// </remarks>
        [Obsolete]
        [PreserveSig]
        HRESULT GetSectionDataLen(
            [In] IntPtr section,
            [Out] out int dataLen);

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
        [PreserveSig]
        HRESULT GetSectionBlock(
            [In] IntPtr section,
            [In] int len,
            [In] int align,
            [Out] out IntPtr ppBytes);

        /// <summary>
        /// Truncates the specified code section by the specified length. This method is obsolete and should not be used.
        /// </summary>
        /// <param name="section">[in] The section to truncate.</param>
        /// <param name="len">[in] The length, in bytes, by which to truncate the section.</param>
        /// <remarks>
        /// Call TruncateSection only if you have special section requirements that are not handled by other methods.
        /// </remarks>
        [Obsolete]
        [PreserveSig]
        HRESULT TruncateSection(
            [In] IntPtr section,
            [In] int len);

        /// <summary>
        /// Generates an image in memory for the code base. This method is obsolete and should not be used.
        /// </summary>
        /// <param name="ppImage">[out] A pointer to the generated image.</param>
        [Obsolete]
        [PreserveSig]
        HRESULT GenerateCeeMemoryImage(
            [Out] out IntPtr ppImage);

        /// <summary>
        /// Determines the buffer for the specified code section. This method is obsolete and should not be used.
        /// </summary>
        /// <param name="section">[in] The code section for which to return a buffer.</param>
        /// <param name="RVA">[in] The relative virtual address of the method for which to get a pointer.</param>
        /// <param name="lpBuffer">[out] A pointer to the returned buffer.</param>
        [Obsolete]
        [PreserveSig]
        HRESULT ComputePointer(
            [In] IntPtr section,
            [In] int RVA,
            [Out] out IntPtr lpBuffer);
    }
}
