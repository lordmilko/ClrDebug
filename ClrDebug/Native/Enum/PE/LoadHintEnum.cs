namespace ClrDebug
{
    public enum LoadHintEnum
    {
        LoadDefault = 0x0000, // No preference specified

        LoadAlways = 0x0001, // Dependency is always loaded
        LoadSometimes = 0x0002, // Dependency is sometimes loaded
        LoadNever = 0x0003  // Dependency is never loaded
    }
}