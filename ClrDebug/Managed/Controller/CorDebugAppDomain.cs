using System;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace ClrDebug
{
    /// <summary>
    /// Provides methods for debugging application domains. This interface is a subclass of <see cref="ICorDebugController"/>.
    /// </summary>
    public class CorDebugAppDomain : CorDebugController
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CorDebugAppDomain"/> class.
        /// </summary>
        /// <param name="raw">The raw COM interface that should be contained in this object.</param>
        public CorDebugAppDomain(ICorDebugAppDomain raw) : base(raw)
        {
        }

        #region ICorDebugAppDomain

        public new ICorDebugAppDomain Raw => (ICorDebugAppDomain) base.Raw;

        #region Process

        /// <summary>
        /// Gets the process containing the application domain.
        /// </summary>
        public CorDebugProcess Process
        {
            get
            {
                CorDebugProcess ppProcessResult;
                TryGetProcess(out ppProcessResult).ThrowOnNotOK();

                return ppProcessResult;
            }
        }

        /// <summary>
        /// Gets the process containing the application domain.
        /// </summary>
        /// <param name="ppProcessResult">[out] A pointer to the address of an <see cref="ICorDebugProcess"/> object that represents the process.</param>
        public HRESULT TryGetProcess(out CorDebugProcess ppProcessResult)
        {
            /*HRESULT GetProcess(
            [Out, MarshalAs(UnmanagedType.Interface)] out ICorDebugProcess ppProcess);*/
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

        /// <summary>
        /// Gets a value that indicates whether the debugger is attached to the application domain.
        /// </summary>
        public bool IsAttached
        {
            get
            {
                bool pbAttached;
                TryIsAttached(out pbAttached).ThrowOnNotOK();

                return pbAttached;
            }
        }

        /// <summary>
        /// Gets a value that indicates whether the debugger is attached to the application domain.
        /// </summary>
        /// <param name="pbAttached">[out] true if the debugger is attached to the application domain; otherwise, false.</param>
        /// <remarks>
        /// The <see cref="ICorDebugController"/> methods cannot be used until the debugger attaches to the application domain.
        /// </remarks>
        public HRESULT TryIsAttached(out bool pbAttached)
        {
            /*HRESULT IsAttached(
            [Out] out bool pbAttached);*/
            return Raw.IsAttached(out pbAttached);
        }

        #endregion
        #region Name

        /// <summary>
        /// Gets the name of the application domain.
        /// </summary>
        public string Name
        {
            get
            {
                string szNameResult;
                TryGetName(out szNameResult).ThrowOnNotOK();

                return szNameResult;
            }
        }

        /// <summary>
        /// Gets the name of the application domain.
        /// </summary>
        /// <param name="szNameResult">[out] An array that stores the name of the application domain.</param>
        /// <remarks>
        /// A debugger calls the GetName method once to get the size of a buffer needed for the name. The debugger allocates
        /// the buffer, and then calls the method a second time to fill the buffer. The first call, to get the size of the
        /// name, is referred to as query mode.
        /// </remarks>
        public HRESULT TryGetName(out string szNameResult)
        {
            /*HRESULT GetName(
            [In] int cchName,
            [Out] out int pcchName,
            [Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder szName);*/
            int cchName = 0;
            int pcchName;
            StringBuilder szName;
            HRESULT hr = Raw.GetName(cchName, out pcchName, null);

            if (hr != HRESULT.S_FALSE && hr != HRESULT.ERROR_INSUFFICIENT_BUFFER && hr != HRESULT.S_OK)
                goto fail;

            cchName = pcchName;
            szName = new StringBuilder(cchName);
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
        #region Object

        /// <summary>
        /// Gets an interface pointer to the common language runtime (CLR) application domain.
        /// </summary>
        public CorDebugValue Object
        {
            get
            {
                CorDebugValue ppObjectResult;
                TryGetObject(out ppObjectResult).ThrowOnNotOK();

                return ppObjectResult;
            }
        }

        /// <summary>
        /// Gets an interface pointer to the common language runtime (CLR) application domain.
        /// </summary>
        /// <param name="ppObjectResult">[out] A pointer to the address of an <see cref="ICorDebugValue"/> interface object that represents the CLR application domain.</param>
        /// <returns>If a managed <see cref="AppDomain"/> object hasn't been constructed for this application domain, the method returns S_FALSE and places NULL in *ppObject.</returns>
        /// <remarks>
        /// Each application domain in a process may have a managed <see cref="AppDomain"/> object in the runtime that represents
        /// it. This function gets an <see cref="ICorDebugValue"/> interface object that corresponds to this managed <see cref="AppDomain"/>
        /// object.
        /// </remarks>
        public HRESULT TryGetObject(out CorDebugValue ppObjectResult)
        {
            /*HRESULT GetObject(
            [Out, MarshalAs(UnmanagedType.Interface)] out ICorDebugValue ppObject);*/
            ICorDebugValue ppObject;
            HRESULT hr = Raw.GetObject(out ppObject);

            if (hr == HRESULT.S_OK)
                ppObjectResult = CorDebugValue.New(ppObject);
            else
                ppObjectResult = default(CorDebugValue);

            return hr;
        }

        #endregion
        #region Id

        /// <summary>
        /// Gets the unique identifier of the application domain.
        /// </summary>
        public int Id
        {
            get
            {
                int pId;
                TryGetID(out pId).ThrowOnNotOK();

                return pId;
            }
        }

        /// <summary>
        /// Gets the unique identifier of the application domain.
        /// </summary>
        /// <param name="pId">[out] The unique identifier of the application domain.</param>
        /// <remarks>
        /// The identifier for the application domain is unique within the containing process.
        /// </remarks>
        public HRESULT TryGetID(out int pId)
        {
            /*HRESULT GetID(
            [Out] out int pId);*/
            return Raw.GetID(out pId);
        }

        #endregion
        #region EnumerateAssemblies

        /// <summary>
        /// Gets an enumerator for the assemblies in the application domain.
        /// </summary>
        public CorDebugAssembly[] Assemblies => EnumerateAssemblies().ToArray();

        /// <summary>
        /// Gets an enumerator for the assemblies in the application domain.
        /// </summary>
        /// <returns>[out] A pointer to the address of an <see cref="ICorDebugAssemblyEnum"/> object that is the enumerator for the assemblies in the application domain.</returns>
        public CorDebugAssemblyEnum EnumerateAssemblies()
        {
            CorDebugAssemblyEnum ppAssembliesResult;
            TryEnumerateAssemblies(out ppAssembliesResult).ThrowOnNotOK();

            return ppAssembliesResult;
        }

        /// <summary>
        /// Gets an enumerator for the assemblies in the application domain.
        /// </summary>
        /// <param name="ppAssembliesResult">[out] A pointer to the address of an <see cref="ICorDebugAssemblyEnum"/> object that is the enumerator for the assemblies in the application domain.</param>
        public HRESULT TryEnumerateAssemblies(out CorDebugAssemblyEnum ppAssembliesResult)
        {
            /*HRESULT EnumerateAssemblies(
            [Out, MarshalAs(UnmanagedType.Interface)] out ICorDebugAssemblyEnum ppAssemblies);*/
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

        /// <summary>
        /// Gets the module that corresponds to the given metadata interface.
        /// </summary>
        /// <param name="pIMetaData">[in] A pointer to an object that is one of the Metadata interfaces.</param>
        /// <returns>[out] A pointer to the address of an <see cref="ICorDebugModule"/> object that represents the module corresponding to the given metadata interface.</returns>
        public CorDebugModule GetModuleFromMetaDataInterface(object pIMetaData)
        {
            CorDebugModule ppModuleResult;
            TryGetModuleFromMetaDataInterface(pIMetaData, out ppModuleResult).ThrowOnNotOK();

            return ppModuleResult;
        }

        /// <summary>
        /// Gets the module that corresponds to the given metadata interface.
        /// </summary>
        /// <param name="pIMetaData">[in] A pointer to an object that is one of the Metadata interfaces.</param>
        /// <param name="ppModuleResult">[out] A pointer to the address of an <see cref="ICorDebugModule"/> object that represents the module corresponding to the given metadata interface.</param>
        public HRESULT TryGetModuleFromMetaDataInterface(object pIMetaData, out CorDebugModule ppModuleResult)
        {
            /*HRESULT GetModuleFromMetaDataInterface(
            [MarshalAs(UnmanagedType.IUnknown), In] object pIMetaData,
            [Out, MarshalAs(UnmanagedType.Interface)] out ICorDebugModule ppModule);*/
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

        /// <summary>
        /// Gets an enumerator for all active breakpoints in the application domain.
        /// </summary>
        public CorDebugBreakpoint[] Breakpoints => EnumerateBreakpoints().ToArray();

        /// <summary>
        /// Gets an enumerator for all active breakpoints in the application domain.
        /// </summary>
        /// <returns>[out] A pointer to the address of an <see cref="ICorDebugBreakpointEnum"/> object that is the enumerator for all active breakpoints in the application domain.</returns>
        /// <remarks>
        /// The enumerator includes all types of breakpoints, including function breakpoints and data breakpoints.
        /// </remarks>
        public CorDebugBreakpointEnum EnumerateBreakpoints()
        {
            CorDebugBreakpointEnum ppBreakpointsResult;
            TryEnumerateBreakpoints(out ppBreakpointsResult).ThrowOnNotOK();

            return ppBreakpointsResult;
        }

        /// <summary>
        /// Gets an enumerator for all active breakpoints in the application domain.
        /// </summary>
        /// <param name="ppBreakpointsResult">[out] A pointer to the address of an <see cref="ICorDebugBreakpointEnum"/> object that is the enumerator for all active breakpoints in the application domain.</param>
        /// <remarks>
        /// The enumerator includes all types of breakpoints, including function breakpoints and data breakpoints.
        /// </remarks>
        public HRESULT TryEnumerateBreakpoints(out CorDebugBreakpointEnum ppBreakpointsResult)
        {
            /*HRESULT EnumerateBreakpoints(
            [Out, MarshalAs(UnmanagedType.Interface)] out ICorDebugBreakpointEnum ppBreakpoints);*/
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

        /// <summary>
        /// Gets an enumerator for all active steppers in the application domain.
        /// </summary>
        public CorDebugStepper[] Steppers => EnumerateSteppers().ToArray();

        /// <summary>
        /// Gets an enumerator for all active steppers in the application domain.
        /// </summary>
        /// <returns>[out] A pointer to the address of an <see cref="ICorDebugStepperEnum"/> object that is the enumerator for all active steppers in the application domain.</returns>
        public CorDebugStepperEnum EnumerateSteppers()
        {
            CorDebugStepperEnum ppSteppersResult;
            TryEnumerateSteppers(out ppSteppersResult).ThrowOnNotOK();

            return ppSteppersResult;
        }

        /// <summary>
        /// Gets an enumerator for all active steppers in the application domain.
        /// </summary>
        /// <param name="ppSteppersResult">[out] A pointer to the address of an <see cref="ICorDebugStepperEnum"/> object that is the enumerator for all active steppers in the application domain.</param>
        public HRESULT TryEnumerateSteppers(out CorDebugStepperEnum ppSteppersResult)
        {
            /*HRESULT EnumerateSteppers(
            [Out, MarshalAs(UnmanagedType.Interface)] out ICorDebugStepperEnum ppSteppers);*/
            ICorDebugStepperEnum ppSteppers;
            HRESULT hr = Raw.EnumerateSteppers(out ppSteppers);

            if (hr == HRESULT.S_OK)
                ppSteppersResult = new CorDebugStepperEnum(ppSteppers);
            else
                ppSteppersResult = default(CorDebugStepperEnum);

            return hr;
        }

        #endregion
        #region Attach

        /// <summary>
        /// Attaches the debugger to the application domain.
        /// </summary>
        /// <remarks>
        /// The debugger must be attached to the application domain to receive events and to enable debugging of the application
        /// domain.
        /// </remarks>
        public void Attach()
        {
            TryAttach().ThrowOnNotOK();
        }

        /// <summary>
        /// Attaches the debugger to the application domain.
        /// </summary>
        /// <remarks>
        /// The debugger must be attached to the application domain to receive events and to enable debugging of the application
        /// domain.
        /// </remarks>
        public HRESULT TryAttach()
        {
            /*HRESULT Attach();*/
            return Raw.Attach();
        }

        #endregion
        #endregion
        #region ICorDebugAppDomain2

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        public ICorDebugAppDomain2 Raw2 => (ICorDebugAppDomain2) Raw;

        #region GetArrayOrPointerType

        /// <summary>
        /// Gets an array of the specified type, or a pointer or reference to the specified type.
        /// </summary>
        /// <param name="elementType">[in] A value of the <see cref="CorElementType"/> enumeration that specifies the underlying native type (an array, pointer, or reference) to be created.</param>
        /// <param name="nRank">[in] The rank (that is, number of dimensions) of the array. This value must be 0 if elementType specifies a pointer or reference type.</param>
        /// <param name="pTypeArg">[in] A pointer to an <see cref="ICorDebugType"/> object that represents the type of array, pointer, or reference to be created.</param>
        /// <returns>[out] A pointer to the address of an <see cref="ICorDebugType"/> object that represents the constructed array, pointer type, or reference type.</returns>
        /// <remarks>
        /// The value of elementType must be one of the following: If the value of elementType is ELEMENT_TYPE_PTR or ELEMENT_TYPE_BYREF,
        /// nRank must be zero.
        /// </remarks>
        public CorDebugType GetArrayOrPointerType(CorElementType elementType, int nRank, ICorDebugType pTypeArg)
        {
            CorDebugType ppTypeResult;
            TryGetArrayOrPointerType(elementType, nRank, pTypeArg, out ppTypeResult).ThrowOnNotOK();

            return ppTypeResult;
        }

        /// <summary>
        /// Gets an array of the specified type, or a pointer or reference to the specified type.
        /// </summary>
        /// <param name="elementType">[in] A value of the <see cref="CorElementType"/> enumeration that specifies the underlying native type (an array, pointer, or reference) to be created.</param>
        /// <param name="nRank">[in] The rank (that is, number of dimensions) of the array. This value must be 0 if elementType specifies a pointer or reference type.</param>
        /// <param name="pTypeArg">[in] A pointer to an <see cref="ICorDebugType"/> object that represents the type of array, pointer, or reference to be created.</param>
        /// <param name="ppTypeResult">[out] A pointer to the address of an <see cref="ICorDebugType"/> object that represents the constructed array, pointer type, or reference type.</param>
        /// <remarks>
        /// The value of elementType must be one of the following: If the value of elementType is ELEMENT_TYPE_PTR or ELEMENT_TYPE_BYREF,
        /// nRank must be zero.
        /// </remarks>
        public HRESULT TryGetArrayOrPointerType(CorElementType elementType, int nRank, ICorDebugType pTypeArg, out CorDebugType ppTypeResult)
        {
            /*HRESULT GetArrayOrPointerType(
            [In] CorElementType elementType,
            [In] int nRank,
            [MarshalAs(UnmanagedType.Interface), In] ICorDebugType pTypeArg,
            [Out, MarshalAs(UnmanagedType.Interface)] out ICorDebugType ppType);*/
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

        /// <summary>
        /// Gets a pointer to a function that has a given signature.
        /// </summary>
        /// <param name="nTypeArgs">[in] The number of type arguments for the function.</param>
        /// <param name="ppTypeArgs">[in] An array of pointers, each of which points to an <see cref="ICorDebugType"/> object that represents a type argument of the function.<para/>
        /// The first element is the return type; each of the other elements is a parameter type.</param>
        /// <returns>[out] A pointer to the address of an <see cref="ICorDebugType"/> object that represents the pointer to the function.</returns>
        public CorDebugType GetFunctionPointerType(int nTypeArgs, ICorDebugType ppTypeArgs)
        {
            CorDebugType ppTypeResult;
            TryGetFunctionPointerType(nTypeArgs, ppTypeArgs, out ppTypeResult).ThrowOnNotOK();

            return ppTypeResult;
        }

        /// <summary>
        /// Gets a pointer to a function that has a given signature.
        /// </summary>
        /// <param name="nTypeArgs">[in] The number of type arguments for the function.</param>
        /// <param name="ppTypeArgs">[in] An array of pointers, each of which points to an <see cref="ICorDebugType"/> object that represents a type argument of the function.<para/>
        /// The first element is the return type; each of the other elements is a parameter type.</param>
        /// <param name="ppTypeResult">[out] A pointer to the address of an <see cref="ICorDebugType"/> object that represents the pointer to the function.</param>
        public HRESULT TryGetFunctionPointerType(int nTypeArgs, ICorDebugType ppTypeArgs, out CorDebugType ppTypeResult)
        {
            /*HRESULT GetFunctionPointerType(
            [In] int nTypeArgs,
            [MarshalAs(UnmanagedType.Interface), In] ref ICorDebugType ppTypeArgs,
            [Out, MarshalAs(UnmanagedType.Interface)] out ICorDebugType ppType);*/
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

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        public ICorDebugAppDomain3 Raw3 => (ICorDebugAppDomain3) Raw;

        #region CachedWinRTTypes

        /// <summary>
        /// Gets an enumerator for all cached Windows Runtime types.
        /// </summary>
        public CorDebugGuidToTypeEnum CachedWinRTTypes
        {
            get
            {
                CorDebugGuidToTypeEnum ppGuidToTypeEnumResult;
                TryGetCachedWinRTTypes(out ppGuidToTypeEnumResult).ThrowOnNotOK();

                return ppGuidToTypeEnumResult;
            }
        }

        /// <summary>
        /// Gets an enumerator for all cached Windows Runtime types.
        /// </summary>
        /// <param name="ppGuidToTypeEnumResult">[out] A pointer to an <see cref="ICorDebugGuidToTypeEnum"/> interface object that can enumerate the managed representations of Windows Runtime types currently loaded in the application domain.</param>
        public HRESULT TryGetCachedWinRTTypes(out CorDebugGuidToTypeEnum ppGuidToTypeEnumResult)
        {
            /*HRESULT GetCachedWinRTTypes(
            [Out, MarshalAs(UnmanagedType.Interface)] out ICorDebugGuidToTypeEnum ppGuidToTypeEnum);*/
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

        /// <summary>
        /// Gets an enumerator for cached Windows Runtime types in an application domain based on their interface identifiers.
        /// </summary>
        /// <param name="cReqTypes">[in] The number of required types.</param>
        /// <param name="iidsToResolve">[in] A pointer to an array that contains the interface identifiers corresponding to the managed representations of the Windows Runtime types to be retrieved.</param>
        /// <returns>[out] A pointer to the address of an "ICorDebugTypeEnum" interface object that allows enumeration of the cached managed representations of the Windows Runtime types retrieved, based on the interface identifiers in iidsToResolve.</returns>
        /// <remarks>
        /// If the method fails to retrieve information for a specific interface identifier, the corresponding entry in the
        /// "ICorDebugTypeEnum" collection will have a type of ELEMENT_TYPE_END for errors due to data retrieval issues, or
        /// ELEMENT_TYPE_VOID for unknown interface identifiers.
        /// </remarks>
        public CorDebugTypeEnum GetCachedWinRTTypesForIIDs(int cReqTypes, Guid iidsToResolve)
        {
            CorDebugTypeEnum ppTypesEnumResult;
            TryGetCachedWinRTTypesForIIDs(cReqTypes, iidsToResolve, out ppTypesEnumResult).ThrowOnNotOK();

            return ppTypesEnumResult;
        }

        /// <summary>
        /// Gets an enumerator for cached Windows Runtime types in an application domain based on their interface identifiers.
        /// </summary>
        /// <param name="cReqTypes">[in] The number of required types.</param>
        /// <param name="iidsToResolve">[in] A pointer to an array that contains the interface identifiers corresponding to the managed representations of the Windows Runtime types to be retrieved.</param>
        /// <param name="ppTypesEnumResult">[out] A pointer to the address of an "ICorDebugTypeEnum" interface object that allows enumeration of the cached managed representations of the Windows Runtime types retrieved, based on the interface identifiers in iidsToResolve.</param>
        /// <remarks>
        /// If the method fails to retrieve information for a specific interface identifier, the corresponding entry in the
        /// "ICorDebugTypeEnum" collection will have a type of ELEMENT_TYPE_END for errors due to data retrieval issues, or
        /// ELEMENT_TYPE_VOID for unknown interface identifiers.
        /// </remarks>
        public HRESULT TryGetCachedWinRTTypesForIIDs(int cReqTypes, Guid iidsToResolve, out CorDebugTypeEnum ppTypesEnumResult)
        {
            /*HRESULT GetCachedWinRTTypesForIIDs(
            [In] int cReqTypes,
            [In, MarshalAs(UnmanagedType.LPStruct)] Guid iidsToResolve,
            [Out, MarshalAs(UnmanagedType.Interface)] out ICorDebugTypeEnum ppTypesEnum);*/
            ICorDebugTypeEnum ppTypesEnum;
            HRESULT hr = Raw3.GetCachedWinRTTypesForIIDs(cReqTypes, iidsToResolve, out ppTypesEnum);

            if (hr == HRESULT.S_OK)
                ppTypesEnumResult = new CorDebugTypeEnum(ppTypesEnum);
            else
                ppTypesEnumResult = default(CorDebugTypeEnum);

            return hr;
        }

        #endregion
        #endregion
        #region ICorDebugAppDomain4

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        public ICorDebugAppDomain4 Raw4 => (ICorDebugAppDomain4) Raw;

        #region GetObjectForCCW

        /// <summary>
        /// Gets a managed object from a COM callable wrapper (CCW) pointer.
        /// </summary>
        /// <param name="ccwPointer">[in] A COM callable wrapper (CCW) pointer.</param>
        /// <returns>[out] A pointer to the address of an "ICorDebugValue" object that represents the managed object that corresponds to the given CCW pointer.</returns>
        public CorDebugValue GetObjectForCCW(CORDB_ADDRESS ccwPointer)
        {
            CorDebugValue ppManagedObjectResult;
            TryGetObjectForCCW(ccwPointer, out ppManagedObjectResult).ThrowOnNotOK();

            return ppManagedObjectResult;
        }

        /// <summary>
        /// Gets a managed object from a COM callable wrapper (CCW) pointer.
        /// </summary>
        /// <param name="ccwPointer">[in] A COM callable wrapper (CCW) pointer.</param>
        /// <param name="ppManagedObjectResult">[out] A pointer to the address of an "ICorDebugValue" object that represents the managed object that corresponds to the given CCW pointer.</param>
        public HRESULT TryGetObjectForCCW(CORDB_ADDRESS ccwPointer, out CorDebugValue ppManagedObjectResult)
        {
            /*HRESULT GetObjectForCCW(
            [In] CORDB_ADDRESS ccwPointer,
            [Out, MarshalAs(UnmanagedType.Interface)] out ICorDebugValue ppManagedObject);*/
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
        
        /// <summary>
        /// Returns a string that represents the current object.
        /// </summary>
        /// <returns>A string that represents the current object.</returns>
        public override string ToString()
        {
            return Name;
        }
    }
}
