﻿using CarInfos.Data;
using CarInfos.Models.Entity;
using CarInfos.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using System.Text;
using OfficeOpenXml;

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

        #region Get methods
        [HttpGet(Name = "GetCarsInfos")]
        [Authorize]
        public IActionResult GetAllCars()
        {
            return Ok(dbContext.Cars.ToList());
        }

        [HttpGet]
        [Route("{id:int}")]
        [Authorize]
        public IActionResult GetCarsById(int id)
        {
            var car = dbContext.Cars.Find(id);
            if (car is null)
            {
                return NotFound("Check your Car Id, thank you!");
            }
            return Ok(car);
        }

        [HttpGet]
        [Route("export")]
        [Authorize]
        public IActionResult ExportCars([FromQuery] string format = "csv, xlsx")
        {
            var cars = dbContext.Cars.ToList();

            if (!cars.Any())
            {
                return NotFound("There's no car data available to export!");
            }

            switch (format.ToLower())
            {
                case "csv":
                    var csvContent = GenerateCsv(cars);
                    return File(System.Text.Encoding.UTF8.GetBytes(csvContent), "text/csv", "CarsExport.csv");

                case "excel":
                    var excelContent = GenerateExcel(cars);
                    return File(excelContent, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "CarsExport.xlsx");

                default:
                    return BadRequest("Invalid format");
            }
        }
        private string GenerateCsv(IEnumerable<Cars> cars)
        {
            var csvBuilder = new StringBuilder();
            csvBuilder.AppendLine("Id,Brand,Model,Year,Color,Price,Description,Mileage,IsAvailable");
            
            foreach (var car in cars)
            {
                csvBuilder.AppendLine($"{car.Id},{car.Brand},{car.Model},{car.Year},{car.Color},{car.Price},{car.Description},{car.Mileage},{car.IsAvailable}");
            }
            return csvBuilder.ToString();
        }

        private byte[] GenerateExcel(IEnumerable<Cars> cars)
        {
            try
            {
                ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
                using (var package = new ExcelPackage())
                {
                    var worksheet = package.Workbook.Worksheets.Add("Cars");
                    worksheet.Cells[1, 1].Value = "Id";
                    worksheet.Cells[1, 2].Value = "Brand";
                    worksheet.Cells[1, 3].Value = "Model";
                    worksheet.Cells[1, 4].Value = "Year";
                    worksheet.Cells[1, 5].Value = "Color";
                    worksheet.Cells[1, 6].Value = "Price";
                    worksheet.Cells[1, 7].Value = "Description";
                    worksheet.Cells[1, 8].Value = "Mileage";
                    worksheet.Cells[1, 9].Value = "IsAvailable";

                    var row = 2;
                    foreach (var car in cars)
                    {
                        worksheet.Cells[row, 1].Value = car.Id;
                        worksheet.Cells[row, 2].Value = car.Brand;
                        worksheet.Cells[row, 3].Value = car.Model;
                        worksheet.Cells[row, 4].Value = car.Year;
                        worksheet.Cells[row, 5].Value = car.Color;
                        worksheet.Cells[row, 6].Value = car.Price;
                        worksheet.Cells[row, 7].Value = car.Description;
                        worksheet.Cells[row, 8].Value = car.Mileage;
                        worksheet.Cells[row, 9].Value = car.IsAvailable;
                        row++;
                    }

                    return package.GetAsByteArray();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                return Array.Empty<byte>();
            }
        }

        [HttpGet("users/{userId}/favorites")]
        public async Task<IActionResult> GetFavorites(int userId)
        {
            var favorites = await dbContext.Favorites
                                           .Where(f => f.UserId == userId)
                                           .Include(f => f.Car)
                                           .ToListAsync();
            
            if (favorites == null || favorites.Count == 0)
            {
                return NotFound();
            }

            return Ok(favorites.Select(f => f.Car));
        }

        [HttpGet("cars/compare")]
        public async Task<IActionResult> CompareCars([FromQuery] int car1_id, [FromQuery] int car2_id)
        {
            var car1 = await dbContext.Cars.FindAsync(car1_id);
            var car2 = await dbContext.Cars.FindAsync(car2_id);

            if (car1 == null  || car2 == null)
            {
                return NotFound("Either one or both cars not found");
            }

            var comparison = new
            {
                Car1 = new
                {
                    car1.Brand,
                    car1.Model,
                    car1.Year,
                    car1.Price,
                    car1.Mileage,
                    car1.Color
                },
                Car2 = new
                {
                    car2.Brand,
                    car2.Model,
                    car2.Year,
                    car2.Price,
                    car2.Mileage,
                    car2.Color
                }
            };
            
            return Ok(comparison);
        }

        #endregion

        #region Post methods
        [HttpPost]
        [Authorize]
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

        [HttpPost("users/{userId}/favorites")]
        public async Task<IActionResult> AddToFavorites(int userId, [FromBody] int carID)
        {
            var user = await dbContext.Users.FindAsync(userId);
            var car = await dbContext.Cars.FindAsync(carID);

            if (user==null || car==null)
            {
                return NotFound();
            }

            var favorite = new Favorite
            {
                UserId = userId,
                CarId = carID
            };

            dbContext.Favorites.Add(favorite);
            await dbContext.SaveChangesAsync();

            return Ok(favorite);
        }
        #endregion

        #region Put method
        [HttpPut]
        [Route("{id:int}")]
        [Authorize]
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
        #endregion

        #region Delete method
        [HttpDelete]
        [Route("{id:int}")]
        [Authorize]
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
        #endregion
    }
}