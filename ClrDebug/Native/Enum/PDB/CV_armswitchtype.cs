namespace ClrDebug.PDB
{
    public enum CV_armswitchtype
    {
        CV_SWT_INT1 = 0,
        CV_SWT_UINT1 = 1,
        CV_SWT_INT2 = 2,
        CV_SWT_UINT2 = 3,
        CV_SWT_INT4 = 4,
        CV_SWT_UINT4 = 5,
        CV_SWT_POINTER = 6,
        CV_SWT_UINT1SHL1 = 7,
        CV_SWT_UINT2SHL1 = 8,
        CV_SWT_INT1SHL1 = 9,
        CV_SWT_INT2SHL1 = 10,
        CV_SWT_TBB = CV_SWT_UINT1SHL1,
        CV_SWT_TBH = CV_SWT_UINT2SHL1,
    }
}
