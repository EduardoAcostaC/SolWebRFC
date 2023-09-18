USE Generacion22;

SELECT * FROM dbRFC;

INSERT INTO dbRFC (nombre, apellidoPaterno, apellidoMaterno, fechaNacimiento, repetido, activo)
VALUES ('Eduardo', 'Acosta', 'Castillo', '2002-02-03', 0, 1);

INSERT INTO tablaRFC (nombre, apellidoPaterno, apellidoMaterno, fechaNacimiento, repetido, activo)
VALUES ('Jose', 'Lopez', 'Castro', '1995-04-16', 0, 1);

INSERT INTO tablaRFC (nombre, apellidoPaterno, apellidoMaterno, fechaNacimiento, repetido, activo)
VALUES ('Laura', 'Campos', 'Torres', '1985-12-08', 0, 1);

EXEC spAgregarRFC 'Jorge', 'Benitez', 'Ruiz', '1990-10-15', 'BERJ901015' ;

EXEC spObtenerTodos;

EXEC spEditarRFC 1, 'Eduardo', 'Acosta', 'Castillo', '2002-02-13';

EXEC spObtenerPorId 2;

EXEC spBorrarRFC 2;

UPDATE dbRFC SET activo= 1;

DROP TABLE tablaRFC;