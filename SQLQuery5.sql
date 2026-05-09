CREATE DATABASE AppSalesAgency;
GO

USE AppSalesAgency;
GO

CREATE TABLE Usuarios(
    id INT PRIMARY KEY IDENTITY(1,1),
    nombre VARCHAR(50) NOT NULL,
    [Password] VARCHAR(50) NOT NULL
);

CREATE TABLE Cliente(
IdCliente INT PRIMARY KEY IDENTITY(1,1),
Nit VARCHAR(20),
Nombre VARCHAR(100),
Apellidos VARCHAR(100)
);

CREATE TABLE Proveedor(
    IdProveedor INT PRIMARY KEY IDENTITY(1,1),
    Nit VARCHAR(50),
    Nombre VARCHAR(100),
    Direccion VARCHAR(200),
    Telefono VARCHAR(20),
    PaginaWeb VARCHAR(150)
);

CREATE TABLE Categoria(
    IdCategoria INT PRIMARY KEY IDENTITY(1,1),
    Nombre VARCHAR(100),
    Descripcion VARCHAR(200)
);

CREATE TABLE Producto(
    IdProducto INT PRIMARY KEY IDENTITY(1,1),
    Nombre VARCHAR(100),
    Precio DECIMAL(10,2),
    Stock INT,
    IdProveedor INT,
    IdCategoria INT,
    FOREIGN KEY(IdProveedor) REFERENCES Proveedor(IdProveedor),
    FOREIGN KEY(IdCategoria) REFERENCES Categoria(IdCategoria)
);

CREATE TABLE Venta(
    IdVenta INT PRIMARY KEY IDENTITY(1,1),
    Fecha DATETIME,
    IdCliente INT,
    Descuento DECIMAL(10,2),
    Total DECIMAL(10,2),
    FOREIGN KEY(IdCliente) REFERENCES Cliente(IdCliente)
);

CREATE TABLE DetalleVenta(
    IdDetalleVenta INT PRIMARY KEY IDENTITY(1,1),
    IdVenta INT,
    IdProducto INT,
    Cantidad INT,
    Precio DECIMAL(10,2),
    Subtotal DECIMAL(10,2),
    FOREIGN KEY(IdVenta) REFERENCES Venta(IdVenta),
    FOREIGN KEY(IdProducto) REFERENCES Producto(IdProducto)
);