## Diagrams
The following diagrams provide a visual representation of the system:
NB drop in browser for rich rendering if you dont have the mermaid extension installed or the vscode preview not displaying diagrams.

### Architecture Diagram
The architecture diagram illustrates the interaction between the React frontend, the API server, and the database. The React application communicates with the API server via REST API calls, and the API server interacts with the database using SQL queries.

```mermaid
graph TD
  subgraph ReactApp
    Home
    About
    Contact
    Persons
    PersonDetails
    AccountDetails
    TransactionDetails
  end

  subgraph APIServer
    Controllers
    Services
    Repositories
    Entities
  end

  subgraph Database
    PersonsTable[Persons]
    AccountsTable[Accounts]
    TransactionsTable[Transactions]
  end

  ReactApp -->|REST API Calls| APIServer
  APIServer -->|SQL Queries| Database
```

### Entity Relationship (ER) Diagram
The ER diagram shows the relationships between the entities in the system. Each person can have multiple accounts, and each account can have multiple transactions.

```mermaid
erDiagram
  PERSONS {
    int Id
    string IDNumber
    string Surname
    string Name
  }
  ACCOUNTS {
    int Id
    string AccountNumber
    decimal Balance
    int PersonId
  }
  TRANSACTIONS {
    int Id
    string Description
    decimal Amount
    datetime Date
    datetime CaptureDate
    int AccountId
  }
  PERSONS ||--o{ ACCOUNTS : "has"
  ACCOUNTS ||--o{ TRANSACTIONS : "has"
```

### Sequence Diagram
The sequence diagram depicts the flow of creating a new person in the system. It shows the interactions between the user, the React application, the API server, and the database.

```mermaid
sequenceDiagram
  participant User
  participant ReactApp
  participant APIServer as "API Server"
  participant Database

  User ->> ReactApp: Create New Person
  ReactApp ->> APIServer: POST /api/persons
  APIServer ->> Database: Insert Person
  Database -->> APIServer: Person Created
  APIServer -->> ReactApp: Person Created
  ReactApp -->> User: Person Created Confirmation
```

### Class Diagram
The class diagram provides a detailed view of the classes in the system and their relationships. It includes the `Person`, `Account`, and `Transaction` classes, along with their attributes and associations.

```mermaid
classDiagram
  class Person {
    int Id
    string IDNumber
    string Surname
    string Name
    List~Account~ Accounts
  }

  class Account {
    int Id
    string AccountNumber
    decimal Balance
    int PersonId
    Person Person
    List~Transaction~ Transactions
  }

  class Transaction {
    int Id
    string Description
    decimal Amount
    DateTime Date
    DateTime CaptureDate
    int AccountId
    Account Account
  }

  Person "1" *-- "many" Account : "has"
  Account "1" *-- "many" Transaction : "has"
```

## License
This project is licensed under the MIT License.