#pragma once
#include <Windows.h>

class __declspec(uuid("326A6F4B-040F-4248-B0CD-95C80764784A")) CTest;

MIDL_INTERFACE("BB5760D0-1345-494E-A92D-D36E753693A3")
IVariantTest : public IUnknown
{
public:
    virtual HRESULT STDMETHODCALLTYPE GetEmpty(VARIANT* v) = 0;
    virtual HRESULT STDMETHODCALLTYPE GetNull(VARIANT* v) = 0;
    virtual HRESULT STDMETHODCALLTYPE GetU1(VARIANT* v) = 0;
    virtual HRESULT STDMETHODCALLTYPE GetU2(VARIANT* v) = 0;
    virtual HRESULT STDMETHODCALLTYPE GetU4(VARIANT* v) = 0;
    virtual HRESULT STDMETHODCALLTYPE GetU8(VARIANT* v) = 0;
    virtual HRESULT STDMETHODCALLTYPE GetI1(VARIANT* v) = 0;
    virtual HRESULT STDMETHODCALLTYPE GetI2(VARIANT* v) = 0;
    virtual HRESULT STDMETHODCALLTYPE GetI4(VARIANT* v) = 0;
    virtual HRESULT STDMETHODCALLTYPE GetI8(VARIANT* v) = 0;
    virtual HRESULT STDMETHODCALLTYPE GetBStr(VARIANT* v) = 0;
    virtual HRESULT STDMETHODCALLTYPE GetBool(VARIANT* v) = 0;
    virtual HRESULT STDMETHODCALLTYPE GetUnknown(VARIANT* v) = 0;
    //virtual HRESULT STDMETHODCALLTYPE GetVoid(VARIANT* v) = 0;
    virtual HRESULT STDMETHODCALLTYPE GetFloat(VARIANT* v) = 0;
    virtual HRESULT STDMETHODCALLTYPE GetDouble(VARIANT* v) = 0;

    virtual HRESULT STDMETHODCALLTYPE SetEmpty(VARIANT* v) = 0;
    virtual HRESULT STDMETHODCALLTYPE SetNull(VARIANT* v) = 0;
    virtual HRESULT STDMETHODCALLTYPE SetU1(VARIANT* v) = 0;
    virtual HRESULT STDMETHODCALLTYPE SetU2(VARIANT* v) = 0;
    virtual HRESULT STDMETHODCALLTYPE SetU4(VARIANT* v) = 0;
    virtual HRESULT STDMETHODCALLTYPE SetU8(VARIANT* v) = 0;
    virtual HRESULT STDMETHODCALLTYPE SetI1(VARIANT* v) = 0;
    virtual HRESULT STDMETHODCALLTYPE SetI2(VARIANT* v) = 0;
    virtual HRESULT STDMETHODCALLTYPE SetI4(VARIANT* v) = 0;
    virtual HRESULT STDMETHODCALLTYPE SetI8(VARIANT* v) = 0;
    virtual HRESULT STDMETHODCALLTYPE SetBStr(VARIANT* v) = 0;
    virtual HRESULT STDMETHODCALLTYPE SetBool(VARIANT* v) = 0;
    virtual HRESULT STDMETHODCALLTYPE SetUnknown(VARIANT* v) = 0;
    //virtual HRESULT STDMETHODCALLTYPE SetVoid(VARIANT* v) = 0;
    virtual HRESULT STDMETHODCALLTYPE SetFloat(VARIANT* v) = 0;
    virtual HRESULT STDMETHODCALLTYPE SetDouble(VARIANT* v) = 0;
};

class CTest : public IVariantTest
{
public:
    CTest() : m_RefCount(0)
    {
    }

    // IUnknown
    STDMETHODIMP_(ULONG) AddRef() override;
    STDMETHODIMP QueryInterface(REFIID riid, void** ppvObject) override;
    STDMETHODIMP_(ULONG) Release() override;

    // ITest
    STDMETHODIMP GetEmpty(VARIANT* v) override;
    STDMETHODIMP GetNull(VARIANT* v) override;
    STDMETHODIMP GetU1(VARIANT* v) override;
    STDMETHODIMP GetU2(VARIANT* v) override;
    STDMETHODIMP GetU4(VARIANT* v) override;
    STDMETHODIMP GetU8(VARIANT* v) override;
    STDMETHODIMP GetI1(VARIANT* v) override;
    STDMETHODIMP GetI2(VARIANT* v) override;
    STDMETHODIMP GetI4(VARIANT* v) override;
    STDMETHODIMP GetI8(VARIANT* v) override;
    STDMETHODIMP GetBStr(VARIANT* v) override;
    STDMETHODIMP GetBool(VARIANT* v) override;
    STDMETHODIMP GetUnknown(VARIANT* v) override;
    //STDMETHODIMP GetVoid(VARIANT* v) override;
    STDMETHODIMP GetFloat(VARIANT* v) override;
    STDMETHODIMP GetDouble(VARIANT* v) override;

    STDMETHODIMP SetEmpty(VARIANT* v) override;
    STDMETHODIMP SetNull(VARIANT* v) override;
    STDMETHODIMP SetU1(VARIANT* v) override;
    STDMETHODIMP SetU2(VARIANT* v) override;
    STDMETHODIMP SetU4(VARIANT* v) override;
    STDMETHODIMP SetU8(VARIANT* v) override;
    STDMETHODIMP SetI1(VARIANT* v) override;
    STDMETHODIMP SetI2(VARIANT* v) override;
    STDMETHODIMP SetI4(VARIANT* v) override;
    STDMETHODIMP SetI8(VARIANT* v) override;
    STDMETHODIMP SetBStr(VARIANT* v) override;
    STDMETHODIMP SetBool(VARIANT* v) override;
    STDMETHODIMP SetUnknown(VARIANT* v) override;
    //STDMETHODIMP SetVoid(VARIANT* v) override;
    STDMETHODIMP SetFloat(VARIANT* v) override;
    STDMETHODIMP SetDouble(VARIANT* v) override;

private:
    long m_RefCount;
};