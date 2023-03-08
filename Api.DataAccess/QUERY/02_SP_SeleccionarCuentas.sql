delimiter //
CREATE PROCEDURE selectCuentas()
/* ***************************************************
Descripci�n: Seleccionar las cuentas
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
    FROM `db_transacciones`.`cuentas`;
end//
delimiter ;