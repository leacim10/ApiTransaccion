use [DB_TRANSACCION_PRUEBA]
go
create procedure prueba.selectCuentas
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
	SELECT 
		nroCuenta_VC,
		tipo_CH,
        moneda_CH,
        nombre_DC,
        saldo_DC
    FROM prueba.CUENTAS;
end