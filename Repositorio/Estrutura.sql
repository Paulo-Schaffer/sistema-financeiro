CREATE TABLE contasPagar(
id INT PRIMARY KEY IDENTITY(1,1),
nome VARCHAR(50),
valor DECIMAL(15),
tipo VARCHAR(50),
data_vencimento DATE
);
CREATE TABLE clientes(
id INT PRIMARY KEY IDENTITY(1,1),
nome VARCHAR(50),
cpf VARCHAR(14),
data_nascimento DATE,
rg VARCHAR(9)
); 
SELECT * FROM clientes;
CREATE TABLE contasReceber(
id INT PRIMARY KEY IDENTITY(1,1),
nome VARCHAR(50),
valor DECIMAL(15),
tipo VARCHAR(50),
data_vencimento DATE
);
