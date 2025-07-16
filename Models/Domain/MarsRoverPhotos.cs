
namespace SpaceStation.Models.Domain
{
    public class MarsRoverPhotos : BaseResponse
    {
        public IEnumerable<MarsRoverPhoto>? photos { get; set; }
    }

    public class MarsRoverCamera
    {
        public int id { get; set; }
        public string name { get; set; } = string.Empty;
        public int rover_id { get; set; }
        public string full_name { get; set; } = string.Empty;
    }

    public class MarsRover
    {
        public int id { get; set; }
        public string name { get; set; } = string.Empty;
        public string landing_date { get; set; } = string.Empty;
        public string launch_date { get; set; } = string.Empty;
        public string status { get; set; } = string.Empty;
    }

    public class MarsRoverPhoto
    {
        public int id { get; set; }
        public int sol { get; set; }
        public MarsRoverCamera? camera { get; set; }
        public string img_src { get; set; } = string.Empty;
        public string earth_date { get; set; } = string.Empty;
        public MarsRover? rover { get; set; }
    }
}

