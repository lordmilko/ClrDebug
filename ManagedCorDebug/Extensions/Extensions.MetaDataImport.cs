using System;
using System.Diagnostics;

namespace ManagedCorDebug
{
    public static partial class Extensions
    {
        /// <summary>
        /// Enumerates TypeDef tokens representing all types within the current scope.
        /// </summary>
        /// <param name="metaDataImport">The <see cref="MetaDataImport"/> to use to enumerate the tokens.</param>
        /// <returns>The array used to store the TypeDef tokens.</returns>
        /// <remarks>
        /// The TypeDef token represents a type such as a class or an interface, as well as any type added via an extensibility
        /// mechanism.
        /// </remarks>
        public static mdTypeDef[] EnumTypeDefs(this MetaDataImport metaDataImport)
        {
            IntPtr hEnum = IntPtr.Zero;
            metaDataImport.EnumTypeDefs(ref hEnum, null);

            try
            {
                var count = metaDataImport.CountEnum(hEnum);

                var buffer = new mdTypeDef[count];

                metaDataImport.EnumTypeDefs(ref hEnum, buffer);

                return buffer;
            }
            finally
            {
                metaDataImport.CloseEnum(hEnum);
            }
        }

        /// <summary>
        /// Enumerates all interfaces implemented by the specified TypeDef.
        /// </summary>
        /// <param name="metaDataImport">The <see cref="MetaDataImport"/> to use to enumerate the tokens.</param>
        /// <param name="td">[in] The token of the TypeDef whose MethodDef tokens representing interface implementations are to be enumerated.</param>
        /// <returns>The array used to store the MethodDef tokens.</returns>
        /// <remarks>
        /// The enumeration returns a collection of <see cref="mdInterfaceImpl"/> tokens for each interface implemented by the specified
        /// TypeDef. Interface tokens are returned in the order the interfaces were specified (through DefineTypeDef or SetTypeDefProps).
        /// Properties of the returned <see cref="mdInterfaceImpl"/> tokens can be queried using <see cref="MetaDataImport.GetInterfaceImplProps"/>.
        /// </remarks>
        public static mdInterfaceImpl[] EnumInterfaceImpls(this MetaDataImport metaDataImport, mdTypeDef td)
        {
            IntPtr hEnum = IntPtr.Zero;
            metaDataImport.EnumInterfaceImpls(ref hEnum, td, null);

            try
            {
                var count = metaDataImport.CountEnum(hEnum);

                var buffer = new mdInterfaceImpl[count];

                metaDataImport.EnumInterfaceImpls(ref hEnum, td, buffer);

                return buffer;
            }
            finally
            {
                metaDataImport.CloseEnum(hEnum);
            }
        }

        /// <summary>
        /// Enumerates TypeRef tokens defined in the current metadata scope.
        /// </summary>
        /// <param name="metaDataImport">The <see cref="MetaDataImport"/> to use to enumerate the tokens.</param>
        /// <returns>The array used to store the TypeRef tokens.</returns>
        /// <remarks>
        /// A TypeRef token represents a reference to a type.
        /// </remarks>
        public static mdTypeRef[] EnumTypeRefs(this MetaDataImport metaDataImport)
        {
            IntPtr hEnum = IntPtr.Zero;
            metaDataImport.EnumTypeRefs(ref hEnum, null);

            try
            {
                var count = metaDataImport.CountEnum(hEnum);

                var buffer = new mdTypeRef[count];

                metaDataImport.EnumTypeRefs(ref hEnum, buffer);

                return buffer;
            }
            finally
            {
                metaDataImport.CloseEnum(hEnum);
            }
        }

        /// <summary>
        /// Enumerates MemberDef tokens representing members of the specified type.
        /// </summary>
        /// <param name="metaDataImport">The <see cref="MetaDataImport"/> to use to enumerate the tokens.</param>
        /// <param name="cl">[in] A TypeDef token representing the type whose members are to be enumerated.</param>
        /// <returns>The array of MemberDef tokens.</returns>
        /// <remarks>
        /// When enumerating collections of members for a class, EnumMembers returns only members (fields and methods, but
        /// not properties or events) defined directly on the class. It does not return any members that the class inherits,
        /// even if the class provides an implementation for those inherited members. To enumerate inherited members, the caller
        /// must explicitly walk the inheritance chain. Note that the rules for the inheritance chain may vary depending on
        /// the language or compiler that emitted the original metadata. Properties and events are not enumerated by EnumMembers.
        /// To enumerate those, use <see cref="MetaDataImport.EnumProperties"/> or <see cref="MetaDataImport.EnumEvents"/>.
        /// </remarks>
        public static mdToken[] EnumMembers(this MetaDataImport metaDataImport, mdTypeDef cl)
        {
            IntPtr hEnum = IntPtr.Zero;
            metaDataImport.EnumMembers(ref hEnum, cl, null);

            try
            {
                var count = metaDataImport.CountEnum(hEnum);

                var buffer = new mdToken[count];

                metaDataImport.EnumMembers(ref hEnum, cl, buffer);

                return buffer;
            }
            finally
            {
                metaDataImport.CloseEnum(hEnum);
            }
        }

        /// <summary>
        /// Enumerates MemberDef tokens representing members of the specified type with the specified name.
        /// </summary>
        /// <param name="metaDataImport">The <see cref="MetaDataImport"/> to use to enumerate the tokens.</param>
        /// <param name="cl">[in] A TypeDef token representing the type with members to enumerate.</param>
        /// <param name="szName">[in] The member name that limits the scope of the enumerator.</param>
        /// <returns>The array used to store the MemberDef tokens.</returns>
        /// <remarks>
        /// This method enumerates fields and methods, but not properties or events. Unlike <see cref="EnumMembers"/>, EnumMembersWithName
        /// discards all field and member tokens that do not have the specified name.
        /// </remarks>
        public static mdToken[] EnumMembersWithName(this MetaDataImport metaDataImport, mdTypeDef cl, string szName)
        {
            IntPtr hEnum = IntPtr.Zero;
            metaDataImport.EnumMembersWithName(ref hEnum, cl, szName, null);

            try
            {
                var count = metaDataImport.CountEnum(hEnum);

                var buffer = new mdToken[count];

                metaDataImport.EnumMembersWithName(ref hEnum, cl, szName, buffer);

                return buffer;
            }
            finally
            {
                metaDataImport.CloseEnum(hEnum);
            }
        }

        /// <summary>
        /// Enumerates MethodDef tokens representing methods of the specified type.
        /// </summary>
        /// <param name="metaDataImport">The <see cref="MetaDataImport"/> to use to enumerate the tokens.</param>
        /// <param name="cl">[in] A TypeDef token representing the type with the methods to enumerate.</param>
        /// <returns>The array to store the MethodDef tokens.</returns>
        public static mdMethodDef[] EnumMethods(this MetaDataImport metaDataImport, mdTypeDef cl)
        {
            IntPtr hEnum = IntPtr.Zero;
            metaDataImport.EnumMethods(ref hEnum, cl, null);

            try
            {
                var count = metaDataImport.CountEnum(hEnum);

                var buffer = new mdMethodDef[count];

                metaDataImport.EnumMethods(ref hEnum, cl, buffer);

                return buffer;
            }
            finally
            {
                metaDataImport.CloseEnum(hEnum);
            }
        }

        /// <summary>
        /// Enumerates methods that have the specified name and that are defined by the type referenced by the specified TypeDef token.
        /// </summary>
        /// <param name="metaDataImport">The <see cref="MetaDataImport"/> to use to enumerate the tokens.</param>
        /// <param name="cl">[in] A TypeDef token representing the type whose methods to enumerate.</param>
        /// <param name="szName">[in] The name that limits the scope of the enumeration.</param>
        /// <returns>The array used to store the MethodDef tokens.</returns>
        /// <remarks>
        /// This method enumerates fields and methods, but not properties or events. Unlike <see cref="EnumMethods"/>, EnumMethodsWithName
        /// discards all method tokens that do not have the specified name.
        /// </remarks>
        public static mdMethodDef[] EnumMethodsWithName(this MetaDataImport metaDataImport, mdTypeDef cl, string szName)
        {
            IntPtr hEnum = IntPtr.Zero;
            metaDataImport.EnumMethodsWithName(ref hEnum, cl, szName, null);

            try
            {
                var count = metaDataImport.CountEnum(hEnum);

                var buffer = new mdMethodDef[count];

                metaDataImport.EnumMethodsWithName(ref hEnum, cl, szName, buffer);

                return buffer;
            }
            finally
            {
                metaDataImport.CloseEnum(hEnum);
            }
        }

        /// <summary>
        /// Enumerates FieldDef tokens for the type referenced by the specified TypeDef token.
        /// </summary>
        /// <param name="metaDataImport">The <see cref="MetaDataImport"/> to use to enumerate the tokens.</param>
        /// <param name="cl">[in] The TypeDef token of the class whose fields are to be enumerated.</param>
        /// <returns>The list of FieldDef tokens.</returns>
        public static mdFieldDef[] EnumFields(this MetaDataImport metaDataImport, mdTypeDef cl)
        {
            IntPtr hEnum = IntPtr.Zero;
            metaDataImport.EnumFields(ref hEnum, cl, null);

            try
            {
                var count = metaDataImport.CountEnum(hEnum);

                var buffer = new mdFieldDef[count];

                metaDataImport.EnumFields(ref hEnum, cl, buffer);

                return buffer;
            }
            finally
            {
                metaDataImport.CloseEnum(hEnum);
            }
        }

        /// <summary>
        /// Enumerates FieldDef tokens of the specified type with the specified name.
        /// </summary>
        /// <param name="metaDataImport">The <see cref="MetaDataImport"/> to use to enumerate the tokens.</param>
        /// <param name="cl">[in] The token of the type whose fields are to be enumerated.</param>
        /// <param name="szName">[in] The field name that limits the scope of the enumeration.</param>
        /// <returns>Array used to store the FieldDef tokens.</returns>
        /// <remarks>
        /// Unlike <see cref="EnumFields"/>, EnumFieldsWithName discards all field tokens that do not have the specified name.
        /// </remarks>
        public static mdFieldDef[] EnumFieldsWithName(this MetaDataImport metaDataImport, mdTypeDef cl, string szName)
        {
            IntPtr hEnum = IntPtr.Zero;
            metaDataImport.EnumFieldsWithName(ref hEnum, cl, szName, null);

            try
            {
                var count = metaDataImport.CountEnum(hEnum);

                var buffer = new mdFieldDef[count];

                metaDataImport.EnumFieldsWithName(ref hEnum, cl, szName, buffer);

                return buffer;
            }
            finally
            {
                metaDataImport.CloseEnum(hEnum);
            }
        }

        /// <summary>
        /// Enumerates ParamDef tokens representing the parameters of the method referenced by the specified MethodDef token.
        /// </summary>
        /// <param name="metaDataImport">The <see cref="MetaDataImport"/> to use to enumerate the tokens.</param>
        /// <param name="mb">[in] A MethodDef token representing the method with the parameters to enumerate.</param>
        /// <returns>The array used to store the ParamDef tokens.</returns>
        public static mdParamDef[] EnumParams(this MetaDataImport metaDataImport, mdMethodDef mb)
        {
            IntPtr hEnum = IntPtr.Zero;
            metaDataImport.EnumParams(ref hEnum, mb, null);

            try
            {
                var count = metaDataImport.CountEnum(hEnum);

                var buffer = new mdParamDef[count];

                metaDataImport.EnumParams(ref hEnum, mb, buffer);

                return buffer;
            }
            finally
            {
                metaDataImport.CloseEnum(hEnum);
            }
        }

        /// <summary>
        /// Enumerates MemberRef tokens representing members of the specified type.
        /// </summary>
        /// <param name="metaDataImport">The <see cref="MetaDataImport"/> to use to enumerate the tokens.</param>
        /// <param name="tkParent">[in] A TypeDef, TypeRef, MethodDef, or ModuleRef token for the type whose members are to be enumerated.</param>
        /// <returns>The array used to store MemberRef tokens.</returns>
        public static mdMemberRef[] EnumMemberRefs(this MetaDataImport metaDataImport, mdToken tkParent)
        {
            IntPtr hEnum = IntPtr.Zero;
            metaDataImport.EnumMemberRefs(ref hEnum, tkParent, null);

            try
            {
                var count = metaDataImport.CountEnum(hEnum);

                var buffer = new mdMemberRef[count];

                metaDataImport.EnumMemberRefs(ref hEnum, tkParent, buffer);

                return buffer;
            }
            finally
            {
                metaDataImport.CloseEnum(hEnum);
            }
        }

        /// <summary>
        /// Enumerates MethodBody and MethodDeclaration tokens representing methods of the specified type.
        /// </summary>
        /// <param name="metaDataImport">The <see cref="MetaDataImport"/> to use to enumerate the tokens.</param>
        /// <param name="td">[in] A TypeDef token for the type whose method implementations to enumerate.</param>
        /// <returns>A value that stores the array of MethodBody and MethodDeclaration tokens.</returns>
        public static EnumMethodImplsResult EnumMethodImpls(this MetaDataImport metaDataImport, mdTypeDef td)
        {
            IntPtr hEnum = IntPtr.Zero;
            metaDataImport.EnumMethodImpls(ref hEnum, td, null, null);

            try
            {
                var count = metaDataImport.CountEnum(hEnum);

                var methodBody = new mdToken[count];
                var methodDecl = new mdToken[count];

                metaDataImport.EnumMethodImpls(ref hEnum, td, methodBody, methodDecl);

                return new EnumMethodImplsResult(methodBody, methodDecl);
            }
            finally
            {
                metaDataImport.CloseEnum(hEnum);
            }
        }

        /// <summary>
        /// Enumerates permissions for the objects in a specified metadata scope.
        /// </summary>
        /// <param name="metaDataImport">The <see cref="MetaDataImport"/> to use to enumerate the tokens.</param>
        /// <param name="tk">[in] A metadata token that limits the scope of the search, or NULL to search the widest scope possible.</param>
        /// <param name="dwActions">[in] Flags representing the security action values to include in rPermission, or zero to return all actions.</param>
        /// <returns>The array used to store the Permission tokens.</returns>
        public static mdPermission[] EnumPermissionSets(this MetaDataImport metaDataImport, mdToken tk, CorDeclSecurity dwActions)
        {
            IntPtr hEnum = IntPtr.Zero;
            metaDataImport.EnumPermissionSets(ref hEnum, tk, dwActions, null);

            try
            {
                var count = metaDataImport.CountEnum(hEnum);

                var buffer = new mdPermission[count];

                metaDataImport.EnumPermissionSets(ref hEnum, tk, dwActions, buffer);

                return buffer;
            }
            finally
            {
                metaDataImport.CloseEnum(hEnum);
            }
        }

        /// <summary>
        /// Enumerates PropertyDef tokens representing the properties of the type referenced by the specified TypeDef token.
        /// </summary>
        /// <param name="metaDataImport">The <see cref="MetaDataImport"/> to use to enumerate the tokens.</param>
        /// <param name="td">[in] A TypeDef token representing the type with properties to enumerate.</param>
        /// <returns>The array used to store the PropertyDef tokens.</returns>
        public static mdProperty[] EnumProperties(this MetaDataImport metaDataImport, mdTypeDef td)
        {
            IntPtr hEnum = IntPtr.Zero;
            metaDataImport.EnumProperties(ref hEnum, td, null);

            try
            {
                var count = metaDataImport.CountEnum(hEnum);

                var buffer = new mdProperty[count];

                metaDataImport.EnumProperties(ref hEnum, td, buffer);

                return buffer;
            }
            finally
            {
                metaDataImport.CloseEnum(hEnum);
            }
        }

        /// <summary>
        /// Enumerates event definition tokens for the specified TypeDef token.
        /// </summary>
        /// <param name="metaDataImport">The <see cref="MetaDataImport"/> to use to enumerate the tokens.</param>
        /// <param name="td">[in] The TypeDef token whose event definitions are to be enumerated.</param>
        /// <returns>The array of returned events.</returns>
        public static mdEvent[] EnumEvents(this MetaDataImport metaDataImport, mdTypeDef td)
        {
            IntPtr hEnum = IntPtr.Zero;
            metaDataImport.EnumEvents(ref hEnum, td, null);

            try
            {
                var count = metaDataImport.CountEnum(hEnum);

                var buffer = new mdEvent[count];

                metaDataImport.EnumEvents(ref hEnum, td, buffer);

                return buffer;
            }
            finally
            {
                metaDataImport.CloseEnum(hEnum);
            }
        }

        /// <summary>
        /// Enumerates the properties and the property-change events to which the specified method is related.
        /// </summary>
        /// <param name="metaDataImport">The <see cref="MetaDataImport"/> to use to enumerate the tokens.</param>
        /// <param name="mb">[in] A MethodDef token that limits the scope of the enumeration.</param>
        /// <returns>The array used to store the events or properties.</returns>
        /// <remarks>
        /// Many common language runtime types define PropertyChanged events and OnPropertyChanged methods related to their
        /// properties. For example, the System.Windows.Forms.Control type defines a System.Windows.Forms.Control.Font property,
        /// a System.Windows.Forms.Control.FontChanged event, and an System.Windows.Forms.Control.OnFontChanged method. The
        /// set accessor method of the System.Windows.Forms.Control.Font property calls System.Windows.Forms.Control.OnFontChanged
        /// method, which in turn raises the System.Windows.Forms.Control.FontChanged event. You would call EnumMethodSemantics
        /// using the MethodDef for System.Windows.Forms.Control.OnFontChanged to get references to the System.Windows.Forms.Control.Font
        /// property and the System.Windows.Forms.Control.FontChanged event.
        /// </remarks>
        public static mdToken[] EnumMethodSemantics(this MetaDataImport metaDataImport, mdMethodDef mb)
        {
            IntPtr hEnum = IntPtr.Zero;
            metaDataImport.EnumMethodSemantics(ref hEnum, mb, null);

            try
            {
                var count = metaDataImport.CountEnum(hEnum);

                var buffer = new mdToken[count];

                metaDataImport.EnumMethodSemantics(ref hEnum, mb, buffer);

                return buffer;
            }
            finally
            {
                metaDataImport.CloseEnum(hEnum);
            }
        }

        /// <summary>
        /// Enumerates ModuleRef tokens that represent imported modules.
        /// </summary>
        /// <param name="metaDataImport">The <see cref="MetaDataImport"/> to use to enumerate the tokens.</param>
        /// <returns>The array used to store the ModuleRef tokens.</returns>
        public static mdModuleRef[] EnumModuleRefs(this MetaDataImport metaDataImport)
        {
            IntPtr hEnum = IntPtr.Zero;
            metaDataImport.EnumModuleRefs(ref hEnum, null);

            try
            {
                var count = metaDataImport.CountEnum(hEnum);

                var buffer = new mdModuleRef[count];

                metaDataImport.EnumModuleRefs(ref hEnum, buffer);

                return buffer;
            }
            finally
            {
                metaDataImport.CloseEnum(hEnum);
            }
        }

        /// <summary>
        /// Enumerates MemberDef tokens representing the unresolved methods in the current metadata scope.
        /// </summary>
        /// <param name="metaDataImport">The <see cref="MetaDataImport"/> to use to enumerate the tokens.</param>
        /// <returns>The array used to store the MemberDef tokens.</returns>
        /// <remarks>
        /// An unresolved method is one that has been declared but not implemented. A method is included in the enumeration
        /// if the method is marked miForwardRef and either mdPinvokeImpl or miRuntime is set to zero. In other words, an unresolved
        /// method is a class method that is marked miForwardRef but which is not implemented in unmanaged code (reached via
        /// PInvoke) nor implemented internally by the runtime itself The enumeration excludes all methods that are defined
        /// either at module scope (globals) or in interfaces or abstract classes.
        /// </remarks>
        public static mdToken[] EnumUnresolvedMethods(this MetaDataImport metaDataImport)
        {
            IntPtr hEnum = IntPtr.Zero;
            metaDataImport.EnumUnresolvedMethods(ref hEnum, null);

            try
            {
                var count = metaDataImport.CountEnum(hEnum);

                var buffer = new mdToken[count];

                metaDataImport.EnumUnresolvedMethods(ref hEnum, buffer);

                return buffer;
            }
            finally
            {
                metaDataImport.CloseEnum(hEnum);
            }
        }

        /// <summary>
        /// Enumerates Signature tokens representing stand-alone signatures in the current scope.
        /// </summary>
        /// <param name="metaDataImport">The <see cref="MetaDataImport"/> to use to enumerate the tokens.</param>
        /// <returns>The array used to store the Signature tokens.</returns>
        /// <remarks>
        /// The Signature tokens are created by the <see cref="MetaDataEmit.GetTokenFromSig"/> method.
        /// </remarks>
        public static mdSignature[] EnumSignatures(this MetaDataImport metaDataImport)
        {
            IntPtr hEnum = IntPtr.Zero;
            metaDataImport.EnumSignatures(ref hEnum, null);

            try
            {
                var count = metaDataImport.CountEnum(hEnum);

                var buffer = new mdSignature[count];

                metaDataImport.EnumSignatures(ref hEnum, buffer);

                return buffer;
            }
            finally
            {
                metaDataImport.CloseEnum(hEnum);
            }
        }

        /// <summary>
        /// Enumerates TypeSpec tokens defined in the current metadata scope.
        /// </summary>
        /// <param name="metaDataImport">The <see cref="MetaDataImport"/> to use to enumerate the tokens.</param>
        /// <returns>The array used to store the TypeSpec tokens.</returns>
        /// <remarks>
        /// The TypeSpec tokens are created by the <see cref="MetaDataEmit.GetTokenFromTypeSpec"/> method.
        /// </remarks>
        public static mdTypeSpec[] EnumTypeSpecs(this MetaDataImport metaDataImport)
        {
            IntPtr hEnum = IntPtr.Zero;
            metaDataImport.EnumTypeSpecs(ref hEnum, null);

            try
            {
                var count = metaDataImport.CountEnum(hEnum);

                var buffer = new mdTypeSpec[count];

                metaDataImport.EnumTypeSpecs(ref hEnum, buffer);

                return buffer;
            }
            finally
            {
                metaDataImport.CloseEnum(hEnum);
            }
        }

        /// <summary>
        /// Enumerates String tokens representing hard-coded strings in the current metadata scope.
        /// </summary>
        /// <param name="metaDataImport">The <see cref="MetaDataImport"/> to use to enumerate the tokens.</param>
        /// <returns>The array used to store the String tokens.</returns>
        /// <remarks>
        /// The String tokens are created by the <see cref="MetaDataEmit.DefineUserString"/> method. This method is designed
        /// to be used by a metadata browser rather than by a compiler.
        /// </remarks>
        public static mdString[] EnumUserStrings(this MetaDataImport metaDataImport)
        {
            IntPtr hEnum = IntPtr.Zero;
            metaDataImport.EnumUserStrings(ref hEnum, null);

            try
            {
                var count = metaDataImport.CountEnum(hEnum);

                var buffer = new mdString[count];

                metaDataImport.EnumUserStrings(ref hEnum, buffer);

                return buffer;
            }
            finally
            {
                metaDataImport.CloseEnum(hEnum);
            }
        }

        /// <summary>
        /// Enumerates custom attribute-definition tokens associated with the specified type or member.
        /// </summary>
        /// <param name="metaDataImport">The <see cref="MetaDataImport"/> to use to enumerate the tokens.</param>
        /// <param name="tk">[in] A token for the scope of the enumeration, or zero for all custom attributes.</param>
        /// <param name="tkType">[in] A token for the constructor of the type of the attributes to be enumerated, or null for all types.</param>
        /// <returns>An array of custom attribute tokens.</returns>
        public static mdCustomAttribute[] EnumCustomAttributes(this MetaDataImport metaDataImport, mdToken tk, mdToken tkType)
        {
            IntPtr hEnum = IntPtr.Zero;
            metaDataImport.EnumCustomAttributes(ref hEnum, tk, tkType, null);

            try
            {
                var count = metaDataImport.CountEnum(hEnum);

                var buffer = new mdCustomAttribute[count];

                metaDataImport.EnumCustomAttributes(ref hEnum, tk, tkType, buffer);

                return buffer;
            }
            finally
            {
                metaDataImport.CloseEnum(hEnum);
            }
        }

        /// <summary>
        /// Gets an enumerator for an array of generic parameter tokens associated with the specified TypeDef or MethodDef token.
        /// </summary>
        /// <param name="metaDataImport">The <see cref="MetaDataImport"/> to use to enumerate the tokens.</param>
        /// <param name="tk">[in] The TypeDef or MethodDef token whose generic parameters are to be enumerated.</param>
        /// <returns>The array of generic parameters to enumerate.</returns>
        public static mdGenericParam[] EnumGenericParams(this MetaDataImport metaDataImport, mdToken tk)
        {
            IntPtr hEnum = IntPtr.Zero;
            metaDataImport.EnumGenericParams(ref hEnum, tk, null);

            try
            {
                var count = metaDataImport.CountEnum(hEnum);

                var buffer = new mdGenericParam[count];

                metaDataImport.EnumGenericParams(ref hEnum, tk, buffer);

                return buffer;
            }
            finally
            {
                metaDataImport.CloseEnum(hEnum);
            }
        }

        /// <summary>
        /// Gets an enumerator for an array of generic parameter constraints associated with the generic parameter represented by the specified token.
        /// </summary>
        /// <param name="metaDataImport">The <see cref="MetaDataImport"/> to use to enumerate the tokens.</param>
        /// <param name="tk">[in] A token that represents the generic parameter whose constraints are to be enumerated.</param>
        /// <returns>The array of generic parameter constraints to enumerate.</returns>
        public static mdGenericParamConstraint[] EnumGenericParamConstraints(this MetaDataImport metaDataImport, mdGenericParam tk)
        {
            IntPtr hEnum = IntPtr.Zero;
            metaDataImport.EnumGenericParamConstraints(ref hEnum, tk, null);

            try
            {
                var count = metaDataImport.CountEnum(hEnum);

                var buffer = new mdGenericParamConstraint[count];

                metaDataImport.EnumGenericParamConstraints(ref hEnum, tk, buffer);

                return buffer;
            }
            finally
            {
                metaDataImport.CloseEnum(hEnum);
            }
        }

        /// <summary>
        /// Gets an enumerator for an array of MethodSpec tokens associated with the specified MethodDef or MemberRef token.
        /// </summary>
        /// <param name="metaDataImport">The <see cref="MetaDataImport"/> to use to enumerate the tokens.</param>
        /// <param name="tk">[in] The MemberRef or MethodDef token that represents the method whose MethodSpec tokens are to be enumerated. If the value of tk is 0 (zero), all MethodSpec tokens in the scope will be enumerated.</param>
        /// <returns>The array of MethodSpec tokens to enumerate.</returns>
        public static mdMethodSpec[] EnumMethodSpecs(this MetaDataImport metaDataImport, mdToken tk)
        {
            IntPtr hEnum = IntPtr.Zero;
            metaDataImport.EnumMethodSpecs(ref hEnum, tk, null);

            try
            {
                var count = metaDataImport.CountEnum(hEnum);

                var buffer = new mdMethodSpec[count];

                metaDataImport.EnumMethodSpecs(ref hEnum, tk, buffer);

                return buffer;
            }
            finally
            {
                metaDataImport.CloseEnum(hEnum);
            }
        }
    }

    /// <summary>
    /// Encapsulates the results of the <see cref="MetaDataImport.EnumMethodImpls"/> method.
    /// </summary>
    [DebuggerDisplay("rMethodBody = {rMethodBody}, rMethodDecl = {rMethodDecl}")]
    public struct EnumMethodImplsResult
    {
        /// <summary>
        /// The array to store the MethodBody tokens.
        /// </summary>
        public mdToken[] rMethodBody { get; }

        /// <summary>
        /// The array to store the MethodDeclaration tokens.
        /// </summary>
        public mdToken[] rMethodDecl { get; }

        public EnumMethodImplsResult(mdToken[] rMethodBody, mdToken[] rMethodDecl)
        {
            this.rMethodBody = rMethodBody;
            this.rMethodDecl = rMethodDecl;
        }
    }
}
