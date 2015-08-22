INSERT INTO Jogador (Apelido, Nome, DataDeNascimento, Posicao, NumeroDeGols, Desarmes, Assistencias, Altura, EhCanhoto)
VALUES('Ronaldinho Ga�cho', 'Ronaldo de Assis Moreira', '19800321', 4, 305, 0, 163, 180, 0)

DECLARE @IdJogador INT
SET @IdJogador = SCOPE_IDENTITY();

INSERT INTO dadosDaCarreira(Biografia,ClubeAtual,idjogador) VALUES 
('Ronaldo de Assis Moreira, mais conhecido como Ronaldinho Ga�cho ou simplesmente Ronaldinho (Porto Alegre, 21 de mar�o de 1980), � um futebolista brasileiro que atua como meia e atacante. Atualmente, defende o Fluminense. Uma de suas marcas registradas � o aspecto dentu�o, seus dribles fant�sticos e usar uma faixa na cabe�a ap�s adotar os cabelos longos. Extremamente habilidoso e muito preciso em seus chutes e passes, � considerado por muitos especialistas como o futebolista mais talentoso de sua gera��o. Venceu o pr�mio "Melhor jogador do mundo pela FIFA" em 2004 e 2005, �poca em que viveu o grande auge de sua carreira.', 16, @IdJogador)

DECLARE @dadosDaCarreira int
set @dadosDaCarreira = (select top 1 id from dadosdacarreira order by id desc)

INSERT INTO Titulo (ano,NomeDoCampeonato,QuantidadeDeGols,IdDadosDaCarreira) VALUES
(2001,'UEFA Intertoto Cup', 3, @dadosDaCarreira)
INSERT INTO Titulo (ano,NomeDoCampeonato,QuantidadeDeGols,IdDadosDaCarreira) VALUES
(2005,'Supercopa da Espanha', 4, @dadosDaCarreira)
INSERT INTO Titulo (ano,NomeDoCampeonato,QuantidadeDeGols,IdDadosDaCarreira) VALUES
(2014,'Recopa Sul-Americana', 4, @dadosDaCarreira)

INSERT INTO Doador(Nome,CartaoDeCredito) VALUES ('Carol Writti', 4916340777223012)
INSERT INTO Doador(Nome,CartaoDeCredito) VALUES ('Samuel Cavalcante', 4532691549449770)

INSERT INTO Doacao (IdDoador, IdJogador, Valor) VALUES ( 1, @IdJogador, 1000)
INSERT INTO Doacao (IdDoador, IdJogador, Valor) VALUES ( 3, @IdJogador, 200)