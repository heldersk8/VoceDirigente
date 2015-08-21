INSERT INTO Jogador (Nome, DataDeNascimento, Posicao, NumeroDeGols, Desarmes, Assistencias, Altura, EhCanhoto)
VALUES('Marcelo Vieira da Silva J�nior', '19800321', 3, 29, 0, 46, 176, 0)

INSERT INTO dadosDaCarreira(Biografia,ClubeAtual,idjogador) VALUES 
('Marcelo Vieira da Silva J�nior mais conhecido como Marcelo (Rio de Janeiro, 12 de maio de 1988) � um futebolista brasileiro que atua como lateral-esquerdo. Atualmente, joga pelo Real Madrid. Chegou ao Real Madrid em 2007 por 6 milh�es de euros. Com o t�cnico Manuel Pellegrini come�ou a atuar com uma maior frequ�ncia, at� como meia-esquerda. Agora sob o comando de Jos� Mourinho, tornou-se titular absoluto em sua posi��o original, e tem sido constantemente elogiado pelo treinador e pela torcida. Na temporada 2010-2011 foi considerado um dos principais jogadores do Real Madrid, mantendo uma regularidade incr�vel, com gols e assist�ncias Marcelo se tornou �dolo da torcida. Marcelo assumiu uma lacuna deixada por Roberto Carlos, jogador que durante 11 anos assumiu a responsabilidade de comandar a lateral-esquerda dos merengues. Ap�s sa�da conturbada de Roberto Carlos, Marcelo foi conquistando aos poucos sua titularidade na lateral-esquerda. Foi eleito o melhor lateral-esquerdo da Europa na �ltima temporada e por consequ�ncia � tido pela grande maioria dos especialistas o melhor lateral-esquerdo do mundo.', 17, SCOPE_IDENTITY())

DECLARE @dadosDaCarreira int
set @dadosDaCarreira = (select top 1 id from dadosdacarreira order by id desc)

INSERT INTO Titulo (ano,NomeDoCampeonato,QuantidadeDeGols,IdDadosDaCarreira) VALUES
(2005,'Campeonato Carioca', 3, @dadosDaCarreira)
INSERT INTO Titulo (ano,NomeDoCampeonato,QuantidadeDeGols,IdDadosDaCarreira) VALUES
(2005,'Ta�a Rio', 4, @dadosDaCarreira)
INSERT INTO Titulo (ano,NomeDoCampeonato,QuantidadeDeGols,IdDadosDaCarreira) VALUES
(2013,'Copa das Confedera��es', 4, @dadosDaCarreira)
INSERT INTO Titulo (ano,NomeDoCampeonato,QuantidadeDeGols,IdDadosDaCarreira) VALUES
(2014,'Copa do Mundo de Clubes da FIFA', 0, @dadosDaCarreira)
INSERT INTO Titulo (ano,NomeDoCampeonato,QuantidadeDeGols,IdDadosDaCarreira) VALUES
(2013,'Liga dos Campe�es da UEFA', 6, @dadosDaCarreira)
INSERT INTO Titulo (ano,NomeDoCampeonato,QuantidadeDeGols,IdDadosDaCarreira) VALUES
(2014,'Liga dos Campe�es da UEFA:', 2, @dadosDaCarreira)