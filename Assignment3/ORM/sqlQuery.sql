CREATE TABLE Employee (
  Id INT PRIMARY KEY,
  Name VARCHAR(255),
  Address VARCHAR(255),
  Salary DECIMAL(18,2),
  Manager VARCHAR(255)
);
INSERT INTO Employee (Id, Name, Address, Salary, Manager) VALUES (@EmpNo, @Name, @Address, @Salary, @Designation);



