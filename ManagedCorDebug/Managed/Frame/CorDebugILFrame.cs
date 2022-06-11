using System;
using System.Runtime.InteropServices;

namespace ManagedCorDebug
{
    public class CorDebugILFrame : CorDebugFrame
    {
        public CorDebugILFrame(ICorDebugILFrame raw) : base(raw)
        {
        }

        #region ICorDebugILFrame

        public new ICorDebugILFrame Raw => (ICorDebugILFrame) base.Raw;

        #region GetStackDepth

        public uint StackDepth
        {
            get
            {
                HRESULT hr;
                uint pDepth;

                if ((hr = TryGetStackDepth(out pDepth)) != HRESULT.S_OK)
                    Marshal.ThrowExceptionForHR((int) hr);

                return pDepth;
            }
        }

        public HRESULT TryGetStackDepth(out uint pDepth)
        {
            /*HRESULT GetStackDepth(out uint pDepth);*/
            return Raw.GetStackDepth(out pDepth);
        }

        #endregion
        #region GetIP

        public GetIPResult GetIP()
        {
            HRESULT hr;
            GetIPResult result;

            if ((hr = TryGetIP(out result)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return result;
        }

        public HRESULT TryGetIP(out GetIPResult result)
        {
            /*HRESULT GetIP(out uint pnOffset, out CorDebugMappingResult pMappingResult);*/
            uint pnOffset;
            CorDebugMappingResult pMappingResult;
            HRESULT hr = Raw.GetIP(out pnOffset, out pMappingResult);

            if (hr == HRESULT.S_OK)
                result = new GetIPResult(pnOffset, pMappingResult);
            else
                result = default(GetIPResult);

            return hr;
        }

        #endregion
        #region SetIP

        public void SetIP(uint nOffset)
        {
            HRESULT hr;

            if ((hr = TrySetIP(nOffset)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);
        }

        public HRESULT TrySetIP(uint nOffset)
        {
            /*HRESULT SetIP([In] uint nOffset);*/
            return Raw.SetIP(nOffset);
        }

        #endregion
        #region EnumerateLocalVariables

        public CorDebugValueEnum EnumerateLocalVariables()
        {
            HRESULT hr;
            CorDebugValueEnum ppValueEnumResult;

            if ((hr = TryEnumerateLocalVariables(out ppValueEnumResult)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return ppValueEnumResult;
        }

        public HRESULT TryEnumerateLocalVariables(out CorDebugValueEnum ppValueEnumResult)
        {
            /*HRESULT EnumerateLocalVariables([MarshalAs(UnmanagedType.Interface)] out ICorDebugValueEnum ppValueEnum);*/
            ICorDebugValueEnum ppValueEnum;
            HRESULT hr = Raw.EnumerateLocalVariables(out ppValueEnum);

            if (hr == HRESULT.S_OK)
                ppValueEnumResult = new CorDebugValueEnum(ppValueEnum);
            else
                ppValueEnumResult = default(CorDebugValueEnum);

            return hr;
        }

        #endregion
        #region GetLocalVariable

        public CorDebugValue GetLocalVariable(uint dwIndex)
        {
            HRESULT hr;
            CorDebugValue ppValueResult;

            if ((hr = TryGetLocalVariable(dwIndex, out ppValueResult)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return ppValueResult;
        }

        public HRESULT TryGetLocalVariable(uint dwIndex, out CorDebugValue ppValueResult)
        {
            /*HRESULT GetLocalVariable([In] uint dwIndex, [MarshalAs(UnmanagedType.Interface)] out ICorDebugValue ppValue);*/
            ICorDebugValue ppValue;
            HRESULT hr = Raw.GetLocalVariable(dwIndex, out ppValue);

            if (hr == HRESULT.S_OK)
                ppValueResult = CorDebugValue.New(ppValue);
            else
                ppValueResult = default(CorDebugValue);

            return hr;
        }

        #endregion
        #region EnumerateArguments

        public CorDebugValueEnum EnumerateArguments()
        {
            HRESULT hr;
            CorDebugValueEnum ppValueEnumResult;

            if ((hr = TryEnumerateArguments(out ppValueEnumResult)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return ppValueEnumResult;
        }

        public HRESULT TryEnumerateArguments(out CorDebugValueEnum ppValueEnumResult)
        {
            /*HRESULT EnumerateArguments([MarshalAs(UnmanagedType.Interface)] out ICorDebugValueEnum ppValueEnum);*/
            ICorDebugValueEnum ppValueEnum;
            HRESULT hr = Raw.EnumerateArguments(out ppValueEnum);

            if (hr == HRESULT.S_OK)
                ppValueEnumResult = new CorDebugValueEnum(ppValueEnum);
            else
                ppValueEnumResult = default(CorDebugValueEnum);

            return hr;
        }

        #endregion
        #region GetArgument

        public CorDebugValue GetArgument(uint dwIndex)
        {
            HRESULT hr;
            CorDebugValue ppValueResult;

            if ((hr = TryGetArgument(dwIndex, out ppValueResult)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return ppValueResult;
        }

        public HRESULT TryGetArgument(uint dwIndex, out CorDebugValue ppValueResult)
        {
            /*HRESULT GetArgument([In] uint dwIndex, [MarshalAs(UnmanagedType.Interface)] out ICorDebugValue ppValue);*/
            ICorDebugValue ppValue;
            HRESULT hr = Raw.GetArgument(dwIndex, out ppValue);

            if (hr == HRESULT.S_OK)
                ppValueResult = CorDebugValue.New(ppValue);
            else
                ppValueResult = default(CorDebugValue);

            return hr;
        }

        #endregion
        #region GetStackValue

        public CorDebugValue GetStackValue(uint dwIndex)
        {
            HRESULT hr;
            CorDebugValue ppValueResult;

            if ((hr = TryGetStackValue(dwIndex, out ppValueResult)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return ppValueResult;
        }

        public HRESULT TryGetStackValue(uint dwIndex, out CorDebugValue ppValueResult)
        {
            /*HRESULT GetStackValue([In] uint dwIndex, [MarshalAs(UnmanagedType.Interface)] out ICorDebugValue ppValue);*/
            ICorDebugValue ppValue;
            HRESULT hr = Raw.GetStackValue(dwIndex, out ppValue);

            if (hr == HRESULT.S_OK)
                ppValueResult = CorDebugValue.New(ppValue);
            else
                ppValueResult = default(CorDebugValue);

            return hr;
        }

        #endregion
        #region CanSetIP

        public void CanSetIP(uint nOffset)
        {
            HRESULT hr;

            if ((hr = TryCanSetIP(nOffset)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);
        }

        public HRESULT TryCanSetIP(uint nOffset)
        {
            /*HRESULT CanSetIP([In] uint nOffset);*/
            return Raw.CanSetIP(nOffset);
        }

        #endregion
        #endregion
        #region ICorDebugILFrame2

        public ICorDebugILFrame2 Raw2 => (ICorDebugILFrame2) Raw;

        #region RemapFunction

        public void RemapFunction(uint newILOffset)
        {
            HRESULT hr;

            if ((hr = TryRemapFunction(newILOffset)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);
        }

        public HRESULT TryRemapFunction(uint newILOffset)
        {
            /*HRESULT RemapFunction([In] uint newILOffset);*/
            return Raw2.RemapFunction(newILOffset);
        }

        #endregion
        #region EnumerateTypeParameters

        public CorDebugTypeEnum EnumerateTypeParameters()
        {
            HRESULT hr;
            CorDebugTypeEnum ppTyParEnumResult;

            if ((hr = TryEnumerateTypeParameters(out ppTyParEnumResult)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return ppTyParEnumResult;
        }

        public HRESULT TryEnumerateTypeParameters(out CorDebugTypeEnum ppTyParEnumResult)
        {
            /*HRESULT EnumerateTypeParameters([MarshalAs(UnmanagedType.Interface)] out ICorDebugTypeEnum ppTyParEnum);*/
            ICorDebugTypeEnum ppTyParEnum;
            HRESULT hr = Raw2.EnumerateTypeParameters(out ppTyParEnum);

            if (hr == HRESULT.S_OK)
                ppTyParEnumResult = new CorDebugTypeEnum(ppTyParEnum);
            else
                ppTyParEnumResult = default(CorDebugTypeEnum);

            return hr;
        }

        #endregion
        #endregion
        #region ICorDebugILFrame3

        public ICorDebugILFrame3 Raw3 => (ICorDebugILFrame3) Raw;

        #region GetReturnValueForILOffset

        public CorDebugValue GetReturnValueForILOffset(uint ilOffset)
        {
            HRESULT hr;
            CorDebugValue ppReturnValueResult;

            if ((hr = TryGetReturnValueForILOffset(ilOffset, out ppReturnValueResult)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return ppReturnValueResult;
        }

        public HRESULT TryGetReturnValueForILOffset(uint ilOffset, out CorDebugValue ppReturnValueResult)
        {
            /*HRESULT GetReturnValueForILOffset(uint ilOffset,
            [MarshalAs(UnmanagedType.Interface)] out ICorDebugValue ppReturnValue);*/
            ICorDebugValue ppReturnValue;
            HRESULT hr = Raw3.GetReturnValueForILOffset(ilOffset, out ppReturnValue);

            if (hr == HRESULT.S_OK)
                ppReturnValueResult = CorDebugValue.New(ppReturnValue);
            else
                ppReturnValueResult = default(CorDebugValue);

            return hr;
        }

        #endregion
        #endregion
        #region ICorDebugILFrame4

        public ICorDebugILFrame4 Raw4 => (ICorDebugILFrame4) Raw;

        #region EnumerateLocalVariablesEx

        public CorDebugValueEnum EnumerateLocalVariablesEx(ILCodeKind flags)
        {
            HRESULT hr;
            CorDebugValueEnum ppValueEnumResult;

            if ((hr = TryEnumerateLocalVariablesEx(flags, out ppValueEnumResult)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return ppValueEnumResult;
        }

        public HRESULT TryEnumerateLocalVariablesEx(ILCodeKind flags, out CorDebugValueEnum ppValueEnumResult)
        {
            /*HRESULT EnumerateLocalVariablesEx([In] ILCodeKind flags,
            [MarshalAs(UnmanagedType.Interface)] out ICorDebugValueEnum ppValueEnum);*/
            ICorDebugValueEnum ppValueEnum;
            HRESULT hr = Raw4.EnumerateLocalVariablesEx(flags, out ppValueEnum);

            if (hr == HRESULT.S_OK)
                ppValueEnumResult = new CorDebugValueEnum(ppValueEnum);
            else
                ppValueEnumResult = default(CorDebugValueEnum);

            return hr;
        }

        #endregion
        #region GetLocalVariableEx

        public CorDebugValue GetLocalVariableEx(ILCodeKind flags, uint dwIndex)
        {
            HRESULT hr;
            CorDebugValue ppValueResult;

            if ((hr = TryGetLocalVariableEx(flags, dwIndex, out ppValueResult)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return ppValueResult;
        }

        public HRESULT TryGetLocalVariableEx(ILCodeKind flags, uint dwIndex, out CorDebugValue ppValueResult)
        {
            /*HRESULT GetLocalVariableEx(
            [In] ILCodeKind flags,
            [In] uint dwIndex,
            [MarshalAs(UnmanagedType.Interface)] out ICorDebugValue ppValue);*/
            ICorDebugValue ppValue;
            HRESULT hr = Raw4.GetLocalVariableEx(flags, dwIndex, out ppValue);

            if (hr == HRESULT.S_OK)
                ppValueResult = CorDebugValue.New(ppValue);
            else
                ppValueResult = default(CorDebugValue);

            return hr;
        }

        #endregion
        #region GetCodeEx

        public CorDebugCode GetCodeEx(ILCodeKind flags)
        {
            HRESULT hr;
            CorDebugCode ppCodeResult;

            if ((hr = TryGetCodeEx(flags, out ppCodeResult)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return ppCodeResult;
        }

        public HRESULT TryGetCodeEx(ILCodeKind flags, out CorDebugCode ppCodeResult)
        {
            /*HRESULT GetCodeEx(
            [In] ILCodeKind flags,
            [MarshalAs(UnmanagedType.Interface)] out ICorDebugCode ppCode);*/
            ICorDebugCode ppCode;
            HRESULT hr = Raw4.GetCodeEx(flags, out ppCode);

            if (hr == HRESULT.S_OK)
                ppCodeResult = new CorDebugCode(ppCode);
            else
                ppCodeResult = default(CorDebugCode);

            return hr;
        }

        #endregion
        #endregion
    }
}