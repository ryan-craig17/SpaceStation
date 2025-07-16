using SpaceStation.Extensions;
using SpaceStation.Models.Domain;
using SpaceStation.Models.View;

namespace SpaceStation.Mappers
{
    public class NasaMapper
    {
        public static AstroPictureView DomainToView(AstroPicture astroPicture)
        {
            var result = new AstroPictureView
            {
                Description = astroPicture.explanation,
                Url = astroPicture.url.ToUriOrNull(),
                HDurl = astroPicture.hdurl.ToUriOrNull(),
                Title = astroPicture.title,
                IsErrorResponse = astroPicture.IsErrorResponse,
                ErrorMessage = astroPicture.ErrorMessage,
                StatusCode = astroPicture.StatusCode,
                Date = DateTime.TryParse(astroPicture.date, out var theDate) ? theDate : DateTime.UtcNow
            };

            return result;
        }

        public static MarsRoverPhotoView DomainToView(MarsRoverPhotos marsRoverPhotos)
        {
            var result = new MarsRoverPhotoView
            {
                MarsPhotos = new List<MarsPhotoItem>(),
                IsErrorResponse = marsRoverPhotos.IsErrorResponse,
                StatusCode = marsRoverPhotos.StatusCode,
            };

            if (marsRoverPhotos?.photos is not null)
            {
                foreach (var photo in marsRoverPhotos.photos)
                {
                    var photoItem = new MarsPhotoItem
                    {
                        Id = photo.id,
                        MarsSol = photo.sol,
                        ImageURL = photo.img_src.ToUriOrNull(),
                        EarthDate = DateTime.TryParse(photo.earth_date, out var theDate) ? theDate : DateTime.UtcNow,
                        CameraName = photo.camera.name,
                        RoverName = photo.rover.name,
                    };

                    result.MarsPhotos.Add(photoItem);
                }
            }

            return result;
        }
    }
}
