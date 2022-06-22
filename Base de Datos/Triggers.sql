Use Ecommerce_Programacionlll
go
Create Trigger TR_EliminarArticulo on Articulos
instead of delete
As
Begin
	Begin Try
		Begin Transaction
			Declare @idArticulo bigint
			Select @idArticulo = IDArticulo From deleted

			Update Imagenes Set Estado = 0 Where IDArticulo = @idArticulo
			Update Articulos_X_Carritos Set Estado = 0 Where IDArticulo = @idArticulo
			Update Articulos Set Estado = 0 Where IDArticulo = @idArticulo
		Commit Transaction
	End Try
	Begin Catch
		RAISERROR('Error, no se pudo eliminar el articulo', 16, 2)
		Rollback Transaction
	End Catch
End
go
---------------------------------------------------------------------------------------------
---------------------------------------------------------------------------------------------
Create Trigger TR_EliminarCategoria on Categorias
instead of delete
As
Begin
	Begin Try
		Begin Transaction
			Declare @idCategoria smallint
			Select @idCategoria = IDCategoria From deleted

			Update Articulos Set IDCategoria = null Where IDCategoria = @idCategoria
			Update Categorias Set Estado = 0 Where IDCategoria = @idCategoria
		Commit Transaction
	End Try
	Begin Catch
		RAISERROR('Error, no se pudo eliminar la categoria', 16, 2)
		Rollback Transaction
	End Catch
End
go
--------------------------------------------------------------------------------------------
--------------------------------------------------------------------------------------------
Create Trigger TR_EliminarImagen on Imagenes
instead of delete
As
Begin
	Begin Try
		Begin Transaction
			Declare @idImagen bigint
			Select @idImagen = IDImagen From deleted

			Update Imagenes Set Estado = 0 Where IDImagen = @idImagen
		Commit Transaction
	End Try
	Begin Catch
		RAISERROR('Error, no se pudo eliminar la categoria', 16, 2)
		Rollback Transaction
	End Catch
End