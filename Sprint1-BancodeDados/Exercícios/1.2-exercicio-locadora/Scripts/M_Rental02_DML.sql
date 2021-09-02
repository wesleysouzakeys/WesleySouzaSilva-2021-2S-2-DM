USE M_Rental;
GO

INSERT INTO EMPRESA (nomeEmpresa)
VALUES ('Rental');

INSERT INTO CLIENTE (nomeCliente)
VALUES ('Isaias'), ('Wesley');

INSERT INTO ALUGUEL (idVeiculo, idCliente, dataAluguel)
VALUES (1, 2, '02082020'), (2, 1, '30052004')

INSERT INTO MARCA (nomeMarca)
VALUES ('Volkswagen'), ('Chevrolet')

INSERT INTO MODELO (idMarca, nomeModelo, anoModelo)
VALUES (1, 'Jetta', '2013'), (2, 'Onix', '2020')

INSERT INTO VEICULO (idEmpresa, idModelo, placa)
VALUES (1, 1, 'IUU1D72'), (1, 2, 'DIL3H49')
