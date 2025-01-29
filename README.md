### Build and Run the Service

1. Open the solution in Visual Studio 2022.
2. Restore the NuGet packages.
3. Build the solution.
4. Run the project.

The service will be available at `https://localhost:<port>/api/sieve`.

## Endpoints

### Get Nth Prime

- **URL:** `GET /api/sieve`
- **Query Parameters:**
  - `n` (int): The position of the prime number to retrieve.
- **Response:**
  - `200 OK`: Returns the nth prime number.