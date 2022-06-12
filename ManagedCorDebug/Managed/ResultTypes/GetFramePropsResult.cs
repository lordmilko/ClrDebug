namespace ManagedCorDebug
{
    public struct GetFramePropsResult
    {
        public int PCodeStartRva { get; }

        public int PParentFrameStartRva { get; }

        public GetFramePropsResult(int pCodeStartRva, int pParentFrameStartRva)
        {
            PCodeStartRva = pCodeStartRva;
            PParentFrameStartRva = pParentFrameStartRva;
        }
    }
}