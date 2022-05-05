CREATE TABLE [dbo].[Alquiler]
(
	
	   IdAlquiler INT NOT NULL IDENTITY(1,1) CONSTRAINT PK_Alquiler PRIMARY KEY CLUSTERED(IdAlquiler)
	 , ClientesId INT NOT NULL
	     	CONSTRAINT FK_Alquier_Cliente FOREIGN KEY(ClientesId) REFERENCES dbo.Clientes(ClientesId)
	 , VehiculoId INT NOT NULL
	     	CONSTRAINT FK_Alquier_Vehiculo FOREIGN KEY(VehiculoId) REFERENCES dbo.Vehiculo(VehiculoId)
			
	 , FechaInicio DATETIME NOT NULL
	 , FechaFin DATETIME NOT NULL
	 , Monto DECIMAL(18,2) NOT NULL
	 , Impuesto DECIMAL(18,2) NOT NULL
	 , Total DECIMAL(18,2) NOT NULL
	 , Observaciones VARCHAR(1000) NULL
	 , Estado BIT
)WITH (DATA_COMPRESSION = PAGE)
GO
