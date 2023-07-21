#include <Windows.h>
#include "CClassFactory.h"
#include "CTest.h"

extern "C" HRESULT WINAPI DllGetClassObject(REFCLSID rclsid, REFIID riid, void** ppv)
{
    if (IsEqualCLSID(rclsid, __uuidof(CTest)))
    {
        IClassFactory* pClassFactory = new CClassFactory();

        if (pClassFactory == nullptr)
            return E_OUTOFMEMORY;

        return pClassFactory->QueryInterface(riid, ppv);
    }

    return CLASS_E_CLASSNOTAVAILABLE;
}