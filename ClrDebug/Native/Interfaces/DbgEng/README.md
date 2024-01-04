| Directory   | Description |
| ----------- | ----------- |
| DebugClient | Contains interfaces that revolve around `IDebugClient`. These interfaces are also compatible with the proxy objects returned from `DebugConnect`. All proxy compatible interfaces will have a type `Proxy<interface>N` defined in `dbgeng.dll` |
| Model       | Contains interfaces defined in `dbgmodel.h` |
| Services    | Contains interfaces defined in `dbgservices.h` |

Due to a long-standing bug in DbgEng, it is normally not possible to hold a managed COM interface to a proxy returned from `DebugConnect`, as these proxies erroneously do not respond to `QueryInterface` requests for `IUnknown`. However, in modern versions of DbgEng, by creating an `IDebugTestHook` via `DebugCreate` however, it is possible to set `g_bAllowQiIUnknown` to `1`, thereby allowing you to
hold full COM interfaces for proxy types.