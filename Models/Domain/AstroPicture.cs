namespace SpaceStation.Models.Domain
{
    public class AstroPicture : BaseResponse
    {
        public string copyright { get; set; } = string.Empty;
        public string date { get; set; } = string.Empty;
        public string explanation { get; set; } = string.Empty;
        public string hdurl { get; set; } = string.Empty;
        public string media_type { get; set; } = string.Empty;
        public string service_version { get; set; } = string.Empty;
        public string title { get; set; } = string.Empty;
        public string url { get; set; } = string.Empty;
        public string msg { get; set; } = string.Empty;
    }
}
