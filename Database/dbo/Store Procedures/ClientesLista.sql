CREATE PROCEDURE [dbo].[ClientesLista]
AS
	BEGIN
	SET NOCOUNT ON


	SELECT
	 ClientesId,
	 NombreCompleto
	FROM Clientes
	WHERE Estado=1


	END