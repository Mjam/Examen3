CREATE PROCEDURE [dbo].[VehiculoLista]
AS
	BEGIN
	SET NOCOUNT ON


	SELECT
	 VehiculoId,
	 Matricula
	FROM Vehiculo
	WHERE Estado=1


	END
