INSERT INTO USUARIO (nomeUsuario, email, senha, admAccess)
VALUES ('José', 'josé@email.com', 'zezin123', 0), ('John', 'john@email.com', 'johnzin123', 1);
GO

INSERT INTO ESTILO (nomeEstilo)
VALUES ('Folk'), ('Jazz'), ('Gospel');
GO

INSERT INTO ALBUM (nomeMusica, qtdMusicas)
VALUES ('Raio de Saudade', 8), ('Meteoro da Paixão', 12);
GO

INSERT INTO ALBUMESTILO (idEstilo, idAlbum, visualizacoes)
VALUES (2, 1, '20000000'), (1, 2, '50000000');
GO

INSERT INTO ARTISTA (idAlbumEstilo, nomeArtista, idadeArtista)
VALUES (3, 'Steve Vai', 23), (4, 'Joe Satriani', 26);
GO

INSERT INTO EMPRESA (idArtista, idUsuario)
VALUES (1, 2), (2, 1);
GO

