Use Ecommerce_Programacionlll
go
Insert into Generos (Nombre) values ('Masculino')
go
Insert into Generos (Nombre) values ('Femenino')
go
Insert into Tallas(Talla) values ('XS')
go
Insert into Tallas(Talla) values ('S')
go
Insert into Tallas(Talla) values ('M')
go
Insert into Tallas(Talla) values ('L')
go
Insert into Tallas(Talla) values ('XL')
go
Insert into Tallas(Talla) values ('XXL')
go
Insert into Tallas(Talla) values ('XXXL')
go
Insert into Tallas(Talla) values ('30')
go
Insert into Tallas(Talla) values ('31')
go
Insert into Tallas(Talla) values ('32')
go
Insert into Tallas(Talla) values ('33')
go
Insert into Tallas(Talla) values ('34')
go
Insert into Tallas(Talla) values ('35')
go
Insert into Tallas(Talla) values ('36')
go
Insert into Tallas(Talla) values ('37')
go
Insert into Tallas(Talla) values ('38')
go
Insert into Tallas(Talla) values ('39')
go
Insert into Tallas(Talla) values ('40')
go
Insert into Tallas(Talla) values ('41')
go
Insert into Tallas(Talla) values ('42')
go
Insert into Tallas(Talla) values ('43')
go
Insert into Tallas(Talla) values ('44')
go
Insert into Tallas(Talla) values ('45')
go
Insert into Tallas(Talla) values ('46')
go
Insert into Categorias (Nombre, FechaRegistro) values ('Camperas', GETDATE())
go
Insert into Categorias (Nombre, FechaRegistro) values ('Blusas', GETDATE())
go
Insert into Categorias (Nombre, FechaRegistro) values ('Remeras', GETDATE())
go
Insert into Categorias (Nombre, FechaRegistro) values ('Jeans', GETDATE())
go
Insert into Marcas (Nombre, FechaRegistro) values ('Northland', GETDATE())
go
Insert into Marcas (Nombre, FechaRegistro) values ('Mirta Armesto Acetato', GETDATE())
go
Insert into Marcas (Nombre, FechaRegistro) values ('Levi´s', GETDATE())
go
Insert into Marcas (Nombre, FechaRegistro) values ('Billabong', GETDATE())
go
Insert into Articulos (IDMarca, IDCategoria, IDGenero, Nombre, Descripcion, Precio, FechaRegistro) 
values (1, 1, 1, 'Campera Impermeable Northland', 'Campera desmontable y muy versátil. Podes usar las prendas juntas o por separado.', 
59990, GETDATE())
go
Insert into Articulos (IDMarca, IDCategoria, IDGenero, Nombre, Descripcion, Precio, FechaRegistro)
values (2, 2, 2, 'Blusa College Mirta Armesto Acetato Lycra Encaje', 
'Delicada blusa manga larga a la cintura. Detalle de encaje en hombros y mangas.', 6499, GETDATE())
go
Insert into Articulos (IDMarca, IDCategoria, IDGenero, Nombre, Descripcion, Precio, FechaRegistro) 
values (3, 3, 1, 'Remera Hombre Levi´s Graphic Set In Neck Batwing Black', ' Hechas de suave tejido de punto Jersey, esta remera tiene un fit slim 
y está elaborada 100% de algodón', 6390, GETDATE())
go
Insert into Articulos (IDMarca, IDCategoria, IDGenero, Nombre, Descripcion, Precio, FechaRegistro) 
values (4, 4, 2, 'Pantalón Billabong Last Rays Beachpant Mujer', 'Pantalón palazzo con cintura elástica, con bolsillos laterales.', 5999,
GETDATE())
go
Insert Into Imagenes (IDArticulo, URLImagen) values (1, 'https://http2.mlstatic.com/D_NQ_NP_858950-MLA45835722992_052021-W.webp')
go
Insert Into Imagenes (IDArticulo, URLImagen) values (1, 'https://http2.mlstatic.com/D_942675-MLA45835796221_052021-O.jpg')
go
Insert Into Imagenes (IDArticulo, URLImagen) values (2, 'https://http2.mlstatic.com/D_NQ_NP_757040-MLA49976265910_052022-W.webp')
go
Insert Into Imagenes (IDArticulo, URLImagen) values (2, 'https://http2.mlstatic.com/D_NQ_NP_899744-MLA49760282678_042022-O.webp')
go
Insert Into Imagenes (IDArticulo, URLImagen) values (3, 'https://http2.mlstatic.com/D_NQ_NP_883558-MLA49794535519_042022-W.webp')
go
Insert Into Imagenes (IDArticulo, URLImagen) values (3, 'https://http2.mlstatic.com/D_NQ_NP_657134-MLA49794595040_042022-O.webp')
go
Insert Into Imagenes (IDArticulo, URLImagen) values (4, 'https://http2.mlstatic.com/D_NQ_NP_756798-MLA49840887741_052022-W.webp')
go
Insert Into Imagenes (IDArticulo, URLImagen) values (4, 'https://http2.mlstatic.com/D_614858-MLA49840887742_052022-O.jpg')
go
Insert into TiposUsuarios (Nombre) values ('Administrador')
go
Insert into TiposUsuarios (Nombre) values ('Cliente')
go
Insert into FormasPagos (Nombre) values ('Efectivo')
go
Insert into FormasPagos (Nombre) values ('Mercado Pago')
go
Insert into TiposUsuarios (Nombre) values ('Cliente')
go
Insert into Pais(Nombre) values ('Argentina')
go
Insert into Provincias(IDPais, Nombre) values (1, 'Buenos Aires')
go
Insert into Localidad(CP, IDProvincia, Nombre) values ('B1648', 1, 'Tigre')
go
insert into Articulos_X_Tallas (IDArticulo,	IDTalla, Stock) values (1, 1, 20)
insert into Articulos_X_Tallas (IDArticulo,	IDTalla, Stock) values (1, 2, 30)
insert into Articulos_X_Tallas (IDArticulo,	IDTalla, Stock) values (1, 3, 80)
insert into Articulos_X_Tallas (IDArticulo,	IDTalla, Stock) values (1, 4, 50)
insert into Articulos_X_Tallas (IDArticulo,	IDTalla, Stock) values (1, 5, 10)
insert into Articulos_X_Tallas (IDArticulo,	IDTalla, Stock) values (1, 6, 220)
insert into Articulos_X_Tallas (IDArticulo,	IDTalla, Stock) values (1, 7, 260)
insert into Articulos_X_Tallas (IDArticulo,	IDTalla, Stock) values (1, 8, 210)
insert into Articulos_X_Tallas (IDArticulo,	IDTalla, Stock) values (1, 9, 120)
insert into Articulos_X_Tallas (IDArticulo,	IDTalla, Stock) values (1, 10, 42)
insert into Articulos_X_Tallas (IDArticulo,	IDTalla, Stock) values (1, 11, 123)
insert into Articulos_X_Tallas (IDArticulo,	IDTalla, Stock) values (1, 12, 133)
insert into Articulos_X_Tallas (IDArticulo,	IDTalla, Stock) values (1, 13, 134)
insert into Articulos_X_Tallas (IDArticulo,	IDTalla, Stock) values (1, 14, 143)
insert into Articulos_X_Tallas (IDArticulo,	IDTalla, Stock) values (1, 15, 173)
insert into Articulos_X_Tallas (IDArticulo,	IDTalla, Stock) values (1, 16, 210)
insert into Articulos_X_Tallas (IDArticulo,	IDTalla, Stock) values (1, 17, 156)
insert into Articulos_X_Tallas (IDArticulo,	IDTalla, Stock) values (1, 18, 44)
insert into Articulos_X_Tallas (IDArticulo,	IDTalla, Stock) values (1, 19, 242)
insert into Articulos_X_Tallas (IDArticulo,	IDTalla, Stock) values (1, 20, 887)
insert into Articulos_X_Tallas (IDArticulo,	IDTalla, Stock) values (1, 21, 74)
insert into Articulos_X_Tallas (IDArticulo,	IDTalla, Stock) values (1, 22, 44)
insert into Articulos_X_Tallas (IDArticulo,	IDTalla, Stock) values (1, 23, 452)
insert into Articulos_X_Tallas (IDArticulo,	IDTalla, Stock) values (1, 24, 11)
go
insert into Articulos_X_Tallas (IDArticulo,	IDTalla, Stock) values (2, 1, 20)
insert into Articulos_X_Tallas (IDArticulo,	IDTalla, Stock) values (2, 2, 30)
insert into Articulos_X_Tallas (IDArticulo,	IDTalla, Stock) values (2, 3, 80)
insert into Articulos_X_Tallas (IDArticulo,	IDTalla, Stock) values (2, 4, 50)
insert into Articulos_X_Tallas (IDArticulo,	IDTalla, Stock) values (2, 5, 10)
insert into Articulos_X_Tallas (IDArticulo,	IDTalla, Stock) values (2, 6, 220)
insert into Articulos_X_Tallas (IDArticulo,	IDTalla, Stock) values (2, 7, 260)
insert into Articulos_X_Tallas (IDArticulo,	IDTalla, Stock) values (2, 8, 210)
insert into Articulos_X_Tallas (IDArticulo,	IDTalla, Stock) values (2, 9, 120)
insert into Articulos_X_Tallas (IDArticulo,	IDTalla, Stock) values (2, 10, 42)
insert into Articulos_X_Tallas (IDArticulo,	IDTalla, Stock) values (2, 11, 123)
insert into Articulos_X_Tallas (IDArticulo,	IDTalla, Stock) values (2, 12, 133)
insert into Articulos_X_Tallas (IDArticulo,	IDTalla, Stock) values (2, 13, 134)
insert into Articulos_X_Tallas (IDArticulo,	IDTalla, Stock) values (2, 14, 143)
insert into Articulos_X_Tallas (IDArticulo,	IDTalla, Stock) values (2, 15, 173)
insert into Articulos_X_Tallas (IDArticulo,	IDTalla, Stock) values (2, 16, 210)
insert into Articulos_X_Tallas (IDArticulo,	IDTalla, Stock) values (2, 17, 156)
insert into Articulos_X_Tallas (IDArticulo,	IDTalla, Stock) values (2, 18, 44)
insert into Articulos_X_Tallas (IDArticulo,	IDTalla, Stock) values (2, 19, 242)
insert into Articulos_X_Tallas (IDArticulo,	IDTalla, Stock) values (2, 20, 887)
insert into Articulos_X_Tallas (IDArticulo,	IDTalla, Stock) values (2, 21, 74)
insert into Articulos_X_Tallas (IDArticulo,	IDTalla, Stock) values (2, 22, 44)
insert into Articulos_X_Tallas (IDArticulo,	IDTalla, Stock) values (2, 23, 452)
insert into Articulos_X_Tallas (IDArticulo,	IDTalla, Stock) values (2, 24, 11)
go
insert into Articulos_X_Tallas (IDArticulo,	IDTalla, Stock) values (3, 1, 20)
insert into Articulos_X_Tallas (IDArticulo,	IDTalla, Stock) values (3, 2, 30)
insert into Articulos_X_Tallas (IDArticulo,	IDTalla, Stock) values (3, 3, 80)
insert into Articulos_X_Tallas (IDArticulo,	IDTalla, Stock) values (3, 4, 50)
insert into Articulos_X_Tallas (IDArticulo,	IDTalla, Stock) values (3, 5, 10)
insert into Articulos_X_Tallas (IDArticulo,	IDTalla, Stock) values (3, 6, 220)
insert into Articulos_X_Tallas (IDArticulo,	IDTalla, Stock) values (3, 7, 260)
insert into Articulos_X_Tallas (IDArticulo,	IDTalla, Stock) values (3, 8, 210)
insert into Articulos_X_Tallas (IDArticulo,	IDTalla, Stock) values (3, 9, 120)
insert into Articulos_X_Tallas (IDArticulo,	IDTalla, Stock) values (3, 10, 42)
insert into Articulos_X_Tallas (IDArticulo,	IDTalla, Stock) values (3, 11, 123)
insert into Articulos_X_Tallas (IDArticulo,	IDTalla, Stock) values (3, 12, 133)
insert into Articulos_X_Tallas (IDArticulo,	IDTalla, Stock) values (3, 13, 134)
insert into Articulos_X_Tallas (IDArticulo,	IDTalla, Stock) values (3, 14, 143)
insert into Articulos_X_Tallas (IDArticulo,	IDTalla, Stock) values (3, 15, 173)
insert into Articulos_X_Tallas (IDArticulo,	IDTalla, Stock) values (3, 16, 210)
insert into Articulos_X_Tallas (IDArticulo,	IDTalla, Stock) values (3, 17, 156)
insert into Articulos_X_Tallas (IDArticulo,	IDTalla, Stock) values (3, 18, 44)
insert into Articulos_X_Tallas (IDArticulo,	IDTalla, Stock) values (3, 19, 242)
insert into Articulos_X_Tallas (IDArticulo,	IDTalla, Stock) values (3, 20, 887)
insert into Articulos_X_Tallas (IDArticulo,	IDTalla, Stock) values (3, 21, 74)
insert into Articulos_X_Tallas (IDArticulo,	IDTalla, Stock) values (3, 22, 44)
insert into Articulos_X_Tallas (IDArticulo,	IDTalla, Stock) values (3, 23, 452)
insert into Articulos_X_Tallas (IDArticulo,	IDTalla, Stock) values (3, 24, 11)
go
insert into Articulos_X_Tallas (IDArticulo,	IDTalla, Stock) values (4, 1, 20)
insert into Articulos_X_Tallas (IDArticulo,	IDTalla, Stock) values (4, 2, 30)
insert into Articulos_X_Tallas (IDArticulo,	IDTalla, Stock) values (4, 3, 80)
insert into Articulos_X_Tallas (IDArticulo,	IDTalla, Stock) values (4, 4, 50)
insert into Articulos_X_Tallas (IDArticulo,	IDTalla, Stock) values (4, 5, 10)
insert into Articulos_X_Tallas (IDArticulo,	IDTalla, Stock) values (4, 6, 220)
insert into Articulos_X_Tallas (IDArticulo,	IDTalla, Stock) values (4, 7, 260)
insert into Articulos_X_Tallas (IDArticulo,	IDTalla, Stock) values (4, 8, 210)
insert into Articulos_X_Tallas (IDArticulo,	IDTalla, Stock) values (4, 9, 120)
insert into Articulos_X_Tallas (IDArticulo,	IDTalla, Stock) values (4, 10, 42)
insert into Articulos_X_Tallas (IDArticulo,	IDTalla, Stock) values (4, 11, 123)
insert into Articulos_X_Tallas (IDArticulo,	IDTalla, Stock) values (4, 12, 133)
insert into Articulos_X_Tallas (IDArticulo,	IDTalla, Stock) values (4, 13, 134)
insert into Articulos_X_Tallas (IDArticulo,	IDTalla, Stock) values (4, 14, 143)
insert into Articulos_X_Tallas (IDArticulo,	IDTalla, Stock) values (4, 15, 173)
insert into Articulos_X_Tallas (IDArticulo,	IDTalla, Stock) values (4, 16, 210)
insert into Articulos_X_Tallas (IDArticulo,	IDTalla, Stock) values (4, 17, 156)
insert into Articulos_X_Tallas (IDArticulo,	IDTalla, Stock) values (4, 18, 44)
insert into Articulos_X_Tallas (IDArticulo,	IDTalla, Stock) values (4, 19, 242)
insert into Articulos_X_Tallas (IDArticulo,	IDTalla, Stock) values (4, 20, 887)
insert into Articulos_X_Tallas (IDArticulo,	IDTalla, Stock) values (4, 21, 74)
insert into Articulos_X_Tallas (IDArticulo,	IDTalla, Stock) values (4, 22, 44)
insert into Articulos_X_Tallas (IDArticulo,	IDTalla, Stock) values (4, 23, 452)
insert into Articulos_X_Tallas (IDArticulo,	IDTalla, Stock) values (4, 24, 11)
go
exec SP_AgregarUsuario 'Gimenez', 'Esteban', 
'234254216', 'ElAdmin', 'pass123', 1, 1, 'mail123@gmail.com', '1123453456'
go
exec SP_AgregarUsuario 'Coronel', 'franco', 
'2334233423', 'ElCliente', 'pass123', 2, 1, 'mail@gmail.com', '1123453456'
go