# Sieve Service

## Overview

The Sieve Service is an ASP.NET Core Web API that provides endpoints to work with prime numbers. It includes functionalities to retrieve the nth prime number and to check if a number is a twin prime.

## Prerequisites

- .NET 8 SDK
- Visual Studio 2022

## Getting Started

### Clone the Repository

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

  ### Check Twin Prime

- **URL:** `GET /api/sieve/twinprime`
- **Query Parameters:**
  - `n` (int): The number to check if it is a twin prime.
- **Response:**
  - `200 OK`: Returns `true` if the number is a twin prime, otherwise `false`.


  ## License
