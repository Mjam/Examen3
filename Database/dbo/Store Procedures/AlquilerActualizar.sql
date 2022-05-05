CREATE PROCEDURE dbo.AlquilerActualizar
    @IdAlquiler INT,
	@ClientesId INT,
	@VehiculoId INT,
	@FechaInicio DATETIME ,
	@FechaFin DATETIME ,
    @Monto DECIMAL(18,2),
	@Impuesto DECIMAL(18,2),
	@Total DECIMAL(18,2),
	@Observaciones VARCHAR(1000),
	@Estado BIT
AS BEGIN
SET NOCOUNT ON

	BEGIN TRANSACTION TRASA

	BEGIN TRY
	IF NOT EXISTS(
	SELECT
	*
	FROM dbo.Alquiler
	WHERE VehiculoId=@VehiculoId and IdAlquiler<>@IdAlquiler
	AND (
	@FechaInicio BETWEEN FechaInicio AND FechaFin
	OR 
	@FechaFin BETWEEN FechaInicio AND FechaFin
	)
	)BEGIN
		
	UPDATE dbo.Alquiler SET
	      ClientesId=@ClientesId,
		  VehiculoId=@VehiculoId,
		  FechaInicio=@FechaInicio,
		  FechaFin=@FechaFin,
		  Monto=@Monto,
		  Impuesto=@Impuesto,
		  Total=@Total,
		  Observaciones=@Observaciones,
		  Estado=@Estado

	WHERE IdAlquiler=@IdAlquiler

	SELECT 0 AS CodeError, '' AS MsgError

		END

	ELSE BEGIN

	SELECT -3 AS CodeError, 'El Vehiculo ya se encuetra reservado para estas fechas' AS MsgError

	END

		COMMIT TRANSACTION TRASA



	END TRY

	BEGIN CATCH
		SELECT 
				ERROR_NUMBER() AS CodeError
			,	ERROR_MESSAGE() AS MsgError

			ROLLBACK TRANSACTION TRASA
	END CATCH


END
