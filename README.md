# CarInfos
CarInfos is a RESTful API built using ASP.NET Core Web API and Entity Framework, designed to provide basic CRUD operations for managing car information. The API also supports advanced features like car comparison, exporting data, and secure access through JWT authentication and role-based authorization.

## Features
- **GET all cars**: Retrieve a list of all cars in the database.
- **GET car by ID**: Retrieve a specific car by its unique ID.
- **POST car**: Add a new car to the database.
- **PUT car**: Update the details of an existing car by its ID.
- **DELETE car**: Remove a car from the database using its ID.
- **Compare cars**: Compare details of two cars side-by-side.
- **Download car details**: Export car details in CSV or Excel format.
- **Authentication and Authorization**: Secure API endpoints using token-based authentication and role-based authorization.

## Technologies Used
- **ASP.NET Core Web API**: A framework for building APIs in .NET.
- **Entity Framework Core**: An Object-Relational Mapper (ORM) that enables interaction with the database using .NET objects.
- **JWT Authentication**: Secure token-based authentication mechanism for users.
- **Role-based Authorization**: Control access to specific endpoints based on user roles (e.g., Admin, User).
- **RESTful API**: Adherence to REST principles ensures stateless communication.
- **EPPlus**: A library for generating Excel files.
- **CsvHelper**: A library for generating CSV files.

## Configuration
1. Configure the connection string in `appsettings.json` to point to your preferred SQL Server database.
2. Configure user roles and claims-based policies in `Startup.cs` or `Program.cs`.
3. Add JWT secret keys and token settings in `appsettings.json`.

## Secured Endpoints
### Admin-only operations:
- POST /api/cars
- PUT /api/cars/{id}
- DELETE /api/cars/{id}

### Authenticated user operations:
- GET /api/cars
- GET /api/cars/{id}
- Compare cars: POST /api/cars/compare
- Download data: GET /api/cars/download/csv or GET /api/cars/download/excel

## API Endpoints

### **GET /api/cars**
Retrieve a list of all cars in the database.

### **GET /api/cars/{id}**
Retrieve the details of a specific car by its ID.

### **POST /api/cars**
Add a new car to the database.

### **PUT /api/cars/{id}**
Update an existing car's details.

### **DELETE /api/cars/{id}**
Delete a car from the database by its ID.

### **POST /api/cars/compare**
Compare details of two cars side-by-side.
#### Request Body
{
  "carId1": 4,
  "carId2": 7
}
#### Sample Response
{
  "car1": {
    "brand": "Nissan",
    "model": "GTR",
    "year": 2005,
    "color": "Purple",
    "price": 350000,
    "mileage": 29,
  },
  "car2": {
    "brand": "Ford",
    "model": "Mustang",
    "year": 2003,
    "color": "Light green",
    "price": 45000000,
    "mileage": 18
  },
  "comparison": {
    "priceDifference": 44650000,
    "mileageDifference": 11
  }
}


### **GET /api/cars/download/csv**
Download the list of all cars in CSV format.

### **GET /api/cars/download/excel**
Download the list of all cars in Excel format.

#### Sample CSV Data
```csv
ID,Brand,Model,Year,Color,Price,Mileage,IsAvailable,Description
4,Nissan,GTR,2005,Purple,350000,29,true,High-performance sports car.
7,Ford,Mustang,2003,Light green,45000000,18,true,Iconic American muscle car.
```
## Database Configuration
This project uses Entity Framework Core to interact with the database. Ensure that you have a local SQL Server instance or use the appsettings.json file to configure a connection string for your preferred database.

## Contributions
Feel free to fork this repository, open issues, and submit pull requests for enhancements or bug fixes.
