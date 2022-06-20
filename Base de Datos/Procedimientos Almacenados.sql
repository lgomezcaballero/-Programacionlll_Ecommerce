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