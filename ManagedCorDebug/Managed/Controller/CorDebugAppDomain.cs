using System;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;

namespace ManagedCorDebug
{
    public class CorDebugAppDomain : CorDebugController
    {
        public CorDebugAppDomain(ICorDebugAppDomain raw) : base(raw)
        {
        }

        #region ICorDebugAppDomain

        public new ICorDebugAppDomain Raw => (ICorDebugAppDomain) base.Raw;

        #region GetProcess

        public CorDebugProcess Process
        {
            get
            {
                HRESULT hr;
                CorDebugProcess ppProcessResult;

                if ((hr = TryGetProcess(out ppProcessResult)) != HRESULT.S_OK)
                    Marshal.ThrowExceptionForHR((int) hr);

                return ppProcessResult;
            }
        }

        public HRESULT TryGetProcess(out CorDebugProcess ppProcessResult)
        {
            /*HRESULT GetProcess([MarshalAs(UnmanagedType.Interface)] out ICorDebugProcess ppProcess);*/
            ICorDebugProcess ppProcess;
            HRESULT hr = Raw.GetProcess(out ppProcess);

            if (hr == HRESULT.S_OK)
                ppProcessResult = new CorDebugProcess(ppProcess);
            else
                ppProcessResult = default(CorDebugProcess);

            return hr;
        }

        #endregion
        #region IsAttached

        public int IsAttached
        {
            get
            {
                HRESULT hr;
                int pbAttached;

                if ((hr = TryIsAttached(out pbAttached)) != HRESULT.S_OK)
                    Marshal.ThrowExceptionForHR((int) hr);

                return pbAttached;
            }
        }

        public HRESULT TryIsAttached(out int pbAttached)
        {
            /*HRESULT IsAttached(out int pbAttached);*/
            return Raw.IsAttached(out pbAttached);
        }

        #endregion
        #region GetObject

        public CorDebugValue Object
        {
            get
            {
                HRESULT hr;
                CorDebugValue ppObjectResult;

                if ((hr = TryGetObject(out ppObjectResult)) != HRESULT.S_OK)
                    Marshal.ThrowExceptionForHR((int) hr);

                return ppObjectResult;
            }
        }

        public HRESULT TryGetObject(out CorDebugValue ppObjectResult)
        {
            /*HRESULT GetObject([MarshalAs(UnmanagedType.Interface)] out ICorDebugValue ppObject);*/
            ICorDebugValue ppObject;
            HRESULT hr = Raw.GetObject(out ppObject);

            if (hr == HRESULT.S_OK)
                ppObjectResult = CorDebugValue.New(ppObject);
            else
                ppObjectResult = default(CorDebugValue);

            return hr;
        }

        #endregion
        #region GetID

        public uint Id
        {
            get
            {
                HRESULT hr;
                uint pId;

                if ((hr = TryGetID(out pId)) != HRESULT.S_OK)
                    Marshal.ThrowExceptionForHR((int) hr);

                return pId;
            }
        }

        public HRESULT TryGetID(out uint pId)
        {
            /*HRESULT GetID(out uint pId);*/
            return Raw.GetID(out pId);
        }

        #endregion
        #region EnumerateAssemblies

        public CorDebugAssemblyEnum EnumerateAssemblies()
        {
            HRESULT hr;
            CorDebugAssemblyEnum ppAssembliesResult;

            if ((hr = TryEnumerateAssemblies(out ppAssembliesResult)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return ppAssembliesResult;
        }

        public HRESULT TryEnumerateAssemblies(out CorDebugAssemblyEnum ppAssembliesResult)
        {
            /*HRESULT EnumerateAssemblies([MarshalAs(UnmanagedType.Interface)] out ICorDebugAssemblyEnum ppAssemblies);*/
            ICorDebugAssemblyEnum ppAssemblies;
            HRESULT hr = Raw.EnumerateAssemblies(out ppAssemblies);

            if (hr == HRESULT.S_OK)
                ppAssembliesResult = new CorDebugAssemblyEnum(ppAssemblies);
            else
                ppAssembliesResult = default(CorDebugAssemblyEnum);

            return hr;
        }

        #endregion
        #region GetModuleFromMetaDataInterface

        public CorDebugModule GetModuleFromMetaDataInterface(object pIMetaData)
        {
            HRESULT hr;
            CorDebugModule ppModuleResult;

            if ((hr = TryGetModuleFromMetaDataInterface(pIMetaData, out ppModuleResult)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return ppModuleResult;
        }

        public HRESULT TryGetModuleFromMetaDataInterface(object pIMetaData, out CorDebugModule ppModuleResult)
        {
            /*HRESULT GetModuleFromMetaDataInterface([MarshalAs(UnmanagedType.IUnknown), In]
            object pIMetaData, [MarshalAs(UnmanagedType.Interface)] out ICorDebugModule ppModule);*/
            ICorDebugModule ppModule;
            HRESULT hr = Raw.GetModuleFromMetaDataInterface(pIMetaData, out ppModule);

            if (hr == HRESULT.S_OK)
                ppModuleResult = new CorDebugModule(ppModule);
            else
                ppModuleResult = default(CorDebugModule);

            return hr;
        }

        #endregion
        #region EnumerateBreakpoints

        public CorDebugBreakpointEnum EnumerateBreakpoints()
        {
            HRESULT hr;
            CorDebugBreakpointEnum ppBreakpointsResult;

            if ((hr = TryEnumerateBreakpoints(out ppBreakpointsResult)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return ppBreakpointsResult;
        }

        public HRESULT TryEnumerateBreakpoints(out CorDebugBreakpointEnum ppBreakpointsResult)
        {
            /*HRESULT EnumerateBreakpoints([MarshalAs(UnmanagedType.Interface)] out ICorDebugBreakpointEnum ppBreakpoints);*/
            ICorDebugBreakpointEnum ppBreakpoints;
            HRESULT hr = Raw.EnumerateBreakpoints(out ppBreakpoints);

            if (hr == HRESULT.S_OK)
                ppBreakpointsResult = new CorDebugBreakpointEnum(ppBreakpoints);
            else
                ppBreakpointsResult = default(CorDebugBreakpointEnum);

            return hr;
        }

        #endregion
        #region EnumerateSteppers

        public CorDebugStepperEnum EnumerateSteppers()
        {
            HRESULT hr;
            CorDebugStepperEnum ppSteppersResult;

            if ((hr = TryEnumerateSteppers(out ppSteppersResult)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return ppSteppersResult;
        }

        public HRESULT TryEnumerateSteppers(out CorDebugStepperEnum ppSteppersResult)
        {
            /*HRESULT EnumerateSteppers([MarshalAs(UnmanagedType.Interface)] out ICorDebugStepperEnum ppSteppers);*/
            ICorDebugStepperEnum ppSteppers;
            HRESULT hr = Raw.EnumerateSteppers(out ppSteppers);

            if (hr == HRESULT.S_OK)
                ppSteppersResult = new CorDebugStepperEnum(ppSteppers);
            else
                ppSteppersResult = default(CorDebugStepperEnum);

            return hr;
        }

        #endregion
        #region GetName

        public string GetName()
        {
            HRESULT hr;
            string szNameResult;

            if ((hr = TryGetName(out szNameResult)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return szNameResult;
        }

        public HRESULT TryGetName(out string szNameResult)
        {
            /*HRESULT GetName([In] uint cchName, out uint pcchName, [Out] StringBuilder szName);*/
            uint cchName = 0;
            uint pcchName;
            StringBuilder szName = null;
            HRESULT hr = Raw.GetName(cchName, out pcchName, szName);

            if (hr != HRESULT.S_FALSE)
                goto fail;

            cchName = pcchName;
            szName = new StringBuilder((int) pcchName);
            hr = Raw.GetName(cchName, out pcchName, szName);

            if (hr == HRESULT.S_OK)
            {
                szNameResult = szName.ToString();

                return hr;
            }

            fail:
            szNameResult = default(string);

            return hr;
        }

        #endregion
        #region Attach

        public void Attach()
        {
            HRESULT hr;

            if ((hr = TryAttach()) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);
        }

        public HRESULT TryAttach()
        {
            /*HRESULT Attach();*/
            return Raw.Attach();
        }

        #endregion
        #endregion
        #region ICorDebugAppDomain2

        public ICorDebugAppDomain2 Raw2 => (ICorDebugAppDomain2) Raw;

        #region GetArrayOrPointerType

        public CorDebugType GetArrayOrPointerType(CorElementType elementType, uint nRank, ICorDebugType pTypeArg)
        {
            HRESULT hr;
            CorDebugType ppTypeResult;

            if ((hr = TryGetArrayOrPointerType(elementType, nRank, pTypeArg, out ppTypeResult)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return ppTypeResult;
        }

        public HRESULT TryGetArrayOrPointerType(CorElementType elementType, uint nRank, ICorDebugType pTypeArg, out CorDebugType ppTypeResult)
        {
            /*HRESULT GetArrayOrPointerType(
            [In] CorElementType elementType,
            [In] uint nRank,
            [MarshalAs(UnmanagedType.Interface), In]
            ICorDebugType pTypeArg,
            [MarshalAs(UnmanagedType.Interface)] out ICorDebugType ppType);*/
            ICorDebugType ppType;
            HRESULT hr = Raw2.GetArrayOrPointerType(elementType, nRank, pTypeArg, out ppType);

            if (hr == HRESULT.S_OK)
                ppTypeResult = new CorDebugType(ppType);
            else
                ppTypeResult = default(CorDebugType);

            return hr;
        }

        #endregion
        #region GetFunctionPointerType

        public CorDebugType GetFunctionPointerType(uint nTypeArgs, ICorDebugType ppTypeArgs)
        {
            HRESULT hr;
            CorDebugType ppTypeResult;

            if ((hr = TryGetFunctionPointerType(nTypeArgs, ppTypeArgs, out ppTypeResult)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return ppTypeResult;
        }

        public HRESULT TryGetFunctionPointerType(uint nTypeArgs, ICorDebugType ppTypeArgs, out CorDebugType ppTypeResult)
        {
            /*HRESULT GetFunctionPointerType(
            [In] uint nTypeArgs,
            [MarshalAs(UnmanagedType.Interface), In]
            ref ICorDebugType ppTypeArgs,
            [MarshalAs(UnmanagedType.Interface)] out ICorDebugType ppType);*/
            ICorDebugType ppType;
            HRESULT hr = Raw2.GetFunctionPointerType(nTypeArgs, ref ppTypeArgs, out ppType);

            if (hr == HRESULT.S_OK)
                ppTypeResult = new CorDebugType(ppType);
            else
                ppTypeResult = default(CorDebugType);

            return hr;
        }

        #endregion
        #endregion
        #region ICorDebugAppDomain3

        public ICorDebugAppDomain3 Raw3 => (ICorDebugAppDomain3) Raw;

        #region GetCachedWinRTTypes

        public CorDebugGuidToTypeEnum CachedWinRTTypes
        {
            get
            {
                HRESULT hr;
                CorDebugGuidToTypeEnum ppGuidToTypeEnumResult;

                if ((hr = TryGetCachedWinRTTypes(out ppGuidToTypeEnumResult)) != HRESULT.S_OK)
                    Marshal.ThrowExceptionForHR((int) hr);

                return ppGuidToTypeEnumResult;
            }
        }

        public HRESULT TryGetCachedWinRTTypes(out CorDebugGuidToTypeEnum ppGuidToTypeEnumResult)
        {
            /*HRESULT GetCachedWinRTTypes([MarshalAs(UnmanagedType.Interface)] out ICorDebugGuidToTypeEnum ppGuidToTypeEnum);*/
            ICorDebugGuidToTypeEnum ppGuidToTypeEnum;
            HRESULT hr = Raw3.GetCachedWinRTTypes(out ppGuidToTypeEnum);

            if (hr == HRESULT.S_OK)
                ppGuidToTypeEnumResult = new CorDebugGuidToTypeEnum(ppGuidToTypeEnum);
            else
                ppGuidToTypeEnumResult = default(CorDebugGuidToTypeEnum);

            return hr;
        }

        #endregion
        #region GetCachedWinRTTypesForIIDs

        public CorDebugTypeEnum GetCachedWinRTTypesForIIDs(uint cReqTypes, Guid iidsToResolve)
        {
            HRESULT hr;
            CorDebugTypeEnum ppTypesEnumResult;

            if ((hr = TryGetCachedWinRTTypesForIIDs(cReqTypes, iidsToResolve, out ppTypesEnumResult)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return ppTypesEnumResult;
        }

        public HRESULT TryGetCachedWinRTTypesForIIDs(uint cReqTypes, Guid iidsToResolve, out CorDebugTypeEnum ppTypesEnumResult)
        {
            /*HRESULT GetCachedWinRTTypesForIIDs(
            [In] uint cReqTypes,
            [In] ref Guid iidsToResolve,
            [MarshalAs(UnmanagedType.Interface)] out ICorDebugTypeEnum ppTypesEnum);*/
            ICorDebugTypeEnum ppTypesEnum;
            HRESULT hr = Raw3.GetCachedWinRTTypesForIIDs(cReqTypes, ref iidsToResolve, out ppTypesEnum);

            if (hr == HRESULT.S_OK)
                ppTypesEnumResult = new CorDebugTypeEnum(ppTypesEnum);
            else
                ppTypesEnumResult = default(CorDebugTypeEnum);

            return hr;
        }

        #endregion
        #endregion
        #region ICorDebugAppDomain4

        public ICorDebugAppDomain4 Raw4 => (ICorDebugAppDomain4) Raw;

        #region GetObjectForCCW

        public CorDebugValue GetObjectForCCW(ulong ccwPointer)
        {
            HRESULT hr;
            CorDebugValue ppManagedObjectResult;

            if ((hr = TryGetObjectForCCW(ccwPointer, out ppManagedObjectResult)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return ppManagedObjectResult;
        }

        public HRESULT TryGetObjectForCCW(ulong ccwPointer, out CorDebugValue ppManagedObjectResult)
        {
            /*HRESULT GetObjectForCCW([In] ulong ccwPointer,
            [MarshalAs(UnmanagedType.Interface)] out ICorDebugValue ppManagedObject);*/
            ICorDebugValue ppManagedObject;
            HRESULT hr = Raw4.GetObjectForCCW(ccwPointer, out ppManagedObject);

            if (hr == HRESULT.S_OK)
                ppManagedObjectResult = CorDebugValue.New(ppManagedObject);
            else
                ppManagedObjectResult = default(CorDebugValue);

            return hr;
        }

        #endregion
        #endregion
    }
}