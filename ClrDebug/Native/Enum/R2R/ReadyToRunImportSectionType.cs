namespace ClrDebug
{
    public enum ReadyToRunImportSectionType : byte
    {
        Unknown      = 0,
        StubDispatch = 2,
        StringHandle = 3,
        ILBodyFixups = 7,
    }
}
