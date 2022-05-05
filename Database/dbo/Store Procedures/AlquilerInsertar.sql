CREATE PROCEDURE dbo.AlquilerInsertar
	
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
	WHERE VehiculoId=@VehiculoId
	AND (
	@FechaInicio BETWEEN FechaInicio AND FechaFin
	OR 
	@FechaFin BETWEEN FechaInicio AND FechaFin
	)
	)BEGIN

		INSERT INTO dbo.Alquiler 
		(	       
	      ClientesId,
		  VehiculoId,
		  FechaInicio,
		  FechaFin,
		  Monto,
		  Impuesto,
		  Total,
		  Observaciones,
		  Estado
		)
		VALUES
		(
		
	      @ClientesId,
		  @VehiculoId,
		  @FechaInicio,
		  @FechaFin,
		  @Monto,
		  @Impuesto,
		 @Total,
		  --((@Impuesto/100)*@Monto)+@Monto,
		  @Observaciones,
		  @Estado
		)
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