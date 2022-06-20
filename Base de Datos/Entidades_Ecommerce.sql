Use Master
go
--Drop Database Ecommerce_Programacionlll
--go
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
	Nombre varchar(50) not null unique,
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
	Nombre varchar(200) not null,
	Descripcion varchar(500) not null,
	Precio money not null check(Precio >= 0),
	Stock bigint not null check(Stock >= 0),
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
go
Create Table FormasPagos(
	IDFormaPago tinyint not null primary key identity(1, 1),
	Nombre varchar(50) not null,
	Estado bit not null default(1)
)
go
Create Table Pais(
	IDPais tinyint not null primary key identity(1, 1),
	Nombre varchar(50) not null,
	Estado bit not null default(1)
)
go
Create Table Provincias(
	IDProvincia int not null primary key identity(1, 1),
	IDPais tinyint not null foreign key references Pais(IDPais),
	Nombre varchar(100) not null,
	Estado bit not null default(1)
)
go
Create Table Localidad(
	IDLocalidad int not null primary key identity(1, 1),
	CP varchar(20) not null unique,
	IDProvincia int not null foreign key references Provincias(IDProvincia),
	Nombre varchar(150) not null,
	Estado bit not null default(1)
)
go
Create Table TiposUsuarios(
	IDTipoUsuario tinyint not null primary key identity(1, 1),
	Nombre varchar(70) not null unique,
	Estado bit not null default(1)
)
go
Create Table Usuarios(
	IDUsuario bigint not null primary key identity(1, 1),
	Apellidos varchar(100) not null,
	Nombres varchar(100) not null,
	DNI varchar(15) not null,
	NombreUsuario varchar(20) not null,
	Contraseña varchar(30) not null,
	IDTipoUsuario tinyint not null foreign key references TiposUsuarios(IDTipoUsuario),
	IDLocalidad int not null foreign key references Localidad(IDLocalidad),
	Estado bit not null default(1)
)
go
Create Table Contactos(
	IDUsuario bigint not null primary key foreign key references Usuarios(IDUsuario),
	Email varchar(100) not null unique,
	Telefono varchar(50) not null,
	Estado bit not null default(1)
)
go
Create Table Compras(
	IDCompra bigint not null primary key identity(1, 1),
	IDUsuario bigint not null references Usuarios(IDUsuario),
	IDArticulo bigint not null references Articulos(IDArticulo),
	Cantidad int not null,
	PrecioTotal money not null,
	Estado bit not null default(1)
)
go
Create Table Factura(
	IDFactura bigint not null primary key identity(1, 1),
	IDCompra bigint not null foreign key references Compras(IDCompra),
	IDFormaPago tinyint not null foreign key references FormasPagos(IDFormaPago),
	Estado bit not null default(1)
)
go
Create Table Valoraciones(
	IDValoracion bigint not null primary key identity(1, 1),
	IDCompra bigint not null foreign key references Compras(IDCompra),
	Puntaje tinyint not null check (Puntaje >=0 AND Puntaje <=10),
	Estado bit not null default(1)
)
go
Create Table Carritos(
	IDCarrito bigint not null primary key identity(1, 1),
	IDUsuario bigint not null foreign key references Usuarios(IDUsuario),
	Estado bit not null default(1)
)
go
Create Table Articulos_X_Carritos(
	IDCarrito bigint not null foreign key references Carritos(IDCarrito),
	IDArticulo bigint not null foreign key references Articulos(IDArticulo),
	Cantidad int not null,
	Estado bit not null default(1)
	Primary Key(IDCarrito, IDArticulo)
)
go
Create Table Movimientos(
	IDMovimiento bigint not null primary key identity(1, 1),
	IDUsuario bigint not null foreign key references Usuarios(IDUsuario),
	FechaLogin datetime not null,
	FechaLogout datetime not null
)