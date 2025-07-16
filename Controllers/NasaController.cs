using Microsoft.AspNetCore.Mvc;
using SpaceStation.Interfaces;
using SpaceStation.Models.View;
using System.Net;

namespace SpaceStationAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NasaController : ControllerBase
    {
        private INasaLogic _nasaLogic { get; set; }

        public NasaController(INasaLogic nasaLogic)
        {
            _nasaLogic = nasaLogic;
        }

        [HttpGet]
        [Route("astronomy-picture")]
        [Produces("application/json", Type = typeof(AstroPictureView))]
        public async Task<IActionResult> GetAPOD(DateTime? pictureDate)
        {
            var picture = await _nasaLogic.GetAstronomyPictureURL(pictureDate);
            var resultCode = (int)(picture?.StatusCode ?? HttpStatusCode.InternalServerError);

            return StatusCode(resultCode, picture);
        }

        [HttpGet]
        [Route("mars-rover-photo")]
        [Produces("application/json", Type = typeof(MarsRoverPhotoView))]
        public async Task<IActionResult> GetMarsRoverPhoto(DateTime? earthDate)
        {
            var photo = await _nasaLogic.GetMarsRoverPhotos(earthDate);
            var resultCode = (int)(photo?.StatusCode ?? HttpStatusCode.InternalServerError);

            return StatusCode(resultCode, photo);
        }
    }
}
