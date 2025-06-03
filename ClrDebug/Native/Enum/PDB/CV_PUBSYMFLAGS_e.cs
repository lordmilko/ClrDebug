namespace ClrDebug.PDB
{
    //There are 3 definitions of pub sym flags. CV_pubsymflag_t, CV_PUBSYMFLAGS and CV_PUBSYMFLAGS_e
    public enum CV_PUBSYMFLAGS_e
    {
        cvpsfNone = 0,
        cvpsfCode = 0x00000001,
        cvpsfFunction = 0x00000002,
        cvpsfManaged = 0x00000004,
        cvpsfMSIL = 0x00000008,
    }
}
