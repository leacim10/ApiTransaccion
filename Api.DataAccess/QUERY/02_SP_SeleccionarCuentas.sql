delimiter //
CREATE PROCEDURE selectCuentas()
/* ***************************************************
Descripción: Seleccionar las cuentas
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
    FROM `db_transacciones`.`cuentas`;
end//
delimiter ;