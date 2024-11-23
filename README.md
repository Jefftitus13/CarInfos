# CarInfos

CarInfos is a RESTful API built using ASP.NET Core Web API and Entity Framework, designed to provide basic CRUD operations for managing car information. The API allows users to interact with a database of cars, supporting operations such as retrieving car data, adding new cars, updating existing records, and deleting cars.

# Features

- GET all cars: Retrieve a list of all cars in the database.
- GET car by Id: Retrieve a specific car by its unique ID.
- POST car: Add a new car to the database.
- PUT car: Update the details of an existing car by its ID.
- DELETE car: Remove a car from the database using its ID.

# Technologies Used

- ASP.NET Core Web API: A framework for building APIs in .NET.
- Entity Framework Core: An Object-Relational Mapper (ORM) that allows interaction with the database using .NET objects.
- RESTful API: The API adheres to REST principles to provide a stateless communication protocol for interacting with the server.

# API Endpoints

## GET /api/cars
Retrieve a list of all cars in the database.

## Request URL
https://localhost:7254/api/Cars

[
  {
    "id": 1,
    "brand": "Toyota",
    "model": "Supra",
    "year": 1996,
    "color": "Orange",
    "price": 1200000,
    "description": "The Toyota Supra is a high-performance sports car known for its sleek design, powerful engine options, and exceptional handling. It's revered for its turbocharged variants and iconic status in automotive culture.",
    "mileage": 25,
    "isAvailable": true
  },
  {
    "id": 2,
    "brand": "Honda",
    "model": "Civic",
    "year": 2001,
    "color": "Dark blue",
    "price": 400000,
    "description": "Compact, stylish sedan with excellent fuel efficiency, advanced features, and reliable performance.",
    "mileage": 35,
    "isAvailable": true
  },
  {
    "id": 3,
    "brand": "Porsche",
    "model": "911",
    "year": 1999,
    "color": "Yellow",
    "price": 5000000,
    "description": "Luxury sports car offering iconic design, exceptional speed, and superior handling performance.",
    "mileage": 12,
    "isAvailable": false
  },
  {
    "id": 4,
    "brand": "Nissan",
    "model": "GTR",
    "year": 2005,
    "color": "Metal green",
    "price": 350000,
    "description": "High-performance sports car with sleek design, advanced technology, and exceptional speed.",
    "mileage": 30,
    "isAvailable": true
  },
  {
    "id": 5,
    "brand": "Suzuki",
    "model": "Ciaz",
    "year": 2017,
    "color": "Brown",
    "price": 256000,
    "description": "Spacious sedan with elegant design, fuel efficiency, and comfortable interiors.",
    "mileage": 39,
    "isAvailable": false
  },
  {
    "id": 6,
    "brand": "Audi",
    "model": "RS6",
    "year": 1996,
    "color": "Steel black",
    "price": 4200000,
    "description": "High-performance sports sedan with a powerful V8 engine, advanced technology, and dynamic handling, blending luxury with speed.",
    "mileage": 12,
    "isAvailable": true
  },
  {
    "id": 7,
    "brand": "Ford",
    "model": "Mustang",
    "year": 2003,
    "color": "Light green",
    "price": 45000000,
    "description": "Iconic American muscle car with powerful engine options, aggressive styling, and thrilling performance.",
    "mileage": 18,
    "isAvailable": true
  }
]

## GET /api/cars/{id}
Retrieve the details of a specific car by ID.

## Request URL
https://localhost:7254/api/Cars/4

{
  "id": 4,
  "brand": "Nissan",
  "model": "GTR",
  "year": 2005,
  "color": "Metal green",
  "price": 350000,
  "description": "High-performance sports car with sleek design, advanced technology, and exceptional speed.",
  "mileage": 30,
  "isAvailable": true
}

## POST /api/cars
Add a new car to the database.

## Request URL
https://localhost:7254/api/Cars

{
  "id": 9,
  "brand": "BMW",
  "model": "M3 GTR",
  "year": 2007,
  "color": "White with Blue",
  "price": 3500000,
  "description": "The BMW M3 GTR is a high-performance version of the M3 series, known for its powerful V8 engine, aggressive styling, and exceptional handling. It was originally developed for racing and later adapted for the road, offering an unmatched driving experience.",
  "mileage": 23,
  "isAvailable": false
}

## PUT /api/cars/{id}
Update an existing car's details.

## Request URL
https://localhost:7254/api/Cars/4

{
  "id": 4,
  "brand": "Nissan",
  "model": "GTR",
  "year": 2005,
  "color": "Purple",
  "price": 350000,
  "description": "High-performance sports car with sleek design, advanced technology, and exceptional speed.",
  "mileage": 29,
  "isAvailable": true
}

## DELETE /api/cars/{id}
Delete a car from the database by its ID.

## Request URL
https://localhost:7254/api/Cars/5

Record succefully deleted!

# Database Configuration

This project uses Entity Framework Core to interact with the database. Ensure that you have a local SQL Server instance or use the appsettings.json to configure a connection string for your preferred database.

# Contributions

Feel free to fork this repository, open issues, and submit pull requests for enhancements or bug fixes.

