# TVA Account Management

## Overview

TVA Account Management is a Single Page Application (SPA) designed to manage accounts, transactions, and associated persons. The backend is built with C# and Entity Framework, while the frontend is developed using React.

## Prerequisites

Before you begin, ensure you have met the following requirements:

- .NET SDK (version 8.0 or later) installed on your machine
- Node.js (version 14.0 or later) and npm installed
- SQL Server instance running (local or remote)
- Postman (optional, for API testing)

## Getting Started

Follow these steps to get the application up and running:

### 1. Unzip the Folder

Unzip the provided folder to your desired location.

### 2. Configure the Database

Ensure your SQL Server instance is running and accessible. Update the connection string in the `appsettings.json` file located in the `tva-backend-app\TvaBackend\Infrastructure` directory.

```json name=tva-backend-app/TvaBackend/TvaBackend/appsettings.json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=YOUR_SERVER_NAME;Database=TVAAccountManagement;User Id=YOUR_USERNAME;Password=YOUR_PASSWORD;"
  },
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  },
  "AllowedHosts": "*"
}
```

### 3. Run Database Migrations

Navigate to the `TvaBackend` directory and run the following commands to apply the database migrations:

```bash
cd tva-backend-app/TvaBackend/Infrastructure
dotnet ef database update
```

### 4. Start the Backend Server

In the same directory (`TvaBackend/`), run the following command to start the backend server:

```bash
dotnet run
```
Using Visual Studio
Open the tva-backend-app/TvaBackend/ solution in Visual Studio.
Set TvaBackend as the startup project.
Press F5 to start debugging or Ctrl+F5 to run without debugging.

The backend server will start on by default on `http://localhost:5105/swagger/index.html` or `http://localhost:5105`
NB double check the port your port should it be different, you will have to change the url on the app.js for front end should this be the case.



### 5. Setup the Frontend

Navigate to the `tva-frontend-app` directory and install the necessary packages:
Ignore the warning for datepicker mappings, the development server will start.

```bash
cd tva-frontend-app
npm install
```

### 6. Start the Frontend Server

In the same directory (`tva-frontend-app`), run the following command to start the frontend server:

```bash
npm start
```

The frontend server will start on `http://localhost:3000`.

### 7. Test the API Endpoints

You can use Postman to test the API endpoints. Import the provided Postman collection `tva-backend-postman-collection.json` and test the CRUD operations for Persons, Accounts, and Transactions.

## API Endpoints

### Persons

- **GET** `/api/Persons` - Get all persons
- **GET** `/api/Persons/{id}` - Get person by ID
- **POST** `/api/Persons` - Create a new person
- **PUT** `/api/Persons/{id}` - Update an existing person
- **DELETE** `/api/Persons/{id}` - Delete a person

### Accounts

- **GET** `/api/Accounts` - Get all accounts
- **GET** `/api/Accounts/{id}` - Get account by ID
- **POST** `/api/Accounts` - Create a new account
- **PUT** `/api/Accounts/{id}` - Update an existing account
- **DELETE** `/api/Accounts/{id}` - Delete an account

### Transactions

- **GET** `/api/Transactions` - Get all transactions
- **GET** `/api/Transactions/{id}` - Get transaction by ID
- **POST** `/api/Transactions` - Create a new transaction
- **PUT** `/api/Transactions/{id}` - Update an existing transaction
- **DELETE** `/api/Transactions/{id}` - Delete a transaction

## Troubleshooting

If you encounter any issues, check the following:

- Ensure your SQL Server instance is running and accessible.
- Verify the connection string in `appsettings.json` is correct.
- Ensure you have run the database migrations.
- Verify that you have the correct versions of .NET SDK and Node.js installed.

For further assistance, please contact the project maintainer.

## License

This project is licensed under the MIT License.
