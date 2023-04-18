use [DB_TRANSACCION_PRUEBA]
go
create procedure prueba.addCuentas
	@nroCuenta_VC VARCHAR(14),
	@tipo_CH CHAR(3),
	@moneda_CH CHAR(3),
	@nombre_DC VARCHAR(40),
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
	insert into prueba.cuentas
		(
			nroCuenta_VC,
            tipo_CH,
            moneda_CH,
            nombre_DC,
            saldo_DC
		)
	values
		(
			@nroCuenta_VC,
            @tipo_CH,
            @moneda_CH,
            @nombre_DC,
            @saldo_DC
        );
end