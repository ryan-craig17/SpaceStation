
namespace SpaceStation.Models
{
    public class AppSettingsModel
    {
        public Settings Settings { get; set; }
    }

    public class  Settings
    {
        public StaticValues StaticValues { get; set; }
        public EnvironmentValues EnvironmentValues { get; set; }
    }

    public class StaticValues
    {
        public string APIname { get; set; }
        public NasaResources NasaResources { get; set; }
        public JwstResources JwstResources { get; set; }
    }

    public class EnvironmentValues
    {
        public string NASA_API_URL { get; set; } = string.Empty;
        public string JWST_API_URL { get; set; } = string.Empty;
        public string NASA_API_Key { get; set; } = string.Empty;
        public string JWST_API_Key { get; set; } = string.Empty;
        public string CorsAllowedSites { get; set; } = string.Empty;
        public Logging Logging { get; set; }
    }

    public class Logging
    {
        public LogLevel LogLevel { get; set; }
    }

    public class LogLevel
    {
        public string Default { get; set; } = string.Empty;
        public string MicrosoftAspNetCore { get; set; } = string.Empty;
    }

    public class NasaResources
    {
        //Astronomy Picture Of the Day = APOD
        public string APOD { get; set; } = string.Empty;
        public string AsteroidList { get; set; } = string.Empty;
        public string AsteroidLookup { get; set; } = string.Empty;
        public string AsteroidBrowse { get; set; } = string.Empty;
        public string MarsRoverPhotos { get; set; } = string.Empty;
    }

    public class JwstResources
    {
        //TODO - fill out
    }
}
