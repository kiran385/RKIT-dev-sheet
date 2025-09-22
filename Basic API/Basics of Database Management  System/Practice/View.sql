CREATE VIEW vws_above25 AS
    SELECT 
        *
    FROM
        customer
    WHERE
        customerAge > 25;

SELECT 
    *
FROM
    vws_above25;

DROP VIEW IF EXISTS vws_above25;