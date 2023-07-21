#include "CTest.h"
#pragma region IUnknown

ULONG CTest::AddRef()
{
    return InterlockedIncrement(&m_RefCount);
}

ULONG CTest::Release()
{
    ULONG refCount = InterlockedDecrement(&m_RefCount);

    if (refCount == 0)
        delete this;

    return refCount;
}

HRESULT CTest::QueryInterface(REFIID riid, void** ppvObject)
{
    if (ppvObject == nullptr)
        return E_POINTER;

    if (riid == IID_IUnknown)
        *ppvObject = static_cast<IUnknown*>(this);
    else if (riid == __uuidof(IVariantTest))
        *ppvObject = static_cast<IVariantTest*>(this);
    else
    {
        *ppvObject = nullptr;
        return E_NOINTERFACE;
    }

    reinterpret_cast<IUnknown*>(*ppvObject)->AddRef();

    return S_OK;
}

#pragma endregion

#define TestGet(clrName, vtName, value) \
    HRESULT CTest::Get##clrName(VARIANT* v) \
    { \
        V_VT(v) = VT_##vtName; \
        V_##vtName(v) = value; \
        return S_OK; \
    }

#define TestGetEmpty(clrName, vtName) \
    HRESULT CTest::Get##clrName(VARIANT* v) \
    { \
        V_VT(v) = VT_##vtName; \
        return S_OK; \
    }

#define TestSet(clrName, vtName, value) \
    HRESULT CTest::Set##clrName(VARIANT* v) \
    { \
        if (V_VT(v) != VT_##vtName) \
            return E_FAIL; \
        \
        if (V_##vtName(v) != value) \
            return E_FAIL; \
        \
        return S_OK; \
    }

#define TestSetEmpty(clrName, vtName) \
    HRESULT CTest::Set##clrName(VARIANT* v) \
    { \
        if (V_VT(v) != VT_##vtName) \
            return E_FAIL; \
        \
        return S_OK; \
    }

//Get
TestGetEmpty(Empty, EMPTY)
TestGetEmpty(Null, NULL)
TestGet(U1, UI1, 8)
TestGet(U2, UI2, 32000)
TestGet(U4, UI4, 123456789)
TestGet(U8, UI8, 1234567812345678)
TestGet(I1, I1, -8);
TestGet(I2, I2, -32000);
TestGet(I4, I4, -123456789)
TestGet(I8, I8, -1234567812345678)
TestGet(BStr, BSTR, SysAllocString(L"hello"))
TestGet(Bool, BOOL, -1)
TestGet(Unknown, UNKNOWN, this)
//TestGetEmpty(Void, VOID)
TestGet(Float, R4, 1.2f)
TestGet(Double, R8, 1.23456789)

//Set
TestSetEmpty(Empty, EMPTY)
TestSetEmpty(Null, NULL)
TestSet(U1, UI1, 8)
TestSet(U2, UI2, 32000)
TestSet(U4, UI4, 123456789)
TestSet(U8, UI8, 1234567812345678)
TestSet(I1, I1, -8);
TestSet(I2, I2, -32000);
TestSet(I4, I4, -123456789)
TestSet(I8, I8, -1234567812345678)


HRESULT CTest::SetBStr(VARIANT* v) \
{ \
    if (V_VT(v) != VT_BSTR)
        return E_FAIL;

    if (wcscmp(V_BSTR(v), L"hello") != 0)
        return E_FAIL;

    return S_OK;
}

TestSet(Bool, BOOL, -1)
TestSet(Unknown, UNKNOWN, this)
//TestSetEmpty(Void, VOID)
TestSet(Float, R4, 1.2f)
TestSet(Double, R8, 1.23456789)
