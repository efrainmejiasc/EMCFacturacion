DECLARE @tablaResumen TABLE ( Cuenta VARCHAR(50), Descripcion VARCHAR(100),Inicio FLOAT, Debito FLOAT, Credito FLOAT , Saldo  FLOAT);
DECLARE @tablaCuenta TABLE ( Cuenta VARCHAR(50), Descripcion VARCHAR(100));
INSERT INTO  @tablaCuenta ( Cuenta, Descripcion ) (SELECT Cuenta, Descripcion FROM EstructuraCuenta WHERE Cuenta <> '' GROUP BY Cuenta,Descripcion );
DECLARE @nCuenta  INT = (SELECT COUNT(*) FROM @tablaCuenta);
--SELECT @nCuenta;
--SELECT * FROM @tablaCuenta
DECLARE @jsonCuenta  VARCHAR(MAX) = (SELECT * FROM @tablaCuenta FOR JSON PATH);
--SELECT @jsonCuenta;
DECLARE @i INT = 1;
DECLARE @propiedad VARCHAR(100); 
DECLARE @propiedad2 VARCHAR(100);
DECLARE @codigoCuenta VARCHAR(50);
DECLARE @descripcionCuenta VARCHAR(100);
DECLARE @Inicio FLOAT;
DECLARE @Credito FLOAT;
DECLARE @Debito FLOAT;
DECLARE @Saldo FLOAT;


  WHILE (@i <= @nCuenta)
	    BEGIN
	    SET @propiedad = CONCAT('$[', @i ,'].Cuenta');
		SET @propiedad2 = CONCAT('$[', @i ,'].Descripcion');
        --SELECT @propiedad;,
		SET @codigoCuenta = JSON_VALUE(@jsonCuenta, @propiedad);
		SET @descripcionCuenta = JSON_VALUE(@jsonCuenta, @propiedad2);
		--SELECT @codigoCuenta AS 'CodigoCuenta';
		--SELECT @descripcionCuenta AS 'DescripcionCuenta';
		SET @Inicio = (SELECT  ISNULL(SUM(Debito + Credito),0)  FROM SaldoCuenta WHERE Cuenta_Id = @codigoCuenta AND  Periodo_id = 1);
		SET @Debito = (SELECT ISNULL(SUM(Debito),0) FROM SaldoCuenta WHERE Cuenta_Id = @codigoCuenta AND  Periodo_id >= 2  AND Periodo_Id <= 6);
		SET @Credito = (SELECT ISNULL(SUM(Credito),0) FROM SaldoCuenta WHERE Cuenta_Id = @codigoCuenta AND  Periodo_id >= 2  AND Periodo_Id <= 6);
		SET @Saldo = @Inicio + @Debito - @Credito;

		IF(@DEBITO > 0 OR @CREDITO > 0)
		   BEGIN 
		              INSERT INTO @tablaResumen VALUES( @codigoCuenta, @descripcionCuenta, @Inicio, @Debito, @Credito, @Saldo);
           END
	    SET @i = @i+1;
     END

	 SELECT * FROM @tablaResumen