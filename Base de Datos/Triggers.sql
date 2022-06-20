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