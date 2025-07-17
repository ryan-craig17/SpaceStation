
namespace SpaceStation.Models.Domain
{
    public class NearEarthObjectList : BaseResponse
    {
        public Links links { get; set; }
        public Page page { get; set; }
        public List<NearEarthObject> near_earth_objects { get; set; }
    }

    public class Links
    {
        public string next { get; set; } = string.Empty;
        public string self { get; set; } = string.Empty;
    }

    public class Page
    {
        public int size { get; set; }
        public int total_elements { get; set; }
        public int total_pages { get; set; }
        public int number { get; set; }
    }


}