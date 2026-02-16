create database bdlojata;
use bdlojata;

create table clientes(
	# dados pessoais
    codigocli int primary key AUTO_INCREMENT,
    nomecli varchar(100),
    sexocli varchar(12),
    CPFcli varchar(50),
    dataNascimentocli varchar(12),
    
    # endereçamento
    enderecoTipocli varchar(10),
    logradourocli varchar(100),
    enderecoNumerocli int,
    bairrocli varchar(100),
    cepcli varchar(100),
    cidadecli varchar(50),
    UFcli varchar(2),
    
    # contato
    celularcli varchar(50),
    emailcli varchar(100),
    instagramcli varchar(100)
)