INSERT INTO Jogador (Nome, DataDeNascimento, Posicao, NumeroDeGols, Desarmes, Assistencias, Altura, EhCanhoto)
VALUES('Marcelo Vieira da Silva Júnior', '19800321', 3, 29, 0, 46, 176, 0)

INSERT INTO dadosDaCarreira(Biografia,ClubeAtual,idjogador) VALUES 
('Marcelo Vieira da Silva Júnior mais conhecido como Marcelo (Rio de Janeiro, 12 de maio de 1988) é um futebolista brasileiro que atua como lateral-esquerdo. Atualmente, joga pelo Real Madrid. Chegou ao Real Madrid em 2007 por 6 milhões de euros. Com o técnico Manuel Pellegrini começou a atuar com uma maior frequência, até como meia-esquerda. Agora sob o comando de José Mourinho, tornou-se titular absoluto em sua posição original, e tem sido constantemente elogiado pelo treinador e pela torcida. Na temporada 2010-2011 foi considerado um dos principais jogadores do Real Madrid, mantendo uma regularidade incrível, com gols e assistências Marcelo se tornou ídolo da torcida. Marcelo assumiu uma lacuna deixada por Roberto Carlos, jogador que durante 11 anos assumiu a responsabilidade de comandar a lateral-esquerda dos merengues. Após saída conturbada de Roberto Carlos, Marcelo foi conquistando aos poucos sua titularidade na lateral-esquerda. Foi eleito o melhor lateral-esquerdo da Europa na última temporada e por consequência é tido pela grande maioria dos especialistas o melhor lateral-esquerdo do mundo.', 17, SCOPE_IDENTITY())

DECLARE @dadosDaCarreira int
set @dadosDaCarreira = (select top 1 id from dadosdacarreira order by id desc)

INSERT INTO Titulo (ano,NomeDoCampeonato,QuantidadeDeGols,IdDadosDaCarreira) VALUES
(2005,'Campeonato Carioca', 3, @dadosDaCarreira)
INSERT INTO Titulo (ano,NomeDoCampeonato,QuantidadeDeGols,IdDadosDaCarreira) VALUES
(2005,'Taça Rio', 4, @dadosDaCarreira)
INSERT INTO Titulo (ano,NomeDoCampeonato,QuantidadeDeGols,IdDadosDaCarreira) VALUES
(2013,'Copa das Confederações', 4, @dadosDaCarreira)
INSERT INTO Titulo (ano,NomeDoCampeonato,QuantidadeDeGols,IdDadosDaCarreira) VALUES
(2014,'Copa do Mundo de Clubes da FIFA', 0, @dadosDaCarreira)
INSERT INTO Titulo (ano,NomeDoCampeonato,QuantidadeDeGols,IdDadosDaCarreira) VALUES
(2013,'Liga dos Campeões da UEFA', 6, @dadosDaCarreira)
INSERT INTO Titulo (ano,NomeDoCampeonato,QuantidadeDeGols,IdDadosDaCarreira) VALUES
(2014,'Liga dos Campeões da UEFA:', 2, @dadosDaCarreira)