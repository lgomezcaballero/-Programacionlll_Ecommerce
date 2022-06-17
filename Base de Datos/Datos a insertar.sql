Use Ecommerce_Programacionlll
go
Insert into Generos (Nombre) values ('Masculino')
go
Insert into Generos (Nombre) values ('Femenino')
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
Insert into Articulos (IDMarca, IDCategoria, IDGenero, Nombre, Descripcion, Precio, Stock, FechaRegistro) 
values (1, 1, 1, 'Campera Impermeable Northland', 'Campera desmontable y muy versátil. Podes usar las prendas juntas o por separado.', 
59990, 200, GETDATE())
go
Insert into Articulos (IDMarca, IDCategoria, IDGenero, Nombre, Descripcion, Precio, Stock, FechaRegistro)
values (2, 2, 2, 'Blusa College Mirta Armesto Acetato Lycra Encaje', 
'Delicada blusa manga larga a la cintura. Detalle de encaje en hombros y mangas.', 6499, 150, GETDATE())
go
Insert into Articulos (IDMarca, IDCategoria, IDGenero, Nombre, Descripcion, Precio, Stock, FechaRegistro) 
values (3, 3, 1, 'Remera Hombre Levi´s Graphic Set In Neck Batwing Black', ' Hechas de suave tejido de punto Jersey, esta remera tiene un fit slim 
y está elaborada 100% de algodón', 6390, 220, GETDATE())
go
Insert into Articulos (IDMarca, IDCategoria, IDGenero, Nombre, Descripcion, Precio, Stock, FechaRegistro) 
values (4, 4, 2, 'Pantalón Billabong Last Rays Beachpant Mujer', 'Pantalón palazzo con cintura elástica, con bolsillos laterales.', 5999, 350,
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

select * from Articulos