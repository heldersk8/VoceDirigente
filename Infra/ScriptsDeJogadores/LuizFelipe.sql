INSERT INTO Jogador (Nome, DataDeNascimento, Posicao, NumeroDeGols, Desarmes, Assistencias, Altura, EhCanhoto)
VALUES('Luiz Felipe Ventura dos Santos', '19840222', 1, 0, 0, 0, 191, 0)
GO
INSERT INTO dadosDaCarreira(Biografia,ClubeAtual,idjogador) VALUES 
('Luiz Felipe Ventura dos Santos, mais conhecido apenas como Felipe (Rio de Janeiro, 22 de fevereiro de 1984), é um futebolista brasileiro que joga como goleiro. Atualmente, joga pelo Figueirense.', 12, SCOPE_IDENTITY())

GO
DECLARE @dadosDaCarreira int
set @dadosDaCarreira = (select top 1 id from dadosdacarreira order by id desc)

INSERT INTO Titulo (ano,NomeDoCampeonato,QuantidadeDeGols,IdDadosDaCarreira) VALUES
(2009,'Campeonato Paulista', 0, @dadosDaCarreira)
INSERT INTO Titulo (ano,NomeDoCampeonato,QuantidadeDeGols,IdDadosDaCarreira) VALUES
(2009,'Copa do Brasil', 0, @dadosDaCarreira)
INSERT INTO Titulo (ano,NomeDoCampeonato,QuantidadeDeGols,IdDadosDaCarreira) VALUES
(2010,'Libertadores', 6, @dadosDaCarreira)
