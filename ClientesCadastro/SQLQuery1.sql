create database Clientes;
use Clientes;
create table Cliente ( nome varchar(25), telefone varchar(9), email varchar(25), ID int identity(1,1));
Insert Into Cliente (nome, telefone, email) Values ('Nadia', '32575054', 'OK@terra.com');
select * from Cliente;