Use Ecommerce_Programacionlll
go
Create Procedure SP_ListarArticulos
As
Begin
	select a.IDArticulo, a.Nombre Articulo, a.Descripcion, a.Precio, a.Stock, a.FechaRegistro, a.Estado EstadoArticulo,
	m.IDMarca, m.Nombre Marca, m.FechaRegistro FechaRegistroMarca, m.Estado EstadoMarca, c.IDCategoria, c.Nombre Categoria,
	c.FechaRegistro FechaRegistroCategoria, c.Estado EstadoCategoria, g.IDGenero, g.Nombre Genero, g.Estado EstadoGenero 
	From Articulos a Inner Join Marcas m on a.IDMarca = m.IDMarca 
	Inner Join Categorias c on a.IDCategoria = c.IDCategoria 
	Inner Join Generos g on a.IDGenero = g.IDGenero
End
go
Create Procedure SP_ListarCategorias
As
Begin
	Select IDCategoria, Nombre, FechaRegistro, Estado From Categorias
End
go
Create Procedure SP_ListarImagenesArticulo(
	@idArticulo bigint
)
As
Begin
	Select IDImagen, URLImagen, Estado From Imagenes Where IDArticulo = @idArticulo
End
go
Create Procedure SP_ListarMarcas
As
Begin
	Select IDMarca, Nombre, FechaRegistro, Estado From Marcas
End
go
Create Procedure SP_ListarUsuarios
As
Begin
	Select u.IDUsuario, u.Apellidos, u.Nombres, u.DNI, u.NombreUsuario, u.Contraseña, u.Estado EstadoUsuario, 
	tu.IDTipoUsuario, tu.Nombre TipoUsuario, tu.Estado EstadoTipoUsuario, c.IDUsuario, c.Email, c.Telefono, 
	c.Estado EstadoContacto, l.IDLocalidad, l.CP CodigoPostal, l.Nombre NombreLocalidad, l.Estado EstadoLocalidad, 
	p.IDProvincia, p.Nombre Provincia, p.Estado EstadoProvincia, pa.IDPais, pa.Nombre Pais, pa.Estado EstadoPais
	From Usuarios u Inner Join TiposUsuarios tu on u.IDTipoUsuario = tu.IDTipoUsuario
	Inner Join Contactos c on u.IDUsuario = c.IDUsuario
	Inner Join Localidad l on u.IDLocalidad = l.IDLocalidad
	Inner Join Provincias p on l.IDProvincia = p.IDProvincia
	Inner Join Pais pa on p.IDPais = pa.IDPais
End
exec SP_ListarImagenesArticulo '1'