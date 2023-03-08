delimiter //
CREATE PROCEDURE addCuentas(
	in _nroCuenta_VC VARCHAR(14),
    in _tipo_CH CHAR(3),
    in _moneda_CH CHAR(3),
    in _nombre_DC VARCHAR(40),
    in _saldo_DC DECIMAL(12, 2)
    )
/* ***************************************************
Descripción: Insertar nuevas cuentas
Autor: Micael R. Chavez C.
FechaCreación:	07/03/2023
FechaModificación:
*************************************************** */    
begin
	insert into `db_transacciones`.`cuentas`
		(
			nroCuenta_VC,
            tipo_CH,
            moneda_CH,
            nombre_DC,
            saldo_DC
		)
	values
		(
			_nroCuenta_VC,
            _tipo_CH,
            _moneda_CH,
            _nombre_DC,
            _saldo_DC
        );
end//
delimiter ;