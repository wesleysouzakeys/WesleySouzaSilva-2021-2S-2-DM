USE CATALOGO;
GO

INSERT INTO FILME(idGenero, tituloFilme)
VALUES (3, 'RAMBO'), (3, 'VINGADORES'),
       (2, 'GHOST'), (2, 'DIARIO DE UMA PAIXAO')
GO

INSERT INTO GENERO (nomeGenero)
VALUES ('Com�dia')
GO

DELETE FROM FILME;

DELETE FROM GENERO;		