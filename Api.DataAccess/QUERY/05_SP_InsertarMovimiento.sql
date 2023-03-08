delimiter //
CREATE PROCEDURE addMovimiento(
	in _nroCuenta_VC VARCHAR(14),
    in _fecha_DT DATETIME,
    in _tipo_CH CHAR(1),
    in _importe_DC DECIMAL(12, 2)
    )
/* ***************************************************
Descripci�n: Insertar nuevos movimientos
Autor: Micael R. Chavez C.
FechaCreaci�n:	07/03/2023
FechaModificaci�n:
*************************************************** */    
begin
	insert into `db_transacciones`.`movimientos`
		(
			nroCuenta_VC,
            fecha_DT,
            tipo_CH,
            importe_DC
		)
	values
		(
			_nroCuenta_VC,
            _fecha_DT,
            _tipo_CH,
            _importe_DC
        );
end//
delimiter ;