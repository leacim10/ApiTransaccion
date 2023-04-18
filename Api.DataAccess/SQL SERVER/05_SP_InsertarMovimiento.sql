use [DB_TRANSACCION_PRUEBA]
go
create procedure prueba.addMovimiento
	@nroCuenta_VC VARCHAR(14),
	@fecha_DT DATETIME,
	@tipo_CH CHAR(1),
	@importe_DC DECIMAL(12, 2)
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
	insert into prueba.MOVIMIENTOS
		(
			nroCuenta_VC,
            fecha_DT,
            tipo_CH,
            importe_DC
		)
	values
		(
			@nroCuenta_VC,
            @fecha_DT,
            @tipo_CH,
            @importe_DC
        );
end