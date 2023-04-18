use [DB_TRANSACCION_PRUEBA]
go
create procedure prueba.selectMovimiento_byNroCuenta
	@nroCuenta_VC VARCHAR(14)
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
	select
		idMovimiento_IN,
		nroCuenta_VC,
        fecha_DT,
        tipo_CH,
        importe_DC
	from prueba.MOVIMIENTOS
    where nroCuenta_VC = @nroCuenta_VC;
end