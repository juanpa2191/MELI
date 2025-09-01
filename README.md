# MercadoLibreApi

## Overview
MercadoLibreApi is a .NET 8 backend API designed to provide product details for a webpage inspired by Mercadolibre. The API follows best practices for backend development, ensuring efficient data handling and a clean architecture.

## Project Structure
The project is organized into several key components:

- **MercadoLibre.Api**: Contains the API entry point, controllers, and configuration files.
- **MercadoLibre.Core**: Contains the core business logic, including entities, interfaces, and services.
- **MercadoLibre.Infrastructure**: Contains data access implementations and configuration extensions.
- **MercadoLibre.Tests**: Contains unit tests for the service layer.

## Setup Instructions
1. **Clone the repository**:
   ```bash
   git clone <repository-url>
   cd MercadoLibreApi
   ```

2. **Restore dependencies**:
   ```bash
   dotnet restore
   ```

3. **Run the application**:
   ```bash
   dotnet run --project src/MercadoLibre.Api/MercadoLibre.Api.csproj
   ```

4. **Access the API**:
   The API will be available at `http://localhost:5000` (or the configured port).

## Usage
- The main endpoint to retrieve product details is `/api/products/{id}` where `{id}` is the unique identifier of the product.
- Ensure to have the sample data in `src/MercadoLibre.Infrastructure/Data/products.json` for testing purposes.

## Testing
Unit tests can be run using the following command:
```bash
dotnet test src/MercadoLibre.Tests/MercadoLibre.Tests.csproj
```

## Contributing
Contributions are welcome! Please submit a pull request or open an issue for any enhancements or bug fixes.

## License
This project is licensed under the MIT License. See the LICENSE file for more details.