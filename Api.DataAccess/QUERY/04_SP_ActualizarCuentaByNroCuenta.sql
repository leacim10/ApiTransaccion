delimiter //
CREATE PROCEDURE updateCuenta_byNroCuenta(
	in _nroCuenta_VC VARCHAR(14),
    in _saldo_DC DECIMAL(12, 2)
    )
/* ***************************************************
Descripci�n: Actualizar saldo de cuenta
Autor: Micael R. Chavez C.
FechaCreaci�n:	07/03/2023
FechaModificaci�n:
*************************************************** */    
begin
	UPDATE CUENTA
	SET saldo_DC = _saldo_DC
	WHERE nroCuenta_VC = _nroCuenta_VC;
end//
delimiter ;