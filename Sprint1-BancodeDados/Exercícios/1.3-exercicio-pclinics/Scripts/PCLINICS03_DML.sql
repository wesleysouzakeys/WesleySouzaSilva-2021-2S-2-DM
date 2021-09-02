INSERT INTO CLINICA (endereço)
VALUES ('Rua dos Pets, 132');

INSERT INTO VETERINARIO (idClinica, nomeVeterinario)
VALUES (1, 'Saulo'), (1, 'Lucas');

INSERT INTO CONSULTA (idVeterinario, idPet, dataConsulta)
VALUES (1, 1, '2020-05-23'), (2, 2, '2020-01-04'), (2, 3, '2020-06-13');

INSERT INTO PET (nomePet)
VALUES ('Totó'), ('Bob'), ('Jujuba');

INSERT INTO DONO (idPet, nomeDono)
VALUES (1, 'Wesley'), (2, 'João'), (3, 'João');

INSERT INTO RACA (idPet, nomeRaca)
VALUES (1, 'Salsicha'), (2, 'Pinscher'), (3, 'Siamês');

INSERT INTO TIPOPET (idRaca, tipoPet)
VALUES (1, 'Cachorro'), (2, 'Cachorro'), (3, 'Gato');



--MUDANÇA NO TIPO DE UMA COLUNA

--ALTER TABLE CONSULTA 
--DROP COLUMN dataConsulta;

--ALTER TABLE CONSULTA
--ADD dataConsulta DATE;