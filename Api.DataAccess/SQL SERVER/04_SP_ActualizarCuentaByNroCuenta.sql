use [DB_TRANSACCION_PRUEBA]
go
create procedure prueba.updateCuenta_byNroCuenta
	@nroCuenta_VC VARCHAR(14),
	@saldo_DC DECIMAL(12, 2)
as
/*************************************************************
*	Descripcion: -
*	Fecha Crea: 17/04/2023
*	Fecha Mod:
*	Parametros: 
*	Autor: Mikael Chavez
*	Versión:BETA 
*	Cambios Importantes: 
**************************************************************/
begin 
	UPDATE prueba.CUENTAS
	SET saldo_DC = @saldo_DC
	WHERE nroCuenta_VC = @nroCuenta_VC;
end