create database DB_TRANSACCION_PRUEBA

go
use DB_TRANSACCION_PRUEBA
go
create schema prueba
go

create table prueba.CUENTAS
(
	nroCuenta_VC VARCHAR(14) primary key not null,
    tipo_CH CHAR(3) not null,
    moneda_CH CHAR(3) not null,
    nombre_DC VARCHAR(40) not null,
    saldo_DC DECIMAL(12, 2) not null
)
go
create table prueba.MOVIMIENTOS
(
	idMovimiento_IN INTEGER primary key identity,
    nroCuenta_VC VARCHAR(14) not null,
    fecha_DT DATETIME not null,
    tipo_CH CHAR(1) not null,
    importe_DC DECIMAL(12, 2) not null
)

alter table prueba.MOVIMIENTOS
add constraint FK_movimientos_cuentas
foreign key (nroCuenta_VC) references prueba.CUENTAS(nroCuenta_VC)