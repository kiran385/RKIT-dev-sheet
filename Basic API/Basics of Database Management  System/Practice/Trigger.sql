CREATE TABLE log (
    message VARCHAR(50),
    dt DATETIME
);

DELIMITER $$

CREATE TRIGGER trg_customer
AFTER INSERT ON Customer
FOR EACH ROW
BEGIN
    INSERT INTO log
    VALUES ('New customer added', NOW());
END$$

DELIMITER ;

drop trigger if exists trg_customer;

SELECT 
    *
FROM
    log;
    
insert into Customer values(202,'K2','k2@gmail.com',20);
