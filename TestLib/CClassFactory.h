#pragma once

#include <Windows.h>

/// <summary>
/// An IClassFactory implementation capable of creating ICorProfilerCallback* instances.
/// </summary>
class CClassFactory final : public IClassFactory
{
public:
    CClassFactory() : m_RefCount(0)
    {
    }

    // IUnknown
    STDMETHODIMP_(ULONG) AddRef() override;
    STDMETHODIMP QueryInterface(REFIID riid, void** ppvObject) override;
    STDMETHODIMP_(ULONG) Release() override;

    // IClassFactory
    STDMETHODIMP CreateInstance(IUnknown* pUnkOuter, REFIID riid, void** ppvObject) override;
    STDMETHODIMP LockServer(BOOL fLock) override;

private:

    /// <summary>
    /// The reference count of this object.
    /// </summary>
    long m_RefCount;
};