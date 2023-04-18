use [DB_TRANSACCION_PRUEBA]
go
create procedure prueba.selectCuenta_byNroCuenta
	@nroCuenta_VC VARCHAR(14)
as
/*************************************************************
*	Descripcion: -
*	Fecha Crea: 17/04/2023
*	Fecha Mod:
*	Parametros: 
*	Autor: Mikael Chavez
*	Versi�n:BETA 
*	Cambios Importantes: 
**************************************************************/
begin 
	SELECT 
		nroCuenta_VC,
		tipo_CH,
        moneda_CH,
        nombre_DC,
        saldo_DC
    FROM prueba.CUENTAS
    WHERE nroCuenta_VC = @nroCuenta_VC;
end