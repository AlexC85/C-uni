using CarService3.BL.Interfaces;
using CarService3.Models.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarService3.Host.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarController : ControllerBase
    {
        private readonly ICarService _carService;
        public CarController(ICarService carService)
        {
            _carService = carService;
        }

        [HttpGet(nameof(GetAllCars))]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public IActionResult GetAllCars()
        {
            var cars = 
                _carService.GetAll();

            if (cars?.Count == 0) return NoContent();
            
            return Ok(cars);
        }


        [HttpGet(nameof(GetCarsById))]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult GetCarsById(Guid id)
        {
          

            var car =
                _carService.GetById(id);

            if (car == null) return NotFound();

            return Ok(car);
        }

        private object GetCarsById()
        {
            throw new NotImplementedException();
        }

        [HttpPost(nameof(AddCar))]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult AddCar([FromBody] Car? car)
        {
            if (car == null)
            {
                return BadRequest("Customer cannot be null.");
            }

            _carService.Add(car);

            return Ok();
        }

        [HttpDelete(nameof(DeleteCar))]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult DeleteCar(Guid id)
        {
           

            _carService.Delete(id);

            return Ok();
        }
    }
}
