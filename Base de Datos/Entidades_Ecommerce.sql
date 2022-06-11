Use Master
go
Create Database Ecommerce_Programacionlll
go
Use Ecommerce_Programacionlll
go
Create Table Marcas(
	IDMarca smallint not null primary key identity(1, 1),
	Nombre varchar(50) not null,
	FechaRegistro datetime null default(GETDATE()),
	Estado bit null default(1),
)
go
Create Table Categorias(
	IDCategoria smallint not null primary key identity(1, 1),
	Nombre varchar(50) not null,
	FechaRegistro datetime null default(GETDATE()),
	Estado bit null default(1)
)
go
Create Table Generos(
	IDGenero tinyint not null primary key identity(1, 1),
	Nombre varchar(50) not null,
	Estado bit null default(1)
)
go
Create Table Articulos(
	IDArticulo bigint not null primary key identity(1, 1),
	IDMarca smallint not null foreign key references Marcas(IDMarca),
	IDCategoria smallint not null foreign key references Categorias(IDCategoria),
	IDGenero tinyint not null foreign key references Generos(IDGenero),
	Nombre varchar(50) not null,
	Descripcion varchar(100) not null,
	Precio money not null,
	Stock bigint not null,
	FechaRegistro datetime null default(GETDATE()),
	Estado bit null default(1)
)
go
Create Table Imagenes(
	IDImagen bigint not null primary key identity(1, 1),
	IDArticulo bigint not null foreign key references Articulos(IDArticulo),
	URLImagen varchar(300) not null,
	Estado bit null default(1)
)