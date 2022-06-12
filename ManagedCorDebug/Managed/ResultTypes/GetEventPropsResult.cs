namespace ManagedCorDebug
{
    public struct GetEventPropsResult
    {
        public mdTypeDef PClass { get; }

        public string SzEvent { get; }

        public int PdwEventFlags { get; }

        public mdToken PtkEventType { get; }

        public mdMethodDef PmdAddOn { get; }

        public mdMethodDef PmdRemoveOn { get; }

        public mdMethodDef PmdFire { get; }

        public mdMethodDef[] RmdOtherMethod { get; }

        public int PcOtherMethod { get; }

        public GetEventPropsResult(mdTypeDef pClass, string szEvent, int pdwEventFlags, mdToken ptkEventType, mdMethodDef pmdAddOn, mdMethodDef pmdRemoveOn, mdMethodDef pmdFire, mdMethodDef[] rmdOtherMethod, int pcOtherMethod)
        {
            PClass = pClass;
            SzEvent = szEvent;
            PdwEventFlags = pdwEventFlags;
            PtkEventType = ptkEventType;
            PmdAddOn = pmdAddOn;
            PmdRemoveOn = pmdRemoveOn;
            PmdFire = pmdFire;
            RmdOtherMethod = rmdOtherMethod;
            PcOtherMethod = pcOtherMethod;
        }
    }
}