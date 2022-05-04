IF NOT EXISTS( SELECT * FROM sysobjects WHERE name = 'Tb_PersonasFisicas')
BEGIN

CREATE TABLE Tb_PersonasFisicas
(
    IdPersonaFisica INT IDENTITY,
    FechaRegistro DATETIME,
    FechaActualizacion DATETIME,
    Nombre VARCHAR(50),
    ApellidoPaterno VARCHAR(50),
    ApellidoMaterno VARCHAR(50),
    RFC VARCHAR(13),
    FechaNacimiento DATE,
    UsuarioAgrega INT,
    Activo BIT
);

ALTER TABLE Tb_PersonasFisicas
ADD CONSTRAINT [PK_Tb_PersonasFisicas]
    PRIMARY KEY (IdPersonaFisica);

ALTER TABLE Tb_PersonasFisicas
ADD CONSTRAINT [DF_Tb_PersonasFisicas_FechaRegistro]
    DEFAULT (GETDATE()) FOR FechaRegistro;

ALTER TABLE Tb_PersonasFisicas
ADD CONSTRAINT [DF_Tb_PersonasFisicas_Activo]
    DEFAULT (1) FOR Activo;
END
GO