
SELECT * FROM USUARIO
SELECT * FROM EMPRESA
SELECT * FROM PROVEEDOR
SELECT * FROM CLIENTE

SELECT * FROM PRODUCTO

SELECT * FROM FacturaCompra
SELECT * FROM FacturaCompraDetalle

SELECT * FROM FacturaVenta
SELECT * FROM FacturaVentaDetalle

SELECT * FROM StockTotal



SELECT * FROM ROLES
SELECT * FROM MetodoPago
SELECT * FROM UnidadMedida
SELECT * FROM TipoFactura
SELECT * FROM InicioFacturacion

--TRUNCATE TABLE FacturaVenta
--TRUNCATE TABLE FacturaVentaDetalle
--TRUNCATE TABLE FacturaCompra
--TRUNCATE TABLE FacturaCompraDetalle
--TRUNCATE TABLE StockTotal


--TRUNCATE TABLE Producto
--TRUNCATE TABLE USUARIO

--INSERT INTO TipoFactura VALUES ('COMPRA')
--INSERT INTO TipoFactura VALUES ('VENTA')

--INSERT INTO ROLES VALUES ('ADMINISTRADOR')
--INSERT INTO ROLES VALUES ('CLIENTE')
--INSERT INTO ROLES VALUES ('VENDEDOR')
--INSERT INTO ROLES VALUES ('ROOT')

--INSERT INTO MetodoPago VALUES('Cash', 'EN-US')
--INSERT INTO MetodoPago VALUES('Credit', 'EN-US')
--INSERT INTO MetodoPago VALUES('Credit Card', 'EN-US')
--INSERT INTO MetodoPago VALUES('Debit Card', 'EN-US')
--INSERT INTO MetodoPago VALUES('Bank Transfer', 'EN-US')

--INSERT INTO UNIDADMEDIDA (UNIDAD, IdEmpresa, Sistema) VALUES ('Unit',1,'EN-US')
--INSERT INTO UNIDADMEDIDA (UNIDAD, IdEmpresa, Sistema) VALUES ('Gallon',1,'EN-US')
--INSERT INTO UNIDADMEDIDA (UNIDAD, IdEmpresa, Sistema) VALUES ('Foot',1,'EN-US')
--INSERT INTO UNIDADMEDIDA (UNIDAD, IdEmpresa, Sistema) VALUES ('Pound',1,'EN-US')

--INSERT INTO UNIDADMEDIDA (UNIDAD, IdEmpresa, Sistema) VALUES ('Unidad',2,'ES-VE')
--INSERT INTO UNIDADMEDIDA (UNIDAD, IdEmpresa, Sistema) VALUES ('Litro',2,'ES-VE')
--INSERT INTO UNIDADMEDIDA (UNIDAD, IdEmpresa, Sistema) VALUES ('Kilo',2,'ES-VE')
--INSERT INTO UNIDADMEDIDA (UNIDAD, IdEmpresa, Sistema) VALUES ('Metro',2,'ES-VE')


--INSERT INTO EMPRESA VALUES ('4F0EF2D3-A470-4B2D-B2EF-A9B8A8EE1777','EMC Software','V-11346727','efrainmejiasc@hotmail.com','04244133677','Valencia-Venezuela',GetDate(),GetDate(),1)
--INSERT INTO USUARIO VALUES ('admin@hotmail.com',1,'admin','admin','admin','YWRtaW5AaG90bWFpbC5jb21hZG1pbg==','YWRtaW4xMjM0',GetDate(),1,1)

--INSERT INTO USUARIO VALUES ('efrainmejiasc@hotmail.com',2,'Efrain','Mejias','efrain','ZWZyYWlubWVqaWFzY0Bob3RtYWlsLmNvbTEyMzQ=','ZWZyYWluMTIzNA==',GetDate(),1,4)

--UPDATE USUARIO SET Password2 = 'YWRtaW5hZG1pbg=='
--UPDATE Proveedor SET IdEmpresa = 2
--UPDATE Cliente SET IdEmpresa = 1
--UPDATE UnidadMedida SET IdEmpresa = 1

--INSERT INTO TIPOINVENTARIO VALUES ('BODEGA')
--INSERT INTO TIPOINVENTARIO VALUES ('TRANSITO')

--INSERT INTO PROVEEDOR VALUES ('6C9A734A-8ECD-4148-A3B4-2374EAEBB555', 'Ingenieria de Software', 'V-11346727', 'Valencia-Venezuela','0424-4133677', 'efrainmejiasc@homail.com',1,GetDate(),GetDate(),1)
--INSERT INTO CLIENTE VALUES ('6C9A734A-8ECD-4148-A3B4-2374EAEBB555', 'Efrain Mejias C', 'V-11346727', 'Valencia-Venezuela','0424-4133677', 'efrainmejiasc@homail.com',1,GetDate(),GetDate(),1)

--Select * from USUARIO WHERE Password = 'ZWZyYWlubWVqaWFzY0Bob3RtYWlsLmNvbTEyMzQ='

--DELETE Proveedor WHERE Id = 
