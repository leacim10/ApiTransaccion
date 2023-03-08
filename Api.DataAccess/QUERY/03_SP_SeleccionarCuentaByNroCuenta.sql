delimiter //
CREATE PROCEDURE selectCuenta_byNroCuenta(
	in _nroCuenta_VC VARCHAR(14)
    )
/* ***************************************************
Descripción: Seleccionar cuenta por el número
Autor: Micael R. Chavez C.
FechaCreación:	07/03/2023
FechaModificación:
*************************************************** */    
begin
	SELECT 
		nroCuenta_VC,
		tipo_CH,
        moneda_CH,
        nombre_DC,
        saldo_DC
    FROM `db_transacciones`.`cuentas`
    WHERE nroCuenta_VC = _nroCuenta_VC;
end//
delimiter ;