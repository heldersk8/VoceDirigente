INSERT INTO Jogador (Nome, DataDeNascimento, Posicao, NumeroDeGols, Desarmes, Assistencias, Altura, EhCanhoto)
VALUES('Francisco Guillermo Ochoa Maga�a', '1985-07-13 00:00:00.998', 1, 0, 0, 0, 183000, 1)
GO
INSERT INTO dadosDaCarreira(Biografia,ClubeAtual,idjogador) VALUES 
('Francisco Guillermo Ochoa Maga�a (Guadalajara, 13 de julho de 1985) � um futebolista mexicano que atua como goleiro. Defende o M�laga. Ochoa foi revelado no Am�rica onde atuou entre 2004 e 2011, quando transferiu-se ao clube franc�s AC Ajaccio. Em 1 de agosto de 2014 assinou contrato por tr�s temporadas com o M�laga.', 12, SCOPE_IDENTITY())

GO
DECLARE @dadosDaCarreira int
set @dadosDaCarreira = (select top 1 id from dadosdacarreira order by id desc)

INSERT INTO Titulo (ano,NomeDoCampeonato,QuantidadeDeGols,IdDadosDaCarreira) VALUES
(2008,'Torneo Ol�mpico de F�tbol de 2008', 0, @dadosDaCarreira)
INSERT INTO Titulo (ano,NomeDoCampeonato,QuantidadeDeGols,IdDadosDaCarreira) VALUES
(2010,'Eliminatorias Sudamericanas 2010', 2, @dadosDaCarreira)
INSERT INTO Titulo (ano,NomeDoCampeonato,QuantidadeDeGols,IdDadosDaCarreira) VALUES
(2010,'Copa Mundial de la FIFA 2010', 6, @dadosDaCarreira)
INSERT INTO Titulo (ano,NomeDoCampeonato,QuantidadeDeGols,IdDadosDaCarreira) VALUES
(2011,'Copa Am�rica 2011', 2, @dadosDaCarreira)
INSERT INTO Titulo (ano,NomeDoCampeonato,QuantidadeDeGols,IdDadosDaCarreira) VALUES
(2014,'Eliminatorias Sudamericanas 2014', 12, @dadosDaCarreira)
INSERT INTO Titulo (ano,NomeDoCampeonato,QuantidadeDeGols,IdDadosDaCarreira) VALUES
(2014,'Copa Mundial de la FIFA 2014', 4, @dadosDaCarreira)
INSERT INTO Titulo (ano,NomeDoCampeonato,QuantidadeDeGols,IdDadosDaCarreira) VALUES
(2015,'Copa Am�rica 2015', 3, @dadosDaCarreira)