namespace ClrDebug.DbgEng
{
    /// <summary>
    /// Describes what an <see cref="IModelObject"/> is intrinsically.
    /// </summary>
    public enum ModelObjectKind : uint
    {
        ObjectPropertyAccessor,
        ObjectContext,
        ObjectTargetObject,
        ObjectTargetObjectReference,
        ObjectSynthetic,
        ObjectNoValue,
        ObjectError,
        ObjectIntrinsic,
        ObjectMethod,
        ObjectKeyReference
    }
}
