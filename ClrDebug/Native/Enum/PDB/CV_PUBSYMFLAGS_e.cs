namespace ClrDebug.PDB
{
    public enum CV_PUBSYMFLAGS_e
    {
        cvpsfNone = 0,
        cvpsfCode = 0x00000001,
        cvpsfFunction = 0x00000002,
        cvpsfManaged = 0x00000004,
        cvpsfMSIL = 0x00000008,
    }
}
