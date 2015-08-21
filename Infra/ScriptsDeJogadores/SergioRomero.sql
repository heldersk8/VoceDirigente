INSERT INTO Jogador (Nome, DataDeNascimento, Posicao, NumeroDeGols, Desarmes, Assistencias, Altura, EhCanhoto)
VALUES('Sergio Germán Romero', '19870222', 1, 0, 0, 0, 192, 0)

GO
INSERT INTO dadosDaCarreira(Biografia,ClubeAtual,idjogador) VALUES 
('Sergio Germán Romero é um futebolista argentino que atua como goleiro. Defende atualmente o Manchester United. Mesmo a Sampdoria tendo sido rebaixada na temporada de 2010–11 a Serie B, foi anunciada sua transferência para a mesma em 22 de agosto de 2011. Em 17 de agosto de 2013, foi cedido por empréstimo de um ano, com opção de compra, para o Monaco. Foi contratado pelo Manchester United em 26 de julho de 2015 para três temporadas.', 11, SCOPE_IDENTITY())

GO
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