delimiter //
CREATE PROCEDURE updateCuenta_byNroCuenta(
	in _nroCuenta_VC VARCHAR(14),
    in _saldo_DC DECIMAL(12, 2)
    )
/* ***************************************************
Descripción: Actualizar saldo de cuenta
Autor: Micael R. Chavez C.
FechaCreación:	07/03/2023
FechaModificación:
*************************************************** */    
begin
	UPDATE CUENTA
	SET saldo_DC = _saldo_DC
	WHERE nroCuenta_VC = _nroCuenta_VC;
end//
delimiter ;