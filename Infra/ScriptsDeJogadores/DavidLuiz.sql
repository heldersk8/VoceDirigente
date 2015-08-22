INSERT INTO Jogador (Apelido, Altura,Assistencias,DataDeNascimento,Desarmes, ehcanhoto,Nome,NumeroDeGols,Posicao)
VALUES  ('David Luiz', 189,4,'19870422',80,0,'David Luiz',4, 2)

DECLARE @IdJogador INT
SET @IdJogador = SCOPE_IDENTITY();

INSERT INTO dadosDaCarreira(Biografia,ClubeAtual,idjogador) VALUES 
('David começou no São Paulo Futebol Clube ainda criança com 12 anos, ficou no clube de 1999 até 2001, mas não teve muita sorte no clube, foi dispensado por ser muito franzino. Depois de um tempo foi para o Vitória, clube no qual passou a maior parte de sua carreira. Foram seis anos incluindo as categorias de base. Atuou inicialmente como central (meio-de-campo) e depois como zagueiro. Após apenas um ano no time profissional, foi emprestado e, meses depois, vendido ao Benfica, onde rapidamente se firmou. Permaneceu no clube português até 2011, quando foi contratado pelo Chelsea. Um ano antes, recebeu também sua primeira convocação para a Seleção Brasileira, tornando-se titular ao lado de Thiago Silva.', 11, @IdJogador)
DECLARE @dadosDaCarreira int
set @dadosDaCarreira = (select top 1 id from dadosdacarreira order by id desc)

INSERT INTO Titulo (ano,NomeDoCampeonato,QuantidadeDeGols,IdDadosDaCarreira) VALUES
(2008,'TAÇA DA LIGA',2,@dadosDaCarreira)
INSERT INTO Titulo (ano,NomeDoCampeonato,QuantidadeDeGols,IdDadosDaCarreira) VALUES
(2012,'LIGA DOS CAMPEÕES DA UEFA',2,@dadosDaCarreira)
INSERT INTO Titulo (ano,NomeDoCampeonato,QuantidadeDeGols,IdDadosDaCarreira) VALUES
(2015,'CAMPEONATO FRANCÊS',2,@dadosDaCarreira)
INSERT INTO Titulo (ano,NomeDoCampeonato,QuantidadeDeGols,IdDadosDaCarreira) VALUES
(2015,'COPA DA FRANÇA',2,@dadosDaCarreira)

INSERT INTO Doador(Nome,CartaoDeCredito) VALUES ('Jorge Luiz Gomes da Silva', 4485509599757131)

INSERT INTO Doacao (IdDoador, IdJogador, Valor) VALUES ( 1, @IdJogador, 600)
INSERT INTO Doacao (IdDoador, IdJogador, Valor) VALUES ( 2, @IdJogador, 50)
INSERT INTO Doacao (IdDoador, IdJogador, Valor) VALUES ( 3, @IdJogador, 300)
