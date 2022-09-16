# Full Stack Web Programming using Dapper and Blazor Server

![Accelebrate Logo](images/accelebrate-logo.png "Accelebrate Logo")

Most of Accelebrate's courses are taught privately online or in-person for teams of 3 or more, and can be customized to your group’s goals. To receive a customized proposal and price quote, please visit [https://www.accelebrate.com/contact/](https://www.accelebrate.com/contact/) or email [sales@accelebrate.com](sales@accelebrate.com). In addition, we offer live, online open enrollment training for individuals.

## List of Helpful VSCode Extensions

- ms-dotnettools.csharp

## Run Azure SQL Edge on Docker

```bash
docker run -e "ACCEPT_EULA=1" -e "MSSQL_SA_PASSWORD=sqlDbp@ss" -e "MSSQL_PID=Developer" -e "MSSQL_USER=SA" -p 1433:1433 -d --name=sql mcr.microsoft.com/azure-sql-edge
```

## Connection String for Azure SQL Edge on Docker

```connectionstring
Data Source=localhost,1433;Initial Catalog=App;User Id=sa;Password=sqlDbp@ss
```

## SQL Script to Initialize Database (for all students)

```sql
DROP DATABASE IF EXISTS App;
GO

CREATE DATABASE App;
GO

USE App;
GO

DROP TABLE IF EXISTS dbo.Color;
GO

CREATE TABLE dbo.Color (
  "Id" INT PRIMARY KEY CLUSTERED IDENTITY,
  "Name" NVARCHAR(MAX) NOT NULL,
  "Hexcode" NVARCHAR(MAX) NOT NULL
);
GO

DROP PROCEDURE IF EXISTS InsertColor
GO

CREATE PROCEDURE InsertColor
  @Name NVARCHAR(MAX),
  @Hexcode NVARCHAR(MAX)  
AS   
  SET NOCOUNT ON;

  INSERT INTO dbo.Color ("Name", "Hexcode")
  VALUES (@Name, @Hexcode);

  SELECT "Id", "Name", "Hexcode"
  FROM dbo.Color WHERE Id = SCOPE_IDENTITY();
GO 

DROP PROCEDURE IF EXISTS UpdateColor
GO

CREATE PROCEDURE UpdateColor
  @Id INT,
  @Name NVARCHAR(MAX),
  @Hexcode NVARCHAR(MAX)  
AS   
  SET NOCOUNT ON;

  UPDATE dbo.Color SET "Name" = @Name, "Hexcode" = @Hexcode
  WHERE Id = @Id;
GO

DROP PROCEDURE IF EXISTS DeleteColor
GO

CREATE PROCEDURE DeleteColor
  @Id INT
AS   
  SET NOCOUNT ON;

  DELETE dbo.Color WHERE Id = @Id;
GO 

EXEC InsertColor 'red', 'FF0000';
EXEC InsertColor 'orange', 'FF7F00';
EXEC InsertColor 'yellow', 'FFFF00';
EXEC InsertColor 'green', '00FF00';
EXEC InsertColor 'blue', '0000FF';
EXEC InsertColor 'indigo', '4B0082';
EXEC InsertColor 'violet', '9400D3';
GO

---

DROP TABLE IF EXISTS dbo.Car;
GO

CREATE TABLE dbo.Car (
  Id INT PRIMARY KEY CLUSTERED IDENTITY,
  Make NVARCHAR(MAX) NOT NULL,
  Model NVARCHAR(MAX) NOT NULL,
  Year INT NOT NULL DEFAULT 1900,
  Color NVARCHAR(MAX) NOT NULL,
  Price MONEY NOT NULL DEFAULT 0
);
GO

DROP PROCEDURE IF EXISTS InsertCar
GO

CREATE PROCEDURE InsertCar
  @Make NVARCHAR(MAX),
  @Model NVARCHAR(MAX),
  @Year INT,
  @Color NVARCHAR(MAX),
  @Price MONEY 
AS   
  SET NOCOUNT ON;

  INSERT INTO dbo.Car ("Make", "Model", "Year", "Color", "Price")
  VALUES (@Make, @Model, @Year, @Color, @Price);

  SELECT "Id", "Make", "Model", "Year", "Color", "Price"
  FROM dbo.Car
  WHERE Id = SCOPE_IDENTITY();
GO 

DROP PROCEDURE IF EXISTS UpdateCar
GO

CREATE PROCEDURE UpdateCar
  @Id INT,
  @Make NVARCHAR(MAX),
  @Model NVARCHAR(MAX),
  @Year INT,
  @Color NVARCHAR(MAX),
  @Price MONEY 
AS   
  SET NOCOUNT ON;

  UPDATE dbo.Car
  SET "Make"=@Make, "Model"=@Model,
      "Year"=@Year, "Color"=@Color,
      "Price"=@Price
  WHERE Id = @Id;
GO

DROP PROCEDURE IF EXISTS DeleteCar
GO

CREATE PROCEDURE DeleteCar
  @Id INT
AS   
  SET NOCOUNT ON;

  DELETE dbo.Car WHERE Id = @Id;
GO

EXEC InsertCar 'Ford', 'Fusion Hybrid', 2020, 'blue', 40000;
EXEC InsertCar 'Tesla', 'S', 2019, 'red', 120000;
GO
```

## Other Resources

The instructor will distribute additional private links during class for accessing other resources...

All code in this repository is distributed under the [MIT license](license.txt).

<br><br>
All course content and teaching is provided by: [T4D.IO](https://www.t4d.io)