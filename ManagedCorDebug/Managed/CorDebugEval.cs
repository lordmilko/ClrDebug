using System;
using System.Reflection;
using System.Runtime.InteropServices;

namespace ManagedCorDebug
{
    public class CorDebugEval : ComObject<ICorDebugEval>
    {
        public CorDebugEval(ICorDebugEval raw) : base(raw)
        {
        }

        #region ICorDebugEval
        #region IsActive

        public int IsActive
        {
            get
            {
                HRESULT hr;
                int pbActive;

                if ((hr = TryIsActive(out pbActive)) != HRESULT.S_OK)
                    Marshal.ThrowExceptionForHR((int) hr);

                return pbActive;
            }
        }

        public HRESULT TryIsActive(out int pbActive)
        {
            /*HRESULT IsActive(out int pbActive);*/
            return Raw.IsActive(out pbActive);
        }

        #endregion
        #region GetResult

        public CorDebugValue Result
        {
            get
            {
                HRESULT hr;
                CorDebugValue ppResultResult;

                if ((hr = TryGetResult(out ppResultResult)) != HRESULT.S_OK)
                    Marshal.ThrowExceptionForHR((int) hr);

                return ppResultResult;
            }
        }

        public HRESULT TryGetResult(out CorDebugValue ppResultResult)
        {
            /*HRESULT GetResult([MarshalAs(UnmanagedType.Interface)] out ICorDebugValue ppResult);*/
            ICorDebugValue ppResult;
            HRESULT hr = Raw.GetResult(out ppResult);

            if (hr == HRESULT.S_OK)
                ppResultResult = CorDebugValue.New(ppResult);
            else
                ppResultResult = default(CorDebugValue);

            return hr;
        }

        #endregion
        #region GetThread

        public CorDebugThread Thread
        {
            get
            {
                HRESULT hr;
                CorDebugThread ppThreadResult;

                if ((hr = TryGetThread(out ppThreadResult)) != HRESULT.S_OK)
                    Marshal.ThrowExceptionForHR((int) hr);

                return ppThreadResult;
            }
        }

        public HRESULT TryGetThread(out CorDebugThread ppThreadResult)
        {
            /*HRESULT GetThread([MarshalAs(UnmanagedType.Interface)] out ICorDebugThread ppThread);*/
            ICorDebugThread ppThread;
            HRESULT hr = Raw.GetThread(out ppThread);

            if (hr == HRESULT.S_OK)
                ppThreadResult = new CorDebugThread(ppThread);
            else
                ppThreadResult = default(CorDebugThread);

            return hr;
        }

        #endregion
        #region CallFunction

        [Obsolete]
        public void CallFunction(ICorDebugFunction pFunction, uint nArgs, ICorDebugValue ppArgs)
        {
            HRESULT hr;

            if ((hr = TryCallFunction(pFunction, nArgs, ppArgs)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);
        }

        [Obsolete]
        public HRESULT TryCallFunction(ICorDebugFunction pFunction, uint nArgs, ICorDebugValue ppArgs)
        {
            /*HRESULT CallFunction([MarshalAs(UnmanagedType.Interface), In]
            ICorDebugFunction pFunction, [In] uint nArgs, [MarshalAs(UnmanagedType.Interface), In]
            ref ICorDebugValue ppArgs);*/
            return Raw.CallFunction(pFunction, nArgs, ref ppArgs);
        }

        #endregion
        #region NewObject

        [Obsolete]
        public void NewObject(ICorDebugFunction pConstructor, uint nArgs, ICorDebugValue ppArgs)
        {
            HRESULT hr;

            if ((hr = TryNewObject(pConstructor, nArgs, ppArgs)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);
        }

        [Obsolete]
        public HRESULT TryNewObject(ICorDebugFunction pConstructor, uint nArgs, ICorDebugValue ppArgs)
        {
            /*HRESULT NewObject([MarshalAs(UnmanagedType.Interface), In]
            ICorDebugFunction pConstructor, [In] uint nArgs, [MarshalAs(UnmanagedType.Interface), In]
            ref ICorDebugValue ppArgs);*/
            return Raw.NewObject(pConstructor, nArgs, ref ppArgs);
        }

        #endregion
        #region NewObjectNoConstructor

        [Obsolete]
        public void NewObjectNoConstructor(ICorDebugClass pClass)
        {
            HRESULT hr;

            if ((hr = TryNewObjectNoConstructor(pClass)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);
        }

        [Obsolete]
        public HRESULT TryNewObjectNoConstructor(ICorDebugClass pClass)
        {
            /*HRESULT NewObjectNoConstructor([MarshalAs(UnmanagedType.Interface), In]
            ICorDebugClass pClass);*/
            return Raw.NewObjectNoConstructor(pClass);
        }

        #endregion
        #region NewString

        public void NewString(string @string)
        {
            HRESULT hr;

            if ((hr = TryNewString(@string)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);
        }

        public HRESULT TryNewString(string @string)
        {
            /*HRESULT NewString([MarshalAs(UnmanagedType.LPWStr), In] string @string);*/
            return Raw.NewString(@string);
        }

        #endregion
        #region NewArray

        [Obsolete]
        public void NewArray(CorElementType elementType, ICorDebugClass pElementClass, uint rank, uint dims, uint lowBounds)
        {
            HRESULT hr;

            if ((hr = TryNewArray(elementType, pElementClass, rank, dims, lowBounds)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);
        }

        [Obsolete]
        public HRESULT TryNewArray(CorElementType elementType, ICorDebugClass pElementClass, uint rank, uint dims, uint lowBounds)
        {
            /*HRESULT NewArray(
            [In] CorElementType elementType,
            [MarshalAs(UnmanagedType.Interface), In]
            ICorDebugClass pElementClass,
            [In] uint rank,
            [In] ref uint dims,
            [In] ref uint lowBounds);*/
            return Raw.NewArray(elementType, pElementClass, rank, ref dims, ref lowBounds);
        }

        #endregion
        #region Abort

        public void Abort()
        {
            HRESULT hr;

            if ((hr = TryAbort()) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);
        }

        public HRESULT TryAbort()
        {
            /*HRESULT Abort();*/
            return Raw.Abort();
        }

        #endregion
        #region CreateValue

        [Obsolete]
        public CorDebugValue CreateValue(uint elementType, ICorDebugClass pElementClass)
        {
            HRESULT hr;
            CorDebugValue ppValueResult;

            if ((hr = TryCreateValue(elementType, pElementClass, out ppValueResult)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return ppValueResult;
        }

        [Obsolete]
        public HRESULT TryCreateValue(uint elementType, ICorDebugClass pElementClass, out CorDebugValue ppValueResult)
        {
            /*HRESULT CreateValue([In] uint elementType, [MarshalAs(UnmanagedType.Interface), In]
            ICorDebugClass pElementClass, [MarshalAs(UnmanagedType.Interface)] out ICorDebugValue ppValue);*/
            ICorDebugValue ppValue;
            HRESULT hr = Raw.CreateValue(elementType, pElementClass, out ppValue);

            if (hr == HRESULT.S_OK)
                ppValueResult = CorDebugValue.New(ppValue);
            else
                ppValueResult = default(CorDebugValue);

            return hr;
        }

        #endregion
        #endregion
        #region ICorDebugEval2

        public ICorDebugEval2 Raw2 => (ICorDebugEval2) Raw;

        #region CallParameterizedFunction

        public void CallParameterizedFunction(ICorDebugFunction pFunction, uint nTypeArgs, ICorDebugType ppTypeArgs, uint nArgs, ICorDebugValue ppArgs)
        {
            HRESULT hr;

            if ((hr = TryCallParameterizedFunction(pFunction, nTypeArgs, ppTypeArgs, nArgs, ppArgs)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);
        }

        public HRESULT TryCallParameterizedFunction(ICorDebugFunction pFunction, uint nTypeArgs, ICorDebugType ppTypeArgs, uint nArgs, ICorDebugValue ppArgs)
        {
            /*HRESULT CallParameterizedFunction(
            [MarshalAs(UnmanagedType.Interface), In]
            ICorDebugFunction pFunction,
            [In] uint nTypeArgs,
            [MarshalAs(UnmanagedType.Interface), In]
            ref ICorDebugType ppTypeArgs,
            [In] uint nArgs,
            [MarshalAs(UnmanagedType.Interface), In]
            ref ICorDebugValue ppArgs);*/
            return Raw2.CallParameterizedFunction(pFunction, nTypeArgs, ref ppTypeArgs, nArgs, ref ppArgs);
        }

        #endregion
        #region CreateValueForType

        public CorDebugValue CreateValueForType(ICorDebugType pType)
        {
            HRESULT hr;
            CorDebugValue ppValueResult;

            if ((hr = TryCreateValueForType(pType, out ppValueResult)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return ppValueResult;
        }

        public HRESULT TryCreateValueForType(ICorDebugType pType, out CorDebugValue ppValueResult)
        {
            /*HRESULT CreateValueForType([MarshalAs(UnmanagedType.Interface), In]
            ICorDebugType pType, [MarshalAs(UnmanagedType.Interface)] out ICorDebugValue ppValue);*/
            ICorDebugValue ppValue;
            HRESULT hr = Raw2.CreateValueForType(pType, out ppValue);

            if (hr == HRESULT.S_OK)
                ppValueResult = CorDebugValue.New(ppValue);
            else
                ppValueResult = default(CorDebugValue);

            return hr;
        }

        #endregion
        #region NewParameterizedObject

        public void NewParameterizedObject(ICorDebugFunction pConstructor, uint nTypeArgs, ICorDebugType ppTypeArgs, uint nArgs, ICorDebugValue ppArgs)
        {
            HRESULT hr;

            if ((hr = TryNewParameterizedObject(pConstructor, nTypeArgs, ppTypeArgs, nArgs, ppArgs)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);
        }

        public HRESULT TryNewParameterizedObject(ICorDebugFunction pConstructor, uint nTypeArgs, ICorDebugType ppTypeArgs, uint nArgs, ICorDebugValue ppArgs)
        {
            /*HRESULT NewParameterizedObject(
            [MarshalAs(UnmanagedType.Interface), In]
            ICorDebugFunction pConstructor,
            [In] uint nTypeArgs,
            [MarshalAs(UnmanagedType.Interface), In]
            ref ICorDebugType ppTypeArgs,
            [In] uint nArgs,
            [MarshalAs(UnmanagedType.Interface), In]
            ref ICorDebugValue ppArgs);*/
            return Raw2.NewParameterizedObject(pConstructor, nTypeArgs, ref ppTypeArgs, nArgs, ref ppArgs);
        }

        #endregion
        #region NewParameterizedObjectNoConstructor

        public void NewParameterizedObjectNoConstructor(ICorDebugClass pClass, uint nTypeArgs, ICorDebugType ppTypeArgs)
        {
            HRESULT hr;

            if ((hr = TryNewParameterizedObjectNoConstructor(pClass, nTypeArgs, ppTypeArgs)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);
        }

        public HRESULT TryNewParameterizedObjectNoConstructor(ICorDebugClass pClass, uint nTypeArgs, ICorDebugType ppTypeArgs)
        {
            /*HRESULT NewParameterizedObjectNoConstructor(
            [MarshalAs(UnmanagedType.Interface), In]
            ICorDebugClass pClass,
            [In] uint nTypeArgs,
            [MarshalAs(UnmanagedType.Interface), In]
            ref ICorDebugType ppTypeArgs);*/
            return Raw2.NewParameterizedObjectNoConstructor(pClass, nTypeArgs, ref ppTypeArgs);
        }

        #endregion
        #region NewParameterizedArray

        public void NewParameterizedArray(ICorDebugType pElementType, uint rank, uint dims, uint lowBounds)
        {
            HRESULT hr;

            if ((hr = TryNewParameterizedArray(pElementType, rank, dims, lowBounds)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);
        }

        public HRESULT TryNewParameterizedArray(ICorDebugType pElementType, uint rank, uint dims, uint lowBounds)
        {
            /*HRESULT NewParameterizedArray(
            [MarshalAs(UnmanagedType.Interface), In]
            ICorDebugType pElementType,
            [In] uint rank,
            [In] ref uint dims,
            [In] ref uint lowBounds);*/
            return Raw2.NewParameterizedArray(pElementType, rank, ref dims, ref lowBounds);
        }

        #endregion
        #region NewStringWithLength

        public void NewStringWithLength(string @string, uint uiLength)
        {
            HRESULT hr;

            if ((hr = TryNewStringWithLength(@string, uiLength)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);
        }

        public HRESULT TryNewStringWithLength(string @string, uint uiLength)
        {
            /*HRESULT NewStringWithLength([MarshalAs(UnmanagedType.LPWStr), In] string @string, [In] uint uiLength);*/
            return Raw2.NewStringWithLength(@string, uiLength);
        }

        #endregion
        #region RudeAbort

        public void RudeAbort()
        {
            HRESULT hr;

            if ((hr = TryRudeAbort()) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);
        }

        public HRESULT TryRudeAbort()
        {
            /*HRESULT RudeAbort();*/
            return Raw2.RudeAbort();
        }

        #endregion
        #endregion
    }
}