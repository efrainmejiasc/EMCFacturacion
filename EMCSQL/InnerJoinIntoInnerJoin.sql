SELECT
  c.cuenta_id,
  ec.estructuracuenta_id,
  ec.cuenta,
  ec.descripcion,
  sc.debito_total,
  sc.credito_total
FROM cuenta c
INNER JOIN estructuracuenta ec on ec.estructuracuenta_id = c.estructuracuenta_id
INNER JOIN
(
  SELECT cuenta_id, SUM(debito) AS debito_total, SUM(credito) AS credito_total
  FROM saldocuenta
  WHERE periodo_id BETWEEN 1 AND 5
  GROUP BY cuenta_id
) sc ON sc.cuenta_id = s.cuenta_id 
ORDER BY c.cuenta_id;