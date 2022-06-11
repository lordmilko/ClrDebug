namespace ManagedCorDebug
{
    public struct GetFramePropsResult
    {
        public uint PCodeStartRva { get; }

        public uint PParentFrameStartRva { get; }

        public GetFramePropsResult(uint pCodeStartRva, uint pParentFrameStartRva)
        {
            PCodeStartRva = pCodeStartRva;
            PParentFrameStartRva = pParentFrameStartRva;
        }
    }
}