CREATE SCHEMA `DB_TRANSACCIONES`;

CREATE TABLE `DB_TRANSACCIONES`.`CUENTAS`
(
	nroCuenta_VC VARCHAR(14) UNIQUE not null,
    tipo_CH CHAR(3) not null,
    moneda_CH CHAR(3) not null,
    nombre_DC VARCHAR(40) not null,
    saldo_DC DECIMAL(12, 2) not null,
    PRIMARY KEY (`nroCuenta_VC`)
);

CREATE TABLE `DB_TRANSACCIONES`.`MOVIMIENTOS`
(
	idMovimiento_IN INT not null AUTO_INCREMENT,
    nroCuenta_VC VARCHAR(14) not null,
    fecha_DT DATETIME not null,
    tipo_CH CHAR(1) not null,
    importe_DC DECIMAL(12, 2) not null,
    PRIMARY KEY (`idMovimiento_IN`),
    INDEX `FK_MOVIMIENTOS_CUENTAS_idx` (`nroCuenta_VC` ASC) visible,
    CONSTRAINT `FK_MOVIMIENTOS_CUENTAS`
		FOREIGN KEY(`nroCuenta_VC`)
        REFERENCES `DB_TRANSACCIONES`.`CUENTAS` (`nroCuenta_VC`)
        ON DELETE NO ACTION
        ON UPDATE NO ACTION
)