INSERT INTO Jogador (Nome, DataDeNascimento, Posicao, NumeroDeGols, Desarmes, Assistencias, Altura, EhCanhoto)
VALUES('Jefferson de Oliveira Galvão', '19870102', 1, 0, 0, 0, 189, 1)
GO
INSERT INTO dadosDaCarreira(Biografia,ClubeAtual,idjogador) VALUES 
('Luiz Felipe Ventura dos Santos, mais conhecido apenas como Felipe (Rio de Janeiro, 22 de fevereiro de 1984), é um futebolista brasileiro que joga como goleiro. Atualmente, joga pelo Figueirense.', 12, SCOPE_IDENTITY())

GO
DECLARE @dadosDaCarreira int
set @dadosDaCarreira = (select top 1 id from dadosdacarreira order by id desc)

INSERT INTO Titulo (ano,NomeDoCampeonato,QuantidadeDeGols,IdDadosDaCarreira) VALUES
(2001,'Copa Sul-Minas', 0, @dadosDaCarreira)
INSERT INTO Titulo (ano,NomeDoCampeonato,QuantidadeDeGols,IdDadosDaCarreira) VALUES
(2002,'Copa Sul-Minas', 0, @dadosDaCarreira)
INSERT INTO Titulo (ano,NomeDoCampeonato,QuantidadeDeGols,IdDadosDaCarreira) VALUES
(2010,'Campeonato Carioca', 6, @dadosDaCarreira)
INSERT INTO Titulo (ano,NomeDoCampeonato,QuantidadeDeGols,IdDadosDaCarreira) VALUES
(2013,'Campeonato Carioca', 2, @dadosDaCarreira)