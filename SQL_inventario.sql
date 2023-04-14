select * from USUARIOS_PC

drop table DatosUsuarios

DBCC CHECKIDENT ('DISPOSITIVOS', RESEED, 0)

ALTER TABLE DISPOSITIVOS
DROP COLUMN COD_USUARIO;


ALTER TABLE Dispositivos
DROP CONSTRAINT FK_DISPOSITIVOS_USUARIOS












create procedure SP_MOSTRARASIGNACIONES
AS
SELECT * FROM DISPAUSU
go


exec SP_MOSTRARASIGNACIONES





create procedure SP_MOSTRAR_ASIGNACION
@_COD_PC
AS
SELECT * FROM 




------ INSERT
--- DROP PROCEDURE InsertarUsuario

CREATE PROCEDURE [dbo].[InsertarUsuario]
    @cod_usuario NVARCHAR(50),
    @nombres NVARCHAR(100),
    @apellidos NVARCHAR(100),
    @area NVARCHAR(100),
    @email NVARCHAR(100)
AS
BEGIN
    SET NOCOUNT ON;

    INSERT INTO USUARIOS_PC (COD_USUARIO, NOMBRES, APELLIDOS, AREA, EMAIL)
    VALUES (@cod_usuario, @nombres, @apellidos, @area, @email);
END






-- SELECT


CREATE PROCEDURE MostrarUsuarios
AS
BEGIN
    SELECT * FROM USUARIOS_PC;
END



---- mostrar FirmaUsuario
--drop procedure MostrarFirmaUsuarios
CREATE PROCEDURE MostrarFirmaUsuarios
@_COD_USUARIO NVARCHAR(20)
AS
BEGIN
    SELECT * FROM USUARIOS_PC where COD_USUARIO=@_COD_USUARIO;
END



---- mostrar Autorizados para firmar
--drop procedure MostrarAutorizadosFirmar
CREATE PROCEDURE MostrarAutorizadosFirmar
@_Entrega bit,
@_COD_USUARIO NVARCHAR(20)
AS
BEGIN
    SELECT * 
	FROM USUARIOS_PC 
	where Entrega=@_Entrega
	and COD_USUARIO = @_COD_USUARIO
END




-- UPDATE


CREATE PROCEDURE [dbo].[usp_ActualizarUsuario]
    @COD_USUARIO nvarchar(50),
    @NOMBRES nvarchar(100),
    @APELLIDOS nvarchar(100),
    @CARGO nvarchar(100),
    @EMAIL nvarchar(100)
AS
BEGIN
    UPDATE USUARIOS_PC
    SET NOMBRES = @NOMBRES,
        APELLIDOS = @APELLIDOS,
        CARGO = @CARGO,
        EMAIL = @EMAIL
    WHERE COD_USUARIO = @COD_USUARIO
END






--- DROP


CREATE PROCEDURE [dbo].[usp_EliminarUsuario]
    @COD_USUARIO nvarchar(50)
AS
BEGIN
    DELETE FROM USUARIOS_PC
    WHERE COD_USUARIO = @COD_USUARIO
END





----- CRUD USUARIOS
EXEC MostrarUsuarios
EXEC MostrarFirmaUsuarios @_COD_USUARIO='CECON01'
exec MostrarAutorizadosFirmar @_Entrega='true', @_COD_USUARIO='CECON01'

exec SP_MOSTRARASIGNACIONES
EXEC InsertarUsuario @COD_USUARIO='CETI02', @NOMBRES='Fernando',@apellidos='TI',@cargo='Soporte Informatica',@email='SOPORTECERASUS@GIDDINGSFRUIT.COM'
EXEC usp_ActualizarUsuario @COD_USUARIO='CETI01', @NOMBRES='DAIRON',@apellidos='PARRA',@cargo='INFORMATICA',@email='JOHNPARRA91@GMAIL.COM'

EXEC usp_EliminarUsuario @COD_USUARIO='CETI01'



EXEC sp_rename 'USUARIOS_PC.CARGO', 'AREA', 'COLUMN';








----- CRUD DISPOSITIVOS

-----------------------drop PROCEDURE sp_InsertarDispositivo

--CREATE PROCEDURE sp_InsertarDispositivo
--    @cod_pc NVARCHAR(50),
--    @cod_usuario NVARCHAR(50),
--    @nombre_usuario NVARCHAR(50),
--    @serial NVARCHAR(100),
--    @area NVARCHAR(100),
--    @tipo NVARCHAR(100),
--    @procesador NVARCHAR(50),
--    @ram INT,
--    @tipo_disco NVARCHAR(3),
--    @capacidad_disco INT,
--    @sistema_operativo NVARCHAR(100),
--    @modelo NVARCHAR(100),
--    @mac_lan NVARCHAR(100) = NULL,
--    @mac_wifi NVARCHAR(100) = NULL
--AS
--BEGIN
--    INSERT INTO DISPOSITIVOS (
--        COD_PC,
--        COD_USUARIO,
--        NOMBRE_USUARIO,
--        SERIAL,
--        AREA,
--        TIPO,
--        PROCESADOR,
--        RAM,
--        TIPO_DISCO,
--        CAPACIDAD_DISCO,
--        SISTEMA_OPERATIVO,
--        MODELO,
--        MAC_LAN,
--        MAC_WIFI
--    ) VALUES (
--        @cod_pc,
--        @cod_usuario,
--        @nombre_usuario,
--        @serial,
--        @area,
--        @tipo,
--        @procesador,
--        @ram,
--        @tipo_disco,
--        @capacidad_disco,
--        @sistema_operativo,
--        @modelo,
--        @mac_lan,
--        @mac_wifi
--    )
--END


CREATE PROCEDURE sp_InsertarDispositivo
    @_cod_pc NVARCHAR(50),
    @_cod_usuario NVARCHAR(50),
    @_nombre_usuario NVARCHAR(50),
    @_serial NVARCHAR(100),
    @_area NVARCHAR(100),
    @_tipo NVARCHAR(100),
    @_procesador NVARCHAR(50),
    @_ram INT,
    @_tipo_disco NVARCHAR(3),
    @_capacidad_disco INT,
    @_sistema_operativo NVARCHAR(100),
    @_modelo NVARCHAR(100),
    @_mac_lan NVARCHAR(100) = NULL,
    @_mac_wifi NVARCHAR(100) = NULL
AS
BEGIN
    DECLARE @_fecha_creacion DATETIME
    SET @_fecha_creacion = GETDATE()

    INSERT INTO DISPOSITIVOS (
        COD_PC,
        COD_USUARIO,
        NOMBRE_USUARIO,
        SERIAL,
        AREA,
        TIPO,
        PROCESADOR,
        RAM,
        TIPO_DISCO,
        CAPACIDAD_DISCO,
        SISTEMA_OPERATIVO,
        MODELO,
        MAC_LAN,
        MAC_WIFI,
        FECHA_CREACION
    ) VALUES (
        @_cod_pc,
        @_cod_usuario,
        @_nombre_usuario,
        @_serial,
        @_area,
        @_tipo,
        @_procesador,
        @_ram,
        @_tipo_disco,
        @_capacidad_disco,
        @_sistema_operativo,
        @_modelo,
        @_mac_lan,
        @_mac_wifi,
        @_fecha_creacion
    )
END







--drop procedure sp_MostrarDispositivos
CREATE PROCEDURE sp_MostrarDispositivos
AS
BEGIN
    SELECT *
	FROM DISPOSITIVOS
END



CREATE PROCEDURE SP_MOSTRAR_COMPUTADOR_ASIGNADO
@_COD_PC NVARCHAR(50)
AS
BEGIN
	SELECT * FROM DISPOSITIVOS WHERE COD_PC=@_COD_PC
END


EXEC SP_MOSTRAR_COMPUTADOR_ASIGNADO @_COD_PC=''



CREATE PROCEDURE sp_ActualizarDispositivo
    @id_dis INT,
    @cod_pc NVARCHAR(50),
    @cod_usuario NVARCHAR(50),
    @nombre_usuario NVARCHAR(50),
    @serial NVARCHAR(100),
    @area NVARCHAR(100),
    @tipo NVARCHAR(100),
    @procesador NVARCHAR(50),
    @ram INT,
    @tipo_disco NVARCHAR(3),
    @capacidad_disco INT,
    @sistema_operativo NVARCHAR(100),
    @modelo NVARCHAR(100),
    @mac_lan NVARCHAR(100) = NULL,
    @mac_wifi NVARCHAR(100) = NULL
AS
BEGIN
    UPDATE DISPOSITIVOS SET
        COD_PC = @cod_pc,
        COD_USUARIO = @cod_usuario,
        NOMBRE_USUARIO = @nombre_usuario,
        SERIAL = @serial,
        AREA = @area,
        TIPO = @tipo,
        PROCESADOR = @procesador,
        RAM = @ram,
        TIPO_DISCO = @tipo_disco,
        CAPACIDAD_DISCO = @capacidad_disco,
        SISTEMA_OPERATIVO = @sistema_operativo,
        MODELO = @modelo,
        MAC_LAN = @mac_lan,
        MAC_WIFI = @mac_wifi
    WHERE ID_DIS = @id_dis
END





------- drop

CREATE PROCEDURE [dbo].[EliminarDispositivo]
    @id_dis int
AS
BEGIN
    SET NOCOUNT ON;
    
    -- Eliminar el dispositivo correspondiente al ID especificado
    DELETE FROM DISPOSITIVOS
    WHERE ID_DIS = @id_dis;
    
    -- Comprobar si se ha eliminado correctamente
    IF @@ROWCOUNT > 0
    BEGIN
        SELECT 'Dispositivo eliminado correctamente' AS Mensaje;
    END
    ELSE
    BEGIN
        SELECT 'No se encontró ningún dispositivo con el ID especificado' AS Mensaje;
    END
END







EXEC sp_MostrarDispositivos
EXEC EliminarDispositivo @id_dis='8'
EXEC sp_InsertarDispositivo @_COD_PC='CETINB04', @_cod_usuario='CETI01', @_nombre_usuario='john', @_serial='sre123sa', @_area='INFORMATICA', @_tipo='LAPTOP', @_procesador='i7', @_ram='24', @_tipo_disco='SSD', @_capacidad_disco='2', @_sistema_operativo='W11', @_modelo='ASPCD20', @_mac_lan='ma:43:FD:54:re', @_mac_wifi=''
EXEC sp_ActualizarDispositivo @ID_DIS='2', @COD_PC='CETINB01', @cod_usuario='CETI01', @nombre_usuario='john dairon', @serial='sre123sa', @area='INFORMATICA', @tipo='LAPTOP', @procesador='i7', @ram='24', @tipo_disco='SSD', @capacidad_disco='2', @sistema_operativo='W11', @modelo='ASPCD20', @mac_lan='ma:43:FD:54:re', @mac_wifi=''






------------|||||||||||||||||||    CREATE TABLE DISPOSITIVOS





USE [ToolsCerasus]
GO

ALTER TABLE [dbo].[DISPOSITIVOS] DROP CONSTRAINT [FK_DISPOSITIVOS_USUARIOS]
GO

/****** Object:  Table [dbo].[DISPOSITIVOS]    Script Date: 30-03-2023 10:38:07 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DISPOSITIVOS]') AND type in (N'U'))
DROP TABLE [dbo].[DISPOSITIVOS]
GO

/****** Object:  Table [dbo].[DISPOSITIVOS]    Script Date: 30-03-2023 10:38:07 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[DISPOSITIVOS](
	[ID_DIS] [int] IDENTITY(1,1) NOT NULL,
	[COD_PC] [nvarchar](50) NOT NULL,
	[COD_USUARIO] [nvarchar](50) NOT NULL,
	[NOMBRE_USUARIO] [nvarchar](50) NOT NULL,
	[SERIAL] [nvarchar](100) NOT NULL,
	[AREA] [nvarchar](100) NOT NULL,
	[TIPO] [nvarchar](100) NOT NULL,
	[PROCESADOR] [nvarchar](50) NOT NULL,
	[RAM] [int] NOT NULL,
	[TIPO_DISCO] [nvarchar](3) NOT NULL,
	[CAPACIDAD_DISCO] [int] NOT NULL,
	[SISTEMA_OPERATIVO] [nvarchar](100) NOT NULL,
	[MODELO] [nvarchar](100) NOT NULL,
	[MAC_LAN] [nvarchar](100) NULL,
	[MAC_WIFI] [nvarchar](100) NULL,
 CONSTRAINT [PK_DISPOSITIVOS] PRIMARY KEY CLUSTERED 
(
	[ID_DIS] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
 CONSTRAINT [UK_DISPOSITIVOS_COD_PC] UNIQUE NONCLUSTERED 
(
	[COD_PC] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[DISPOSITIVOS]  WITH CHECK ADD  CONSTRAINT [FK_DISPOSITIVOS_USUARIOS] FOREIGN KEY([COD_USUARIO])
REFERENCES [dbo].[USUARIOS_PC] ([COD_USUARIO])
GO

ALTER TABLE [dbo].[DISPOSITIVOS] CHECK CONSTRAINT [FK_DISPOSITIVOS_USUARIOS]
GO







----------------------|||||||||||||||||||||||||||| FIN TABLA DISPOSITIVOS


ALTER TABLE [dbo].[DISPOSITIVOS] DROP CONSTRAINT [FK_DISPOSITIVOS_USUARIOS]

ALTER TABLE [dbo].[DISPOSITIVOS] DROP CONSTRAINT [PK_DISPOSITIVOS]

ALTER TABLE [dbo].[DISPOSITIVOS] ADD CONSTRAINT [UK_DISPOSITIVOS_COD_PC] UNIQUE ([COD_PC])


ALTER TABLE [dbo].[DISPOSITIVOS] WITH CHECK ADD CONSTRAINT [FK_DISPOSITIVOS_USUARIOS] FOREIGN KEY([COD_USUARIO]) REFERENCES [dbo].[USUARIOS_PC] ([COD_USUARIO])

ALTER TABLE [dbo].[DISPOSITIVOS] CHECK CONSTRAINT [FK_DISPOSITIVOS_USUARIOS]


-----!!! AGREGAR 3 CAMPOS CON FECHA -----------------------°°°°°°°

ALTER TABLE [dbo].[DISPOSITIVOS]
ADD [FECHA_CREACION] DATETIME NULL,
    [FECHA_ASIGNACION] DATETIME NULL,
    [FECHA_DEVOLUCION] DATETIME NULL





	

------------////////// CONSULTA DE EQUIPOS ASIGNADOS   /////////

exec SP_MOSTRARASIGNACIONES
EXEC MostrarUsuarios
EXEC sp_MostrarDispositivos
EXEC SP_MOSTRAR_ASIGNACION_PC

EXEC SP_MOSTRAR_COMPUTADOR_ASIGNADO @_COD_PC='CETINB02'





--drop procedure SP_MOSTRAR_ASIGNACION_PC
CREATE PROCEDURE SP_MOSTRAR_ASIGNACION_PC
AS
SELECT D.COD_PC, D.SERIAL, D.TIPO, D.PROCESADOR, D.RAM, D.TIPO_DISCO, D.CAPACIDAD_DISCO, U.COD_USUARIO, U.NOMBRES, U.APELLIDOS, U.AREA, U.EMAIL
FROM USUARIOS_PC U
INNER JOIN DISPAUSU DU ON U.COD_USUARIO = DU.COD_USUARIO
INNER JOIN DISPOSITIVOS D ON DU.COD_PC = D.COD_PC;
GO





-- AGREGAR UN CAMPO PARA GUARDAR UN PDF

ALTER TABLE [dbo].[DISPAUSU]
ADD [ACTA_PDF] [VARBINARY](MAX) NULL;


ALTER TABLE [dbo].[DISPAUSU]
drop COLUMN [ARCHIVO_PDF]


ALTER TABLE [dbo].[DISPAUSU]
ALTER COLUMN [ARCHIVO_PDF] [varbinary](max) NULL;



SELECT * FROM DISPAUSU




-------- INSERTAR UN ARCHIVO PDF -------------
UPDATE DISPAUSU
SET ACTA_PDF = (SELECT BulkColumn FROM OPENROWSET(BULK 'C:\Users\jparra\Desktop\MiArchivo.pdf', SINGLE_BLOB) AS x)
WHERE ID_DISPAUSU = 30;







UPDATE DISPAUSU
SET ARCHIVO_PDF = @PDFData
WHERE ID = @ID;



SELECT ARCHIVO_PDF FROM DISPAUSU WHERE COD_PC = 'cetinb02'


ALTER TABLE DISPAUSU
DROP CONSTRAINT IF EXISTS UQ_num_acta;

ALTER TABLE DISPAUSU
ALTER COLUMN num_acta INT IDENTITY(1,1);

ALTER TABLE SISTEMA_OPERATIVO
ADD CONSTRAINT SO UNIQUE(SO);

ALTER TABLE CAPACIDAD_DISCOS
ADD CONSTRAINT CAPACIDAD_DISCO UNIQUE(CAPACIDAD_DISCO);


ALTER TABLE DISPOSITIVOS
ADD CONSTRAINT SERIAL UNIQUE(SERIAL);



ALTER TABLE USUARIOS_PC
ADD ActaEntregaPDF VARBINARY(MAX)null;

ALTER TABLE USUARIOS_PC
ADD ActaDevolucionPDF VARBINARY(MAX)null;

ALTER TABLE USUARIOS_PC
ADD FECHA_CREACION DATETIME null;


ALTER TABLE USUARIOS_PC
ADD Entrega bit;




-------


CREATE TABLE [dbo].[Permisos_Formularios](
    [IdUsuario] [int] NOT NULL,
    [formulario] [varchar](50) NOT NULL,
    [permiso] [bit] NOT NULL,
    CONSTRAINT [PK_Permisos_Formularios] PRIMARY KEY CLUSTERED (
        [IdUsuario] ASC,
        [formulario] ASC
    ),
    CONSTRAINT [FK_Permisos_Formularios_Usuarios] FOREIGN KEY ([IdUsuario]) REFERENCES [Usuarios]([Id])
);








----HISTORIAL


USE [ToolsCerasus]
GO

CREATE TABLE [dbo].[HISTORIA_DISPOSITIVO](
    [ID_HISTORIA] [int] IDENTITY(1,1) NOT NULL,
    [ID_DISPAUSU] [int] NOT NULL,
    [COD_PC] [nvarchar](50) NOT NULL,
    [COD_USUARIO] [nvarchar](50) NOT NULL,
    [NUM_ACTA] [int] NOT NULL,
    [TIPO_EVENTO] [nvarchar](50) NOT NULL,
    [FECHA_EVENTO] [datetime] NOT NULL,
 CONSTRAINT [PK_HISTORIA_DISPOSITIVO] PRIMARY KEY CLUSTERED 
(
    [ID_HISTORIA] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO


---- historial actas
CREATE TABLE [dbo].[ACTAS](
    [ID_ACTA] [int] IDENTITY(1,1) NOT NULL,
    [COD_USUARIO] [nvarchar](50) NOT NULL,
    [COD_PC] [nvarchar](50) NOT NULL,
    [NUM_ACTA] [int] NOT NULL,
    [TIPO_ACTA] [nvarchar](50) NOT NULL, -- 'ENTREGA' o 'DEVOLUCION'
    [FECHA_ACTA] [datetime] NOT NULL,
    [ACTA_PDF] [varbinary](max) NULL,
 CONSTRAINT [PK_ACTAS] PRIMARY KEY CLUSTERED 
(
    [ID_ACTA] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

ALTER TABLE [dbo].[ACTAS]  WITH CHECK ADD  CONSTRAINT [FK_ACTAS_USUARIOS_PC] FOREIGN KEY([COD_USUARIO])
REFERENCES [dbo].[USUARIOS_PC] ([COD_USUARIO])
GO

ALTER TABLE [dbo].[ACTAS] CHECK CONSTRAINT [FK_ACTAS_USUARIOS_PC]
GO

ALTER TABLE [dbo].[ACTAS]  WITH CHECK ADD  CONSTRAINT [FK_ACTAS_DISPOSITIVOS] FOREIGN KEY([COD_PC])
REFERENCES [dbo].[DISPOSITIVOS] ([COD_PC])
GO

ALTER TABLE [dbo].[ACTAS] CHECK CONSTRAINT [FK_ACTAS_DISPOSITIVOS]
GO




------ trigger

USE [ToolsCerasus]
GO

CREATE TRIGGER [dbo].[TRG_INSERT_DISPAUSU]
ON [dbo].[DISPAUSU]
AFTER INSERT
AS
BEGIN
    -- Insertar registro en la tabla HISTORIA_DISPOSITIVO
    INSERT INTO [dbo].[HISTORIA_DISPOSITIVO] (ID_DISPAUSU, COD_PC, COD_USUARIO, NUM_ACTA, TIPO_EVENTO, FECHA_EVENTO)
    SELECT
        i.ID_DISPAUSU,
        i.COD_PC,
        i.COD_USUARIO,
        i.NUM_ACTA,
        'ASIGNACION',
        i.FECHA_ASIGNACION
    FROM inserted i
END
GO



USE [ToolsCerasus]
GO

CREATE TRIGGER [dbo].[TRG_DELETE_DISPAUSU]
ON [dbo].[DISPAUSU]
AFTER DELETE
AS
BEGIN
    -- Insertar registro en la tabla HISTORIA_DISPOSITIVO como devolución
    INSERT INTO [dbo].[HISTORIA_DISPOSITIVO] (ID_DISPAUSU, COD_PC, COD_USUARIO, NUM_ACTA, TIPO_EVENTO, FECHA_EVENTO)
    SELECT
        d.ID_DISPAUSU,
        d.COD_PC,
        d.COD_USUARIO,
        d.NUM_ACTA,
        'DEVOLUCION',
        GETDATE()
    FROM deleted d
END
GO








CREATE TRIGGER [dbo].[TRG_ACTA_ENTREGA]
ON [dbo].[USUARIOS_PC]
AFTER UPDATE
AS
BEGIN
    -- Insertar registro en la tabla ACTAS con el PDF de la acta de entrega
    INSERT INTO [dbo].[ACTAS] (COD_USUARIO, COD_PC, NUM_ACTA, TIPO_ACTA, FECHA_ACTA, ACTA_PDF)
    SELECT
        i.COD_USUARIO,
        dp.COD_PC,
        dp.NUM_ACTA,
        'ENTREGA',
        i.FECHA_ACTA_ENTREGA,
        i.ActaEntregaPDF
    FROM inserted i
    JOIN deleted d ON i.COD_USUARIO = d.COD_USUARIO
    JOIN DISPAUSU dp ON i.COD_USUARIO = dp.COD_USUARIO
    WHERE i.ActaEntregaPDF IS NOT NULL AND (d.ActaEntregaPDF IS NULL OR i.ActaEntregaPDF <> d.ActaEntregaPDF);
END
GO


CREATE TRIGGER [dbo].[TRG_ACTA_DEVOLUCION]
ON [dbo].[DISPAUSU]
AFTER DELETE
AS
BEGIN
    -- Insertar registro en la tabla ACTAS con el PDF de la acta de devolución
    INSERT INTO [dbo].[ACTAS] (COD_USUARIO, COD_PC, NUM_ACTA, TIPO_ACTA, FECHA_ACTA, ACTA_PDF)
    SELECT
        d.COD_USUARIO,
        d.COD_PC,
        d.NUM_ACTA,
        'DEVOLUCION',
        up.FECHA_ACTA_DEVOLUCION,
        up.ActaDevolucionPDF
    FROM deleted d
    JOIN USUARIOS_PC up ON d.COD_USUARIO = up.COD_USUARIO
    WHERE up.ActaDevolucionPDF IS NOT NULL;
END
GO

