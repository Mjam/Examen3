CREATE PROCEDURE [dbo].CatalogoDistritoLista
@IdCatalogoCanton INT=null
AS
	BEGIN
		SET NOCOUNT ON
		SELECT 
		IdCatalogoDistrito,
		NombreCatalogoDistrito

		FROM	
			dbo.CatalogoDistrito

	    WHERE
		    IdCatalogoCanton=@IdCatalogoCanton


	END
