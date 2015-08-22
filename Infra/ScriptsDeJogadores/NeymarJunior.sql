INSERT INTO Jogador (Apelido, Nome, DataDeNascimento, Posicao, NumeroDeGols, Desarmes, Assistencias, Altura, EhCanhoto)
VALUES('Neymar Jr', 'Neymar da Silva Santos Júnior', '19920205', 5, 196, 0, 88, 175, 0)

DECLARE @IdJogador INT
SET @IdJogador = SCOPE_IDENTITY();

INSERT INTO dadosDaCarreira(Biografia,ClubeAtual,idjogador) VALUES 
('Neymar da Silva Santos Júnior (Mogi das Cruzes, 5 de fevereiro de 1992), geralmente referido como Neymar ou Neymar Jr., é um futebolista brasileiro que atualmente defende o clube espanhol Barcelona e é o capitão da seleção brasileira.', 15, @IdJogador)

DECLARE @dadosDaCarreira int
set @dadosDaCarreira = (select top 1 id from dadosdacarreira order by id desc)

INSERT INTO Titulo (ano,NomeDoCampeonato,QuantidadeDeGols,IdDadosDaCarreira) VALUES
(2010,'Campeonato Paulista', 0, @dadosDaCarreira)
INSERT INTO Titulo (ano,NomeDoCampeonato,QuantidadeDeGols,IdDadosDaCarreira) VALUES
(2011,'Copa Libertadores da América', 0, @dadosDaCarreira)
INSERT INTO Titulo (ano,NomeDoCampeonato,QuantidadeDeGols,IdDadosDaCarreira) VALUES
(2012,'Recopa Sul-Americana', 0, @dadosDaCarreira)
INSERT INTO Titulo (ano,NomeDoCampeonato,QuantidadeDeGols,IdDadosDaCarreira) VALUES
(2014,'Troféu Joan Gamper', 0, @dadosDaCarreira)
INSERT INTO Titulo (ano,NomeDoCampeonato,QuantidadeDeGols,IdDadosDaCarreira) VALUES
(2013,'Supercopa da Espanha', 6, @dadosDaCarreira)
INSERT INTO Titulo (ano,NomeDoCampeonato,QuantidadeDeGols,IdDadosDaCarreira) VALUES
(2015,'Liga dos Campeões da UEFA:', 2, @dadosDaCarreira)

INSERT INTO Doador(Nome,CartaoDeCredito) VALUES ('Sandro Yamasaki', 4556461070569326)
INSERT INTO Doador(Nome,CartaoDeCredito) VALUES ('Helder Pereira', 4556461070569326)
INSERT INTO Doador(Nome,CartaoDeCredito) VALUES ('Renan Moura', 4556461070569326)

INSERT INTO Doacao (IdDoador, IdJogador, Valor) VALUES ( 2, @IdJogador, 3000)
INSERT INTO Doacao (IdDoador, IdJogador, Valor) VALUES ( 1, @IdJogador, 100)
INSERT INTO Doacao (IdDoador, IdJogador, Valor) VALUES ( 3, @IdJogador, 100)