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
