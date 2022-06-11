namespace ManagedCorDebug
{
    public struct GetGenericParamConstraintPropsResult
    {
        public mdGenericParam PtGenericParam { get; }

        public mdToken PtkConstraintType { get; }

        public GetGenericParamConstraintPropsResult(mdGenericParam ptGenericParam, mdToken ptkConstraintType)
        {
            PtGenericParam = ptGenericParam;
            PtkConstraintType = ptkConstraintType;
        }
    }
}