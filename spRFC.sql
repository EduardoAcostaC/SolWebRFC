CREATE OR ALTER PROC spAgregarRFC
@nombre VARCHAR(100),
@apellidoPaterno VARCHAR(100),
@apellidoMaterno VARCHAR(100),
@fechaNacimiento DATE,
@rfc VARCHAR(100)
AS
BEGIN
	INSERT INTO dbRFC (nombre, apellidoPaterno, apellidoMaterno, fechaNacimiento,rfc, repetido, activo)
	VALUES (@nombre, @apellidoPaterno, @apellidoMaterno, @fechaNacimiento, @rfc, 0, 1);
END;

CREATE OR ALTER PROC spObtenerTodos
AS
BEGIN
	SELECT idRFC, nombre, apellidoPaterno, apellidoMaterno, fechaNacimiento, RFC, repetido, activo
	FROM dbRFC
	WHERE activo = 1;
END;

CREATE OR ALTER PROC spEditarRFC
@idRFC INT,
@nombre VARCHAR(100),
@apellidoPaterno VARCHAR(100),
@apellidoMaterno VARCHAR(100),
@fechaNacimiento DATE,
@rfc VARCHAR(100)
AS
BEGIN
	UPDATE dbRFC SET nombre = @nombre, apellidoPaterno = @apellidoPaterno, apellidoMaterno = @apellidoMaterno, fechaNacimiento = @fechaNacimiento, rfc = @rfc
	WHERE idRFC = @idRFC;
END;

CREATE OR ALTER PROC spObtenerPorId
@idRFC INT 
AS
BEGIN
	SELECT idRFC, nombre, apellidoPaterno, apellidoMaterno, fechaNacimiento, RFC, repetido, activo
	FROM dbRFC
	WHERE idRFC = @idRFC;
END;

CREATE OR ALTER PROC spBorrarRFC
@idRFC INT
AS
BEGIN
	UPDATE dbRFC SET activo = 0 WHERE idRFC = @idRFC;
END;