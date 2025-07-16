using SpaceStation.Models.View;

namespace SpaceStation.Interfaces
{
    public interface INasaLogic
    {
        public Task<AstroPictureView> GetAstronomyPictureURL(DateTime? pictureDate);
        public Task<MarsRoverPhotoView> GetMarsRoverPhotos(DateTime? earthDate);
    }
}
