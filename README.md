# Employee Management App (C#, Blazor)

A simple employee management App using Blazor

## Features
- Add / Update / Delete Employees
- Blazor Front End Development along with C#
- Database Table and Stored Prodedures created in SQL Server Management Studio
- Dapper used for data access layer
- One‑click run from Visual Studio

## Database Setup
**1) Create new database in SQL Server Management Studio**

**2) Create Table**

CREATE TABLE Employees (
    EmployeeId INT IDENTITY(1,1) PRIMARY KEY,
    Name NVARCHAR(100),
    Department NVARCHAR(100),
    Salary DECIMAL(18,2)
);

**3) Run Stored Procedures for CRUD Operations**

-- CREATE

CREATE PROCEDURE sp_AddEmployee
    @Name NVARCHAR(100),
    @Department NVARCHAR(100),
    @Salary DECIMAL(18,2)
AS
BEGIN
    INSERT INTO Employees (Name, Department, Salary)
    VALUES (@Name, @Department, @Salary);
END
GO

-- READ

CREATE PROCEDURE sp_GetEmployees
AS
BEGIN
    SELECT EmployeeId, Name, Department, Salary FROM Employees;
END
GO

-- UPDATE

CREATE PROCEDURE sp_UpdateEmployee
    @EmployeeId INT,
    @Name NVARCHAR(100),
    @Department NVARCHAR(100),
    @Salary DECIMAL(18,2)
AS
BEGIN
    UPDATE Employees
    SET Name=@Name, Department=@Department, Salary=@Salary
    WHERE EmployeeId=@EmployeeId;
END
GO

-- DELETE

CREATE PROCEDURE sp_DeleteEmployee
    @EmployeeId INT
AS
BEGIN
    DELETE FROM Employees WHERE EmployeeId=@EmployeeId;
END
GO

**4) Connect database in Visual Studio via the Server Explorer**

**5) Update appsettings.json in the BlazorEmployeeApp project with the connection string**
