DELIMITER $$

CREATE PROCEDURE LoopCustomers()
BEGIN
    DECLARE v_CustomerID INT;
    DECLARE done INT DEFAULT FALSE;

    DECLARE customer_cursor CURSOR FOR
        SELECT CustomerId FROM Customer;

    DECLARE CONTINUE HANDLER FOR NOT FOUND SET done = TRUE;

    OPEN customer_cursor;

    read_loop: LOOP
        FETCH customer_cursor INTO v_CustomerID;

        IF done THEN
            LEAVE read_loop;
        END IF;

        INSERT INTO log 
        VALUES ('Customer fetched', NOW());
        
    END LOOP read_loop;

    CLOSE customer_cursor;
END$$

DELIMITER ;

drop procedure if exists LoopCustomers;

CALL LoopCustomers();

select * from log;
select count(*) from log;
truncate log;