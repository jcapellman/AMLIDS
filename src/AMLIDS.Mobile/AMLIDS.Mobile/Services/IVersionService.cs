namespace AMLIDS.Mobile.Services
{
    public interface IVersionService
    {
        string VersionNumber { get; }

        string BuildNumber { get; }

        string PlatformVersion { get; }

        string ModelName { get; }

        string Manufacturer { get; }

        string Platform { get; }
    }
}
