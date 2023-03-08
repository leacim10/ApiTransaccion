delimiter //
CREATE PROCEDURE selectMovimiento_byNroCuenta(
	in _nroCuenta_VC VARCHAR(14)
    )
/* ***************************************************
Descripci�n: Insertar nuevos movimientos
Autor: Micael R. Chavez C.
FechaCreaci�n:	07/03/2023
FechaModificaci�n:
*************************************************** */    
begin
	select
		idMovimiento_IN,
		nroCuenta_VC,
        fecha_DT,
        tipo_CH,
        importe_DC
	from `db_transacciones`.`movimientos`
    where nroCuenta_VC = _nroCuenta_VC;
end//
delimiter ;