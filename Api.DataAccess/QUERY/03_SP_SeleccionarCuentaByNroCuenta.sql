delimiter //
CREATE PROCEDURE selectCuenta_byNroCuenta(
	in _nroCuenta_VC VARCHAR(14)
    )
/* ***************************************************
Descripci�n: Seleccionar cuenta por el n�mero
Autor: Micael R. Chavez C.
FechaCreaci�n:	07/03/2023
FechaModificaci�n:
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