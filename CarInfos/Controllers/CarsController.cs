//using CarInfo.Data;
//using CarInfo.Models;
//using CarInfo.Models.Entities;
using CarInfos.Data;
using CarInfos.Models.Entity;
using CarInfos.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CarInfo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        private readonly CarsDbContext dbContext;

        public CarsController(CarsDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        //Get methods
        [HttpGet]
        public IActionResult GetAllCars()
        {
            return Ok(dbContext.Cars.ToList());
        }

        [HttpGet]
        [Route("{id:int}")]
        public IActionResult GetCarsById(int id)
        {
            var car = dbContext.Cars.Find(id);
            if (car is null)
            {
                return NotFound("Check your Car Id, thank you!");
            }
            return Ok(car);
        }
        //Post method
        [HttpPost]
        public IActionResult AddCars(AddCarsDto addCarsDto)
        {
            var carsEntity = new Cars()
            {
                Brand = addCarsDto.Brand,
                Model = addCarsDto.Model,
                Year = addCarsDto.Year,
                Color = addCarsDto.Color,
                Price = addCarsDto.Price,
                Description = addCarsDto.Description,
                Mileage = addCarsDto.Mileage,
                IsAvailable = addCarsDto.IsAvailable,
            };
            dbContext.Cars.Add(carsEntity);
            dbContext.SaveChanges();
            return Ok(carsEntity);
        }
        //Put method
        [HttpPut]
        [Route("{id:int}")]
        public IActionResult UpdateCars(int id, UpdateCarsDto updateCarsDto)
        {
            var cars = dbContext.Cars.Find(id);
            if (cars is null)
            {
                return NotFound("Check your Car Id, thank you!");
            }

            cars.Brand = updateCarsDto.Brand;
            cars.Model = updateCarsDto.Model;
            cars.Year = updateCarsDto.Year;
            cars.Color = updateCarsDto.Color;
            cars.Price = updateCarsDto.Price;
            cars.Description = updateCarsDto.Description;
            cars.Mileage = updateCarsDto.Mileage;
            cars.IsAvailable = updateCarsDto.IsAvailable;

            dbContext.Entry(cars).State = EntityState.Modified;
            dbContext.SaveChanges();
            return Ok(cars);
        }
        //Delete method
        [HttpDelete]
        [Route("{id:int}")]
        public IActionResult DeleteCars(int id)
        {
            var delCars = dbContext.Cars.Find(id);
            if (delCars is null)
            {
                return NotFound("Check your Car Id, thank you!");
            }
            dbContext.Cars.Remove(delCars);
            dbContext.SaveChanges();
            return Ok("Record succefully deleted!");
        }
    }
}