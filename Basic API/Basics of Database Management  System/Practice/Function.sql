DELIMITER $$

CREATE FUNCTION fn_GetAgeCategory(age INT)
RETURNS VARCHAR(20)
DETERMINISTIC
BEGIN
    DECLARE category VARCHAR(20);

    IF age < 25 THEN
        SET category = 'Young';
    ELSEIF age <= 45 THEN
        SET category = 'Middle-aged';
    ELSE
        SET category = 'Senior';
    END IF;

    RETURN category;
END $$

DELIMITER ;


SELECT 
    customerName,
    customerAge,
    fn_GetAgeCategory(customerAge) AS ageCategory
FROM
    customer;
    
drop function if exists fn_GetAgeCategory;