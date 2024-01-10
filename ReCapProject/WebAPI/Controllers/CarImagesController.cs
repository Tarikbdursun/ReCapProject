using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarImagesController : ControllerBase
    {
        ICarImageService _carImageService;
        public CarImagesController(ICarImageService carImageService)
        {
            _carImageService = carImageService;
        }

        // ADD, DELETE, UPDATE, GETALL, GETBYID,
        [HttpPost("add")]
        public IActionResult Add([FromForm] IFormFile file,[FromForm]CarImage carImage)
        {
            var result = _carImageService.AddCarImage(file,carImage);

            return result.Success ? Ok() : BadRequest();
        }

        [HttpPost("delete")]
        public IActionResult Delete(CarImage carImage)
        {
            var result = _carImageService.DeleteCarImage(carImage);

            return result.Success ? Ok() : BadRequest();
        }

        [HttpPost("update")]
        public IActionResult Update([FromForm] IFormFile file, [FromForm] CarImage carImage)
        {
            var result = _carImageService.UpdateCarImage(file,carImage);

            return result.Success ? Ok() : BadRequest();
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _carImageService.GetAll();
            return result.Success ? Ok() : BadRequest();
        }

        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            var result = _carImageService.GetById(id);
            return result.Success ? Ok() : BadRequest();
        }
        
        [HttpGet("getimagesbycarid")]
        public IActionResult GetImagesByCarId(int carId)
        {
            var result = _carImageService.GetImagesByCarId(carId);
            return result.Success ? Ok() : BadRequest();
        }
    }
}
