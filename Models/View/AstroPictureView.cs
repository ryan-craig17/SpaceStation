namespace SpaceStation.Models.View
{
    public class AstroPictureView : BaseResponse
    {
        public Uri? Url { get; set; }
        public Uri? HDurl { get; set; }
        public DateTime Date { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
    }
}
