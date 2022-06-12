using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace ManagedCorDebug
{
    /// <summary>
    /// Provides methods that test for child and parent frame relationships.
    /// </summary>
    /// <remarks>
    /// This interface logically extends the "ICorDebugNativeFrame" interface.
    /// </remarks>
    [Guid("35389FF1-3684-4C55-A2EE-210F26C60E5E")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [ComImport]
    public interface ICorDebugNativeFrame2
    {
        /// <summary>
        /// Determines whether the current frame is a child frame.
        /// </summary>
        /// <param name="pIsChild">[out] A Boolean value that specifies whether the current frame is a child frame.</param>
        /// <returns>
        /// This method returns the following specific HRESULTs as well as HRESULT errors that indicate method failure.
        /// 
        /// | HRESULT      | Description                                 |
        /// | ------------ | ------------------------------------------- |
        /// | S_OK         | The child status was successfully returned. |
        /// | E_FAIL       | The child status could not be returned.     |
        /// | E_INVALIDARG | pIsChild is null.                           |
        /// </returns>
        /// <remarks>
        /// The IsChild method returns true if the frame object on which you call the method is a child of another frame. If
        /// this is the case, use the <see cref="IsMatchingParentFrame"/> method to check whether a frame is its parent.
        /// </remarks>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT IsChild(out int pIsChild);

        /// <summary>
        /// Determines whether the specified frame is the parent of the current frame.
        /// </summary>
        /// <param name="pPotentialParentFrame">[in] A pointer to the frame object that you want to evaluate for parent status.</param>
        /// <param name="pIsParent">[out] true if pPotentialParentFrame is the current frame’s parent; otherwise, false.</param>
        /// <returns>
        /// This method returns the following specific HRESULTs as well as HRESULT errors that indicate method failure.
        /// 
        /// | HRESULT      | Description                                  |
        /// | ------------ | -------------------------------------------- |
        /// | S_OK         | The parent status was successfully returned. |
        /// | E_FAIL       | The parent status could not be returned.     |
        /// | E_INVALIDARG | pPotentialParentFrame or pIsParent is null.  |
        /// </returns>
        /// <remarks>
        /// IsMatchingParentFrame returns true if the frame object you pass to the method is the parent of the frame object
        /// on which the method was called. If you call the method on a frame that is not a child of the specified frame, it
        /// returns an error.
        /// </remarks>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT IsMatchingParentFrame([MarshalAs(UnmanagedType.Interface), In]
            ICorDebugNativeFrame2 pPotentialParentFrame, out int pIsParent);

        /// <summary>
        /// Returns the cumulative size of the parameters on the stack on x86 operating systems.
        /// </summary>
        /// <param name="pSize">[out] A pointer to the cumulative size of the parameters on the stack.</param>
        /// <returns>
        /// This method returns the following specific HRESULTs as well as HRESULT errors that indicate method failure.
        /// 
        /// | HRESULT      | Description                                             |
        /// | ------------ | ------------------------------------------------------- |
        /// | S_OK         | The stack size was successfully returned.               |
        /// | S_FALSE      | GetStackParameterSize was called on a non-x86 platform. |
        /// | E_FAIL       | The size of the parameters could not be returned.       |
        /// | E_INVALIDARG | pSize Is null.                                          |
        /// </returns>
        /// <remarks>
        /// The <see cref="ICorDebugStackWalk"/> methods do not adjust the stack pointer for parameters that are pushed on
        /// the stack. Instead, you can use the value returned by GetStackParameterSize to adjust the stack pointer to seed
        /// a native unwinder, which does adjust for the parameters.
        /// </remarks>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT GetStackParameterSize(out int pSize);
    }
}