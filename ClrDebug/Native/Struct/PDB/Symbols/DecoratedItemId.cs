namespace ClrDebug.PDB
{
    /// <summary>
    /// Combined encoding of TI or FuncId, In compiler implementation Id prefixed by 1 if it is function ID.
    /// </summary>
    public readonly struct DecoratedItemId
    {
        private readonly uint decoratedItemId;

        public bool IsFuncId => (decoratedItemId & 0x80000000) == 0x80000000;

        public CV_ItemId Itemid => (int) (decoratedItemId & 0x7fffffff);

        public DecoratedItemId(bool isFuncId, CV_ItemId inputId)
        {
            if (isFuncId)
            {
                decoratedItemId = 0x80000000 | inputId;
            }
            else
            {
                decoratedItemId = inputId;
            }
        }

        public DecoratedItemId(CV_ItemId encodedId)
        {
            decoratedItemId = encodedId;
        }

        public static implicit operator uint(DecoratedItemId value) => value.decoratedItemId;
    }
}
