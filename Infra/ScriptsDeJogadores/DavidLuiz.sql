INSERT INTO Jogador (Apelido, Altura,Assistencias,DataDeNascimento,Desarmes, ehcanhoto,Nome,NumeroDeGols,Posicao)
VALUES  ('David Luiz', 189,4,'19870422',80,0,'David Luiz',4, 2)

DECLARE @IdJogador INT
SET @IdJogador = SCOPE_IDENTITY();

INSERT INTO dadosDaCarreira(Biografia,ClubeAtual,idjogador) VALUES 
('David come�ou no S�o Paulo Futebol Clube ainda crian�a com 12 anos, ficou no clube de 1999 at� 2001, mas n�o teve muita sorte no clube, foi dispensado por ser muito franzino. Depois de um tempo foi para o Vit�ria, clube no qual passou a maior parte de sua carreira. Foram seis anos incluindo as categorias de base. Atuou inicialmente como central (meio-de-campo) e depois como zagueiro. Ap�s apenas um ano no time profissional, foi emprestado e, meses depois, vendido ao Benfica, onde rapidamente se firmou. Permaneceu no clube portugu�s at� 2011, quando foi contratado pelo Chelsea. Um ano antes, recebeu tamb�m sua primeira convoca��o para a Sele��o Brasileira, tornando-se titular ao lado de Thiago Silva.', 11, @IdJogador)
DECLARE @dadosDaCarreira int
set @dadosDaCarreira = (select top 1 id from dadosdacarreira order by id desc)

INSERT INTO Titulo (ano,NomeDoCampeonato,QuantidadeDeGols,IdDadosDaCarreira) VALUES
(2008,'TA�A DA LIGA',2,@dadosDaCarreira)
INSERT INTO Titulo (ano,NomeDoCampeonato,QuantidadeDeGols,IdDadosDaCarreira) VALUES
(2012,'LIGA DOS CAMPE�ES DA UEFA',2,@dadosDaCarreira)
INSERT INTO Titulo (ano,NomeDoCampeonato,QuantidadeDeGols,IdDadosDaCarreira) VALUES
(2015,'CAMPEONATO FRANC�S',2,@dadosDaCarreira)
INSERT INTO Titulo (ano,NomeDoCampeonato,QuantidadeDeGols,IdDadosDaCarreira) VALUES
(2015,'COPA DA FRAN�A',2,@dadosDaCarreira)

INSERT INTO Doador(Nome,CartaoDeCredito) VALUES ('Jorge Luiz Gomes da Silva', 4485509599757131)

INSERT INTO Doacao (IdDoador, IdJogador, Valor) VALUES ( 1, @IdJogador, 600)
INSERT INTO Doacao (IdDoador, IdJogador, Valor) VALUES ( 2, @IdJogador, 50)
INSERT INTO Doacao (IdDoador, IdJogador, Valor) VALUES ( 3, @IdJogador, 300)
