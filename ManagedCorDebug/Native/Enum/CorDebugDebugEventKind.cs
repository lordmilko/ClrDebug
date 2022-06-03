﻿namespace ManagedCorDebug
{
    public enum CorDebugDebugEventKind
    {
        DEBUG_EVENT_KIND_MODULE_LOADED = 1,
        DEBUG_EVENT_KIND_MODULE_UNLOADED = 2,
        DEBUG_EVENT_KIND_MANAGED_EXCEPTION_FIRST_CHANCE = 3,
        DEBUG_EVENT_KIND_MANAGED_EXCEPTION_USER_FIRST_CHANCE = 4,
        DEBUG_EVENT_KIND_MANAGED_EXCEPTION_CATCH_HANDLER_FOUND = 5,
        DEBUG_EVENT_KIND_MANAGED_EXCEPTION_UNHANDLED = 6
    }
}