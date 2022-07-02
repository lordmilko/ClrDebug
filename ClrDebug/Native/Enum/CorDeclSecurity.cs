namespace ClrDebug
{
    /// <summary>
    /// Specifies the security actions that can be performed using declarative security.
    /// </summary>
    public enum CorDeclSecurity
    {
        /// <summary>
        /// Reserved.
        /// </summary>
        dclActionMask               =   0x001f,     // Mask allows growth of enum.

        /// <summary>
        /// Reserved.
        /// </summary>
        dclActionNil                =   0x0000,     //

        /// <summary>
        /// Reserved.
        /// </summary>
        dclRequest                  =   0x0001,     //

        /// <summary>
        /// All callers higher in the call stack are required to have been granted the permission specified by the current permission object.
        /// </summary>
        dclDemand                   =   0x0002,     //

        /// <summary>
        /// The calling code can access the resource identified by the current permission object, even if callers higher in the stack have not been granted permission to access the resource
        /// </summary>
        dclAssert                   =   0x0003,     //

        /// <summary>
        /// The ability to access the resource specified by the current permission object is denied to callers, even if they have been granted permission to access it.
        /// </summary>
        dclDeny                     =   0x0004,     //

        /// <summary>
        /// Only the resources specified by this permission object can be accessed, even if the code has been granted permission to access other resources.
        /// </summary>
        dclPermitOnly               =   0x0005,     //

        /// <summary>
        /// The immediate caller is required to have been granted the specified permission for a given period of time.
        /// </summary>
        dclLinktimeCheck            =   0x0006,     //

        /// <summary>
        /// The derived class inheriting another class or overriding a method is required to have been granted the specified permission.
        /// </summary>
        dclInheritanceCheck         =   0x0007,     //

        /// <summary>
        /// The caller can request for the minimum permissions required for code to run. This action can only be used within the scope of the assembly.
        /// </summary>
        dclRequestMinimum           =   0x0008,     //

        /// <summary>
        /// The caller can request for additional permissions that are optional (not required to run). This request implicitly refuses all other permissions not specifically requested.<para/>
        /// This action can only be used within the scope of the assembly.
        /// </summary>
        dclRequestOptional          =   0x0009,     //

        /// <summary>
        /// The caller's request for permissions that might be misused will not be granted. This action can only be used within the scope of the assembly.
        /// </summary>
        dclRequestRefuse            =   0x000a,     //

        /// <summary>
        /// Reserved.
        /// </summary>
        dclPrejitGrant              =   0x000b,     // Persisted grant set at prejit time

        /// <summary>
        /// Reserved.
        /// </summary>
        dclPrejitDenied             =   0x000c,     // Persisted denied set at prejit time

        /// <summary>
        /// Reserved.
        /// </summary>
        dclNonCasDemand             =   0x000d,     //

        /// <summary>
        /// The immediate caller is required to have been granted the specified permission.
        /// </summary>
        dclNonCasLinkDemand         =   0x000e,     //

        /// <summary>
        /// Reserved.
        /// </summary>
        dclNonCasInheritance        =   0x000f,     //

        /// <summary>
        /// Reserved.
        /// </summary>
        dclMaximumValue             =   0x000f,     // Maximum legal value
    }
}