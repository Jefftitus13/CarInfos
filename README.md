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
- **Image Uploading, Editing, and Retrieving**:
  - Store images/documents on disk (local file system).
  - Upload images while adding car details.
  - Retrieve and update images linked to specific cars.
- **Car Analytics**:
  - Filtering cars by most searched brand and model names.

## Technologies Used
- **ASP.NET Core Web API**: A framework for building APIs in .NET.
- **Entity Framework Core**: An Object-Relational Mapper (ORM) that enables interaction with the database using .NET objects.
- **JWT Authentication**: Secure token-based authentication mechanism for users.
- **Role-based Authorization**: Control access to specific endpoints based on user roles (e.g., Admin, User).
- **RESTful API**: Adherence to REST principles ensures stateless communication.
- **EPPlus**: A library for generating Excel files.
- **CsvHelper**: A library for generating CSV files.
- **Local File System**: Store images and documents on the server's disk, ensuring efficient retrieval and updates.

## Configuration
1. Configure the connection string in `appsettings.json` to point to your preferred SQL Server database.
2. Configure user roles and claims-based policies in `Program.cs`.
3. Add JWT secret keys and token settings in `appsettings.json`.

## Secured Endpoints
### Admin-only operations:
- POST /api/cars
- PUT /api/cars/{id}
- DELETE /api/cars/{id}

### Authenticated user operations:
- GET /api/cars
- GET /api/cars/{id}
- Compare cars: GET /api/cars/compare
- Download data: GET /api/cars/download/csv or GET /api/cars/download/excel

## API Endpoints

### **GET /api/cars**
Retrieve a list of all cars in the database.
```Json
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
```

### **GET /api/cars/{id}**
Retrieve the details of a specific car by its ID.
```Json
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
```

### **POST /api/cars**
Add a new car to the database.
```Json
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
```

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
```Json
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
```

### **GET /api/cars/download/csv**
Download the list of all cars in CSV format.

### **GET /api/cars/download/excel**
Download the list of all cars in Excel format.

### **GET /api/cars/{id}/image
Retrieve the image of a specific car.

### **POST /api/cars/{id}/upload-image
Upload an image for a specific car. Images are stored on the local file system.
```Json
{
  "message": "Image uploaded successfully.",
  "filePath": "wwwroot/images/cars/car1.jpg"
}
```

### **GET /api/cars/analytics
Generate analytical insights about the cars in the database.
```Json
{
  "mostPopularBrands": [
    {
      "brand": "Toyota",
      "count": 3
    },
    {
      "brand": "Honda",
      "count": 2
    },
    {
      "brand": "Nissan",
      "count": 1
    },
    {
      "brand": "Porsche",
      "count": 1
    },
    {
      "brand": "Tata",
      "count": 1
    }
  ],
  "mostPopularModels": [
    {
      "model": "Supra",
      "count": 3
    },
    {
      "model": "Virtus",
      "count": 1
    },
    {
      "model": "911",
      "count": 1
    },
    {
      "model": "Altroz",
      "count": 1
    },
    {
      "model": "City",
      "count": 1
    }
  ]
}
```

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
