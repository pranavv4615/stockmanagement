--Create database
CREATE database stock_management;

-- Create the Order table
CREATE TABLE Orders (
    Id INT AUTO_INCREMENT PRIMARY KEY,
    CustomerName VARCHAR(255) NOT NULL,
    StockId INT NOT NULL,
    OrderQty INT NOT NULL,
    FOREIGN KEY (StockId) REFERENCES Stocks(Id)
);

-- Create the Stock table
CREATE TABLE Stocks (
    Id INT AUTO_INCREMENT PRIMARY KEY,
    Name VARCHAR(255) NOT NULL UNIQUE,
    Quantity INT NOT NULL,
    OrderValue INT NOT NULL
);

