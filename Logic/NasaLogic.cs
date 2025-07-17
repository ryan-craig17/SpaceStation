using Microsoft.Extensions.Options;
using SpaceStation.Interfaces;
using SpaceStation.Mappers;
using SpaceStation.Models;
using SpaceStation.Models.Domain;
using SpaceStation.Models.View;

namespace SpaceStation.Logic
{
    public class NasaLogic : INasaLogic
    {
        private IRestWorker _restWorker { get; set; }
        private Settings _settings { get; set; }
        private string url_domain { get; set; }
        private string apiKey_Nasa { get; set; }

        public NasaLogic(IRestWorker restWorker, IOptions<Settings> settings)
        {
            _restWorker = restWorker;
            _settings = settings.Value;

            url_domain = _settings.EnvironmentValues.NASA_API_URL;
            apiKey_Nasa = _settings.EnvironmentValues.NASA_API_Key;
        }

        public async Task<AstroPictureView> GetAstronomyPictureURL(DateTime? pictureDate)
        {
            var url_path = string.Format(_settings.StaticValues.NasaResources.APOD, $"{pictureDate:yyyy-MM-dd}", apiKey_Nasa);
            var url = new Uri(new Uri(url_domain), url_path);

            var response = await _restWorker.CallService<AstroPicture>(url);
            var result = NasaMapper.DomainToView(response);

            return result;
        }

        public async Task<MarsRoverPhotoView> GetMarsRoverPhotos(DateTime? earthDate)
        {
            var photoDate = earthDate ?? DateTime.UtcNow;
            var url_path = string.Format(_settings.StaticValues.NasaResources.MarsRoverPhotos, $"{photoDate:yyyy-MM-dd}", apiKey_Nasa);
            var url = new Uri(new Uri(url_domain), url_path);

            var response = await _restWorker.CallService<MarsRoverPhotos>(url);
            var result = NasaMapper.DomainToView(response);

            return result;
        }

        public async Task<NearEarthObjectView> GetNearEarthObject(int id)
        {
            var url_path = string.Format(_settings.StaticValues.NasaResources.AsteroidLookup, id, apiKey_Nasa);
            var url = new Uri(new Uri(url_domain), url_path);

            var response = await _restWorker.CallService<NearEarthObject>(url);
            var result = NasaMapper.DomainToView(response);

            return result;
        }

        public async Task<NearEarthObjectListView> BrowseNearEarthObjects(int pageNumber, int pageSize)
        {
            var url_path = string.Format(_settings.StaticValues.NasaResources.AsteroidBrowse, pageNumber, pageSize, apiKey_Nasa);
            var url = new Uri(new Uri(url_domain), url_path);

            var response = await _restWorker.CallService<NearEarthObjectList>(url);
            var result = NasaMapper.DomainToView(response);

            return result;
        }
    }
}
