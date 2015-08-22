INSERT INTO Jogador (Apelido, Nome, DataDeNascimento, Posicao, NumeroDeGols, Desarmes, Assistencias, Altura, EhCanhoto)
VALUES('Ochoa', 'Francisco Guillermo Ochoa Magaña', '19920205', 1, 0, 0, 0, 180, 0)

DECLARE @IdJogador INT
SET @IdJogador = SCOPE_IDENTITY();

INSERT INTO dadosDaCarreira(Biografia,ClubeAtual,idjogador) VALUES 
('Francisco Guillermo Ochoa Magaña (Guadalajara, 13 de julho de 1985) é um futebolista mexicano que atua como goleiro. Defende o Málaga. Ochoa foi revelado no América onde atuou entre 2004 e 2011, quando transferiu-se ao clube francês AC Ajaccio. Em 1 de agosto de 2014 assinou contrato por três temporadas com o Málaga.', 12, @IdJogador)

DECLARE @dadosDaCarreira int
set @dadosDaCarreira = (select top 1 id from dadosdacarreira order by id desc)

INSERT INTO Titulo (ano,NomeDoCampeonato,QuantidadeDeGols,IdDadosDaCarreira) VALUES
(2008,'Torneo Olímpico de Fútbol de 2008', 0, @dadosDaCarreira)
INSERT INTO Titulo (ano,NomeDoCampeonato,QuantidadeDeGols,IdDadosDaCarreira) VALUES
(2010,'Eliminatorias Sudamericanas 2010', 2, @dadosDaCarreira)
INSERT INTO Titulo (ano,NomeDoCampeonato,QuantidadeDeGols,IdDadosDaCarreira) VALUES
(2010,'Copa Mundial de la FIFA 2010', 6, @dadosDaCarreira)
INSERT INTO Titulo (ano,NomeDoCampeonato,QuantidadeDeGols,IdDadosDaCarreira) VALUES
(2011,'Copa América 2011', 2, @dadosDaCarreira)
INSERT INTO Titulo (ano,NomeDoCampeonato,QuantidadeDeGols,IdDadosDaCarreira) VALUES
(2014,'Eliminatorias Sudamericanas 2014', 12, @dadosDaCarreira)
INSERT INTO Titulo (ano,NomeDoCampeonato,QuantidadeDeGols,IdDadosDaCarreira) VALUES
(2014,'Copa Mundial de la FIFA 2014', 4, @dadosDaCarreira)
INSERT INTO Titulo (ano,NomeDoCampeonato,QuantidadeDeGols,IdDadosDaCarreira) VALUES
(2015,'Copa América 2015', 3, @dadosDaCarreira)

INSERT INTO Doador(Nome,CartaoDeCredito) VALUES ('Glauber Laender', 4556461070569326)

INSERT INTO Doacao (IdDoador, IdJogador, Valor) VALUES ( 1, @IdJogador, 00)
INSERT INTO Doacao (IdDoador, IdJogador, Valor) VALUES ( 2, @IdJogador, 20)