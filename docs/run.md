# Instructions to Run the MercadoLibre API Project

## Prerequisites
- .NET 8 SDK installed on your machine.
- A code editor such as Visual Studio Code.

## Setup
1. **Clone the Repository**
   ```bash
   git clone <repository-url>
   cd MercadoLibreApi
   ```

2. **Restore Dependencies**
   Run the following command to restore the necessary packages:
   ```bash
   dotnet restore
   ```

3. **Build the Project**
   Build the project to ensure everything is set up correctly:
   ```bash
   dotnet build
   ```

## Running the Application
To run the application, use the following command:
```bash
dotnet run --project src/MercadoLibre.Api/MercadoLibre.Api.csproj
```

## Accessing the API
Once the application is running, you can access the API at:
```
http://localhost:5000/api/products
```

## Testing the API
You can use tools like Postman or curl to test the API endpoints. For example, to get product details, you can send a GET request to:
```
http://localhost:5000/api/products/{id}
```
Replace `{id}` with the actual product ID you want to retrieve.

## Stopping the Application
To stop the application, simply press `Ctrl + C` in the terminal where the application is running.