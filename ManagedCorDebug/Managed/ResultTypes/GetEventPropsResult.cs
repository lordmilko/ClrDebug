namespace ManagedCorDebug
{
    public struct GetEventPropsResult
    {
        public mdTypeDef PClass { get; }

        public string SzEvent { get; }

        public uint PdwEventFlags { get; }

        public mdToken PtkEventType { get; }

        public mdMethodDef PmdAddOn { get; }

        public mdMethodDef PmdRemoveOn { get; }

        public mdMethodDef PmdFire { get; }

        public mdMethodDef[] RmdOtherMethod { get; }

        public uint PcOtherMethod { get; }

        public GetEventPropsResult(mdTypeDef pClass, string szEvent, uint pdwEventFlags, mdToken ptkEventType, mdMethodDef pmdAddOn, mdMethodDef pmdRemoveOn, mdMethodDef pmdFire, mdMethodDef[] rmdOtherMethod, uint pcOtherMethod)
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