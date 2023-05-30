# Dog House API

This is a sample REST API developed using C# and ASP .NET Core Web API. It provides endpoints to interact with a dog database, allowing users to ping the service, query dogs, and create new dogs. The API supports sorting, pagination, and handles various error cases.

## Prerequisites

-   .NET 5 SDK
-   PostgreSQL database

## Getting Started

1.  Clone the repository: `git clone <repository-url>`
2.  Navigate to the project directory: `cd dog-house-api`
3.  Restore the NuGet packages: `dotnet restore`
4.  Update the database connection string in the `appsettings.json` file.
5.  Build the project: `dotnet build`
6.  Run the application: `dotnet run`

The API will be accessible at `http://localhost:5000` or `https://localhost:5001`.

## API Endpoints

### 1. Ping

-   Endpoint: `GET /ping`
-   Description: Check the availability of the API.
-   Example: 
    `curl -X GET http://localhost:5000/ping` 
    

### 2. Query Dogs

-   Endpoint: `GET /dogs`
-   Description: Retrieve a list of dogs.
-   Query Parameters:
    -   `attribute` (optional): Sort the dogs by the specified attribute (e.g., `weight`).
    -   `order` (optional): Sort order (`asc` for ascending, `desc` for descending).
    -   `pageNumber` (optional): Page number for pagination.
    -   `pageSize` (optional): Number of dogs per page.
-   Example:
    `curl -X GET "http://localhost:5000/dogs?attribute=weight&order=desc&pageNumber=1&pageSize=10"` 
    

### 3. Create Dog

-   Endpoint: `POST /dog`
-   Description: Create a new dog.
-   Request Body: JSON object representing the dog's details.
-   Example:
    `curl -X POST http://localhost:5000/dog -d "{"name": "Doggy", "color": "red", "tail_length": 173, "weight": 33}"` 

## Rate Limiting

The API includes a rate limiting mechanism to handle situations when there are too many incoming requests. By default, it allows 10 requests per second. If the number of incoming requests exceeds the configured limit, the API will return an HTTP status code `429 Too Many Requests`.

## Testing

Unit tests have been implemented to cover all the logic in the application. To run the tests, use the following command:

`dotnet test` 

## Conclusion

This sample Dog House API provides basic functionality to interact with a dog database. It showcases the use of various software development patterns, handles error cases, and incorporates rate limiting to prevent overwhelming the service with excessive requests. Feel free to explore and modify the code as per your requirements.
