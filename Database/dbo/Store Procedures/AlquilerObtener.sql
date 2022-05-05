CREATE PROCEDURE [dbo].AlquilerObtener
@IdAlquiler INT=NULL

AS BEGIN
	SET NOCOUNT ON

	SELECT
			A.IdAlquiler
		,   A.FechaInicio
		,   A.FechaFin
		,   A.Monto
		,   A.Impuesto
		,   A.Total
		,   A.Observaciones
		,   A.Estado

		,   A.ClientesId
		,	C.NombreCompleto

		,   A.VehiculoId
		,	V.Matricula
				

	FROM dbo.Alquiler A
	 INNER JOIN dbo.Clientes C
         ON A.ClientesId = C.ClientesId
     INNER JOIN dbo.Vehiculo V
         ON A.VehiculoId = V.VehiculoId
	 
	WHERE
	     (@IdAlquiler IS NULL OR A.IdAlquiler=@IdAlquiler)

END