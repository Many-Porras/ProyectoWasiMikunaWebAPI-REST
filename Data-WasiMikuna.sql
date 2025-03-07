USE [Wasi_Mikuna]
GO
/****** Object:  Table [dbo].[centro_salud]    Script Date: 29/01/2025 12:56:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[centro_salud](
	[id_centro_salud] [int] IDENTITY(1,1) NOT NULL,
	[id_distrito] [int] NOT NULL,
	[nombre] [varchar](200) NOT NULL,
	[telefono] [nvarchar](12) NULL,
	[direccion] [nvarchar](100) NULL,
	[X] [nvarchar](500) NULL,
	[Y] [nvarchar](500) NULL,
	[fecha_registro] [datetime] NULL,
	[fecha_update] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[id_centro_salud] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[colegio]    Script Date: 29/01/2025 12:56:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[colegio](
	[id_colegio] [int] IDENTITY(1,1) NOT NULL,
	[id_distrito] [int] NOT NULL,
	[nombre_colegio] [nvarchar](50) NOT NULL,
	[codigo_modular] [nvarchar](10) NULL,
	[telefono_colegio] [nvarchar](12) NULL,
	[direccion_colegio] [nvarchar](100) NULL,
	[X] [nvarchar](500) NULL,
	[Y] [nvarchar](500) NULL,
	[fecha_registro] [datetime] NULL,
	[fecha_update] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[id_colegio] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[detalle_incidencia]    Script Date: 29/01/2025 12:56:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[detalle_incidencia](
	[id_detalle_incidencia] [int] IDENTITY(1,1) NOT NULL,
	[id_incidencia] [int] NOT NULL,
	[id_usuario] [bigint] NOT NULL,
	[comentario] [nvarchar](300) NULL,
	[estado_detalle] [char](1) NULL,
	[fecha_registro] [datetime] NULL,
	[fecha_update] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[id_detalle_incidencia] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[distrito]    Script Date: 29/01/2025 12:56:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[distrito](
	[id_distrito] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [nvarchar](50) NOT NULL,
	[coordenadas] [geometry] NULL,
	[id_provincia] [int] NOT NULL,
	[id_user_create] [int] NULL,
	[fecha_registro] [datetime] NULL,
	[fecha_update] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[id_distrito] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[incidencia]    Script Date: 29/01/2025 12:56:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[incidencia](
	[id_incidencia] [int] IDENTITY(1,1) NOT NULL,
	[id_colegio] [int] NOT NULL,
	[tipo_incidencia] [nvarchar](20) NOT NULL,
	[tipologia] [nvarchar](50) NULL,
	[tipo_doc_reporta] [nvarchar](3) NULL,
	[nro_doc_reporta] [nvarchar](12) NULL,
	[nombre_reporta] [nvarchar](50) NULL,
	[celular_reporta] [nvarchar](10) NULL,
	[detalle_incidencia] [nvarchar](500) NULL,
	[estado] [nvarchar](20) NULL,
	[fecha_reagendada] [datetime] NULL,
	[fecha_registro] [datetime] NULL,
	[fecha_update] [datetime] NULL,
	[archivos] [varbinary](max) NULL,
PRIMARY KEY CLUSTERED 
(
	[id_incidencia] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[provincia]    Script Date: 29/01/2025 12:56:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[provincia](
	[id_provincia] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [nvarchar](50) NOT NULL,
	[id_region] [int] NOT NULL,
	[id_user_create] [int] NULL,
	[fecha_registro] [datetime] NULL,
	[fecha_update] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[id_provincia] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[region]    Script Date: 29/01/2025 12:56:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[region](
	[id_region] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [nvarchar](50) NOT NULL,
	[fecha_registro] [datetime] NULL,
	[fecha_update] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[id_region] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[usuario]    Script Date: 29/01/2025 12:56:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[usuario](
	[id_usuario] [bigint] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](255) NOT NULL,
	[tip_doc] [nvarchar](3) NULL,
	[nro_doc] [nvarchar](10) NULL,
	[email] [nvarchar](255) NOT NULL,
	[email_verified_at] [datetime] NULL,
	[password] [nvarchar](255) NOT NULL,
	[remember_token] [nvarchar](100) NULL,
	[fecha_registro] [datetime] NULL,
	[fecha_update] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[id_usuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[email] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[centro_salud]  WITH CHECK ADD  CONSTRAINT [FK_centro_salud_distrito] FOREIGN KEY([id_distrito])
REFERENCES [dbo].[distrito] ([id_distrito])
GO
ALTER TABLE [dbo].[centro_salud] CHECK CONSTRAINT [FK_centro_salud_distrito]
GO
ALTER TABLE [dbo].[colegio]  WITH CHECK ADD  CONSTRAINT [FK_colegio_distrito] FOREIGN KEY([id_distrito])
REFERENCES [dbo].[distrito] ([id_distrito])
GO
ALTER TABLE [dbo].[colegio] CHECK CONSTRAINT [FK_colegio_distrito]
GO
ALTER TABLE [dbo].[detalle_incidencia]  WITH CHECK ADD  CONSTRAINT [FK_detalle_incidencia_incidencia] FOREIGN KEY([id_incidencia])
REFERENCES [dbo].[incidencia] ([id_incidencia])
GO
ALTER TABLE [dbo].[detalle_incidencia] CHECK CONSTRAINT [FK_detalle_incidencia_incidencia]
GO
ALTER TABLE [dbo].[detalle_incidencia]  WITH CHECK ADD  CONSTRAINT [FK_detalle_incidencia_usuario] FOREIGN KEY([id_usuario])
REFERENCES [dbo].[usuario] ([id_usuario])
GO
ALTER TABLE [dbo].[detalle_incidencia] CHECK CONSTRAINT [FK_detalle_incidencia_usuario]
GO
ALTER TABLE [dbo].[distrito]  WITH CHECK ADD  CONSTRAINT [FK_distrito_provincia] FOREIGN KEY([id_provincia])
REFERENCES [dbo].[provincia] ([id_provincia])
GO
ALTER TABLE [dbo].[distrito] CHECK CONSTRAINT [FK_distrito_provincia]
GO
ALTER TABLE [dbo].[incidencia]  WITH CHECK ADD  CONSTRAINT [FK_incidencia_colegio] FOREIGN KEY([id_colegio])
REFERENCES [dbo].[colegio] ([id_colegio])
GO
ALTER TABLE [dbo].[incidencia] CHECK CONSTRAINT [FK_incidencia_colegio]
GO
ALTER TABLE [dbo].[provincia]  WITH CHECK ADD  CONSTRAINT [FK_provincia_region] FOREIGN KEY([id_region])
REFERENCES [dbo].[region] ([id_region])
GO
ALTER TABLE [dbo].[provincia] CHECK CONSTRAINT [FK_provincia_region]
GO
/****** Object:  StoredProcedure [dbo].[sp_InsertarIncidencia]    Script Date: 29/01/2025 12:56:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_InsertarIncidencia]
    @id_colegio INT,
    @tipo_incidencia NVARCHAR(20),
    @tipologia NVARCHAR(50) = NULL,
    @tipo_doc_reporta NVARCHAR(3) = NULL,
    @nro_doc_reporta NVARCHAR(12) = NULL,
    @nombre_reporta NVARCHAR(50) = NULL,
    @celular_reporta NVARCHAR(10) = NULL,
    @detalle_incidencia NVARCHAR(500) = NULL,
    @archivos varbinary(MAX) = NULL,
    @estado NVARCHAR(20) = NULL,
    @fecha_reagendada DATETIME = NULL
AS
BEGIN
    SET NOCOUNT ON;

    INSERT INTO [dbo].[incidencia] 
    ([id_colegio], [tipo_incidencia], [tipologia], [tipo_doc_reporta], [nro_doc_reporta], [nombre_reporta], [celular_reporta], [detalle_incidencia], [archivos], [estado], [fecha_reagendada], [fecha_registro], [fecha_update])
    VALUES
    (@id_colegio, @tipo_incidencia, @tipologia, @tipo_doc_reporta, @nro_doc_reporta, @nombre_reporta, @celular_reporta, @detalle_incidencia, @archivos, @estado, @fecha_reagendada, GETDATE(), NULL);

    SELECT SCOPE_IDENTITY() AS id_incidencia; -- Devuelve el ID generado
END;
GO
/****** Object:  StoredProcedure [dbo].[sp_ObtenerColegiosPorIdDistrito]    Script Date: 29/01/2025 12:56:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- 4. Obtener un colegio específico con información del distrito
CREATE PROCEDURE [dbo].[sp_ObtenerColegiosPorIdDistrito]
    @id_distrito INT
AS
BEGIN
  SELECT c.id_colegio,d.id_distrito, c.nombre_colegio, c.codigo_modular,c.telefono_colegio,c.direccion_colegio,c.X,c.Y, c.fecha_registro,c.fecha_update, d.nombre AS nombre_distrito
    FROM colegio c
    JOIN distrito d ON c.id_distrito = d.id_distrito
    WHERE c.id_distrito = @id_distrito
END;


-- SELECT c.id_colegio,d.id_distrito, c.nombre_colegio, c.codigo_modular,c.telefono_colegio,c.direccion_colegio,c.X,c.Y, c.fecha_registro,c.fecha_update, d.nombre AS nombre_distrito
--    FROM colegio c
--    JOIN distrito d ON c.id_distrito = d.id_distrito
--    WHERE c.id_distrito = 33

--select * from colegio;
GO
/****** Object:  StoredProcedure [dbo].[sp_ObtenerDistritoPorCoordenadas]    Script Date: 29/01/2025 12:56:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_ObtenerDistritoPorCoordenadas]
    @Longitud FLOAT,
    @Latitud FLOAT
AS
BEGIN
    SET NOCOUNT ON;

    SELECT TOP 1
        d.id_distrito AS iddistrito,
        p.id_provincia AS idprovincia,
        r.id_region AS idregion
    FROM distrito d
    JOIN provincia p ON d.id_provincia = p.id_provincia
    JOIN region r ON p.id_region = r.id_region
    WHERE d.coordenadas.STContains(
        geometry::STGeomFromText('POINT(' + CAST(@Longitud AS VARCHAR(20)) + ' ' + CAST(@Latitud AS VARCHAR(20)) + ')', 4326)
    ) = 1;
END;
GO
/****** Object:  StoredProcedure [dbo].[sp_ObtenerDistritoPorIdProvincia]    Script Date: 29/01/2025 12:56:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- PROCEDIMIENTO ALMACENADO PARA distritos por provincia
CREATE PROCEDURE [dbo].[sp_ObtenerDistritoPorIdProvincia]
	@id_provincia INT
	AS
	BEGIN
		select d.id_distrito, 
		d.nombre,p.id_provincia, 
		d.fecha_registro, 
		d.fecha_update from distrito d
		JOIN provincia p ON d.id_provincia = p.id_provincia
		where d.id_provincia = @id_provincia;
	END;
GO
/****** Object:  StoredProcedure [dbo].[sp_ObtenerProvinciasPorIdRegion]    Script Date: 29/01/2025 12:56:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- 2. Obtener una provincia específica con información de la región
CREATE PROCEDURE [dbo].[sp_ObtenerProvinciasPorIdRegion]
    @id_region INT
AS
BEGIN
    SELECT 
        p.id_provincia, 
        p.nombre AS nombre_provincia, 
        r.id_region, 
        r.nombre AS nombre_region,
        p.fecha_registro,
        p.fecha_update
    FROM provincia p
    JOIN region r ON p.id_region = r.id_region
    WHERE p.id_region = @id_region;
END;


GO
/****** Object:  StoredProcedure [dbo].[sp_ObtenerRegiones]    Script Date: 29/01/2025 12:56:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- 3. Obtener todas las regiones
CREATE PROCEDURE [dbo].[sp_ObtenerRegiones]
AS
BEGIN
    SELECT * FROM region;
END;

GO
/****** Object:  StoredProcedure [dbo].[sp_ObtenerRegionPorId]    Script Date: 29/01/2025 12:56:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- 4. Obtener región por ID
CREATE PROCEDURE [dbo].[sp_ObtenerRegionPorId]
    @id_region INT
AS
BEGIN
    SELECT * FROM region WHERE id_region = @id_region;
END;

GO
/****** Object:  StoredProcedure [dbo].[sp_RegistrarIncidencia]    Script Date: 29/01/2025 12:56:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_RegistrarIncidencia]
    @id_colegio INT,
    @tipo_incidencia NVARCHAR(20),
    @tipologia NVARCHAR(50) = NULL,
    @tipo_doc_reporta NVARCHAR(3) = NULL,
    @nro_doc_reporta NVARCHAR(12) = NULL,
    @nombre_reporta NVARCHAR(50) = NULL,
    @celular_reporta NVARCHAR(10) = NULL,
    @detalle_incidencia NVARCHAR(500) = NULL,
    @estado NVARCHAR(20) = NULL,
    @fecha_reagendada DATETIME = NULL,
    @archivos VARBINARY(MAX) = NULL
AS
BEGIN
    SET NOCOUNT ON;

    BEGIN TRY
        BEGIN TRANSACTION;

        -- Validación para evitar registros inválidos (opcional)
        IF NOT EXISTS (SELECT 1 FROM dbo.colegio WHERE id_colegio = @id_colegio)
        BEGIN
            RAISERROR('El colegio especificado no existe.', 16, 1);
            RETURN;
        END

        -- Inserción de datos en la tabla incidencia
        INSERT INTO [dbo].[incidencia] 
           ([id_colegio], [tipo_incidencia], [tipologia], [tipo_doc_reporta], 
            [nro_doc_reporta], [nombre_reporta], [celular_reporta], 
            [detalle_incidencia], [estado], [fecha_reagendada], 
            [fecha_registro], [fecha_update], [archivos])
        VALUES 
           (@id_colegio, @tipo_incidencia, @tipologia, @tipo_doc_reporta, 
            @nro_doc_reporta, @nombre_reporta, @celular_reporta, 
            @detalle_incidencia, @estado, @fecha_reagendada, 
            GETDATE(), GETDATE(), @archivos);

			SELECT SCOPE_IDENTITY() AS id_incidencia; -- Devuelve el ID generado

        -- Confirmar la transacción
        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        -- Manejo de errores: rollback de la transacción en caso de error
        IF @@TRANCOUNT > 0
            ROLLBACK TRANSACTION;

        -- Propagar el error para que sea manejado por el cliente
        THROW;
    END CATCH
END
GO
