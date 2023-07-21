#include "CClassFactory.h"
#include "CTest.h"

#pragma region IUnknown

/// <summary>
/// Increments the reference count of this object.
/// </summary>
/// <returns>The incremented reference count.</returns>
ULONG CClassFactory::AddRef()
{
    return InterlockedIncrement(&m_RefCount);
}

/// <summary>
/// Decrements the reference count of this object. When the reference count reaches 0 this object will be deleted.
/// </summary>
/// <returns>The new reference count of this object.</returns>
ULONG CClassFactory::Release()
{
    ULONG refCount = InterlockedDecrement(&m_RefCount);

    if (refCount == 0)
        delete this;

    return refCount;
}

/// <summary>
/// Queries the class factory for a pointer to a specific interface it may implement.
/// </summary>
/// <param name="riid">The identifier of the interface that is being queried for.</param>
/// <param name="ppvObject">A pointer to store a pointer to the interface to, if it is supported.</param>
/// <returns>E_POINTER if ppvObject was null, S_OK if the interface is supported or E_NOINTERFACE if the interface is not supported.</returns>
HRESULT CClassFactory::QueryInterface(REFIID riid, void** ppvObject)
{
    if (ppvObject == nullptr)
        return E_POINTER;

    if (riid == IID_IUnknown)
        *ppvObject = static_cast<IUnknown*>(this);
    else if (riid == IID_IClassFactory)
        *ppvObject = static_cast<IClassFactory*>(this);
    else
    {
        *ppvObject = nullptr;
        return E_NOINTERFACE;
    }

    reinterpret_cast<IUnknown*>(*ppvObject)->AddRef();

    return S_OK;
}

#pragma endregion
#pragma region IClassFactory

/// <summary>
/// Creates an ICorProfilerCallback* to use for profiling an application.
/// </summary>
/// <param name="pUnkOuter">A pointer to an outer aggregate. This value must be null.</param>
/// <param name="riid">The identifier of the interface that the type to be created implements.</param>
/// <param name="ppvObject">A pointer to store the created instance in.</param>
/// <returns>S_OK if the instance was successfully created, E_NOINTERFACE if the interface is not supported, or another HRESULT indicating failure.</returns>
HRESULT CClassFactory::CreateInstance(IUnknown* pUnkOuter, REFIID riid, void** ppvObject)
{
    if (pUnkOuter != nullptr)
        return CLASS_E_NOAGGREGATION;

    if (riid == __uuidof(IVariantTest))
    {
        //All profilers written for .NET Framework 2+ must implement ICorProfilerCallback2
        IVariantTest* pTest = new CTest();

        if (pTest == nullptr)
            return E_OUTOFMEMORY;

        return pTest->QueryInterface(riid, ppvObject);
    }

    return E_NOINTERFACE;
}

/// <summary>
/// Locks an object application open in memory. This method is not implemented in this application.
/// </summary>
/// <param name="fLock">TRUE to increment the lock count, FALSE to decrement the lock count.</param>
/// <returns>A HRESULT that indicates success or failure.</returns>
HRESULT CClassFactory::LockServer(BOOL fLock)
{
    //This application does not support server locking
    return S_OK;
}

#pragma endregion