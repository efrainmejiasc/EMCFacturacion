
SELECT * FROM USUARIO
SELECT * FROM EMPRESA
SELECT * FROM PROVEEDOR
SELECT * FROM CLIENTE

SELECT * FROM PRODUCTO

SELECT * FROM FacturaCompra ORDER BY FECHA DESC
SELECT * FROM FacturaCompraDetalle ORDER BY ID DESC

SELECT * FROM FacturaVenta ORDER BY FECHA DESC
SELECT * FROM FacturaVentaDetalle ORDER BY ID DESC

SELECT * FROM StockTotal
SELECT * FROM StockTransito

SELECT * FROM TipoFactura

SELECT * FROM Producto
SELECT * FROM ProductoImgInfo
SELECT * FROM ProductoImg

DELETE ProductoImgInfo WHERE Id <= 10
DELETE  ProductoImg WHERE ProductoImgInfoId <> 1004

TRUNCATE TABLE ProductoImgInfo
TRUNCATE TABLE ProductoImg

--Update ProductoImgInfo SET Precio = 345.52
  --Update ProductoImgInfo SET Categoria = 'In' WHERE ID = 4

SELECT * FROM ROLES
SELECT * FROM MetodoPago
SELECT * FROM UnidadMedida
SELECT * FROM UnidadMedida WHERE Sistema = 'EN-US'
SELECT * FROM UnidadMedida WHERE Sistema = 'ES-ES'
SELECT * FROM TipoFactura
SELECT * FROM InicioFacturacion
SELECT * FROM TrazabilidadEnvio

--UPDATE TRAZABILIDADENVIO SET Dni = '11346727'

--UPDATE UnidadMedida SET Sistema = 'ES-ES' WHERE Id = 10

--TRUNCATE TABLE FacturaVenta
--TRUNCATE TABLE FacturaVentaDetalle
--TRUNCATE TABLE FacturaCompra
--TRUNCATE TABLE FacturaCompraDetalle
--TRUNCATE TABLE StockTotal
--TRUNCATE TABLE StockTransito
--TRUNCATE TABLE StockBodega
--TRUNCATE TABLE Proveedor
--TRUNCATE TABLE ProductoImgInfo


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

--INSERT INTO MetodoPago VALUES('Efectivo', 'ES-ES')
--INSERT INTO MetodoPago VALUES('Credito', 'ES-ES')
--INSERT INTO MetodoPago VALUES('Tarjeta de Credito', 'ES-ES')
--INSERT INTO MetodoPago VALUES('Tarjeta de Debito', 'ES-ES')
--INSERT INTO MetodoPago VALUES('Transferencia Bancaria', 'ES-ES')

--INSERT INTO UNIDADMEDIDA (UNIDAD, IdEmpresa, Sistema) VALUES ('Unit',1,'EN-US')
--INSERT INTO UNIDADMEDIDA (UNIDAD, IdEmpresa, Sistema) VALUES ('Gallon',1,'EN-US')
--INSERT INTO UNIDADMEDIDA (UNIDAD, IdEmpresa, Sistema) VALUES ('Foot',1,'EN-US')
--INSERT INTO UNIDADMEDIDA (UNIDAD, IdEmpresa, Sistema) VALUES ('Pound',1,'EN-US')
--INSERT INTO UNIDADMEDIDA (UNIDAD, IdEmpresa, Sistema) VALUES ('Part',1,'EN-US')

--INSERT INTO UNIDADMEDIDA (UNIDAD, IdEmpresa, Sistema) VALUES ('Unidad',2,'ES-ES')
--INSERT INTO UNIDADMEDIDA (UNIDAD, IdEmpresa, Sistema) VALUES ('Litro',2,'ES-ES')
--INSERT INTO UNIDADMEDIDA (UNIDAD, IdEmpresa, Sistema) VALUES ('Kilo',2,'ES-ES')
--INSERT INTO UNIDADMEDIDA (UNIDAD, IdEmpresa, Sistema) VALUES ('Metro',2,'ES-ES')
--INSERT INTO UNIDADMEDIDA (UNIDAD, IdEmpresa, Sistema) VALUES ('Pieza',1,'ES-ES')

--update StockTransito Set NombreArticulo = ' Monitor - Unit' Where id = 1 


 -- INSERT INTO EMPRESA VALUES ('4F0EF2D3-A470-4B2D-B2EF-A9B8A8EE1777','Reparaciones CP','V-00000000','efrainmejiasc@hotmail.com','0414401526','Valencia-Venezuela',GetDate(),GetDate(),1)
  --INSERT INTO EMPRESA VALUES ('5F0EF2D3-A470-5B2D-B2EF-A9B8A8EE1775','Servicios','V-00000000','efrainmejiasc@hotmail.com','0414401526','Valencia-Venezuela',GetDate(),GetDate(),1)

 --INSERT INTO USUARIO VALUES ('admin@hotmail.com',1,'admin','admin','admin','YWRtaW5AaG90bWFpbC5jb20xMjM0','YWRtaW4xMjM0',GetDate(),1,1)
 --INSERT INTO USUARIO VALUES ('admin2@hotmail.com',2,'admin','admin','admin','YWRtaW5AaG90bWFpbC5jb20xMjM0','YWRtaW4xMjM0',GetDate(),1,1)
 --INSERT INTO USUARIO VALUES ('efrainmejiasc@hotmail.com',2,'Efrain','Mejias','efrain','ZWZyYWlubWVqaWFzY0Bob3RtYWlsLmNvbTEyMzQ=','ZWZyYWluMTIzNA==',GetDate(),1,4)

--UPDATE USUARIO SET Password = 'YWRtaW5AaG90bWFpbC5jb20xMjM0'
--UPDATE USUARIO SET Activo = 1
--UPDATE Proveedor SET IdEmpresa = 2
--UPDATE Cliente SET IdEmpresa = 1
--UPDATE UnidadMedida SET IdEmpresa = 1
--UPDATE EMPRESA SET Activo = 1


--INSERT INTO TIPOINVENTARIO VALUES ('BODEGA')
--INSERT INTO TIPOINVENTARIO VALUES ('TRANSITO')

--INSERT INTO PROVEEDOR VALUES ('6C9A734A-8ECD-4148-A3B4-2374EAEBB555', 'Ingenieria de Software', 'V-11346727', 'Valencia-Venezuela','0424-4133677', 'efrainmejiasc@homail.com',1,GetDate(),GetDate(),1)
--INSERT INTO CLIENTE VALUES ('6C9A734A-8ECD-4148-A3B4-2374EAEBB555', 'Efrain Mejias C', 'V-11346727', 'Valencia-Venezuela','0424-4133677', 'efrainmejiasc@homail.com',1,GetDate(),GetDate(),1)

--Select * from USUARIO WHERE Password = 'ZWZyYWlubWVqaWFzY0Bob3RtYWlsLmNvbTEyMzQ='

--DELETE Proveedor WHERE Id = 

  --DELETE FacturaCompraDetalle WHERE Id = 2

--UPDATE FacturaCompra SET Fecha = GetDate() , FechaModificacion = GetDate()
--UPDATE FacturaCompraDetalle SET Fecha = GetDate() , FechaModificacion = GetDate()

--UPDATE  FacturaVenta SET Fecha = GetDate() , FechaModificacion = GetDate()
--UPDATE  FacturaVentaDetalle SET Fecha = GetDate() , FechaModificacion = GetDate()


  SELECT C.NombreProducto, B.Cantidad, A.Total, A.Fecha FROM FacturaCompra A INNER  JOIN FacturaCompraDetalle B  ON A.NumeroFactura = B.NumeroFactura
                                                                             INNER JOIN Producto C ON B.NombreArticulo LIKE '%' + C.NombreProducto + '%'

  SELECT C.NombreProducto, B.Cantidad, A.Total, A.Fecha FROM FacturaVenta A INNER  JOIN FacturaVentaDetalle B  ON A.NumeroFactura = B.NumeroFactura
                                                                             INNER JOIN Producto C ON B.NombreArticulo LIKE '%' + C.NombreProducto + '%'

  

--UPDATE PRODUCTO SET NombreProducto = 'Galletas' Where Id = 6
SELECT * FROM PRODUCTO