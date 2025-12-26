CREATE TABLE JSON_TYPE(
ID INT,
DATA JSON
);

SELECT * FROM JSON_TYPE;
DELETE FROM JSON_TYPE;

INSERT INTO JSON_TYPE VALUES (
    1,
    '{"name":"Alex","age":20,"skills":["SQL","C#"]}'
),
(
    2,
    '{"name":"Bob","age":19,"skills":["SQL","JS"]}'
);

SELECT JSON_EXTRACT(DATA,'$.name') FROM JSON_TYPE;		-- Extract JSON value
SELECT DATA->'$.name' FROM JSON_TYPE;					-- Extract JSON value
SELECT DATA->>'$.name' FROM JSON_TYPE;					-- Extract plain data from JSON

-- Returns 1 if found else 0
SELECT JSON_CONTAINS(DATA, '"SQL"', '$.skills') FROM JSON_TYPE;		
SELECT JSON_CONTAINS(DATA, '"Alex"', '$.name') FROM JSON_TYPE;

-- Add or update value
UPDATE JSON_TYPE
SET DATA = JSON_SET(DATA, '$.age', 21)
WHERE id = 1;

-- Insert only if key does not exist
UPDATE JSON_TYPE
SET DATA = JSON_INSERT(DATA, '$.grade', 'A');
UPDATE JSON_TYPE
SET DATA = JSON_INSERT(DATA, '$.role', 'Developer') WHERE id = 1;

-- Replace only if key exists
UPDATE JSON_TYPE
SET DATA = JSON_REPLACE(DATA, '$.new', 'PL') WHERE id = 1;

-- Delete a key 
UPDATE JSON_TYPE
SET DATA = JSON_REMOVE(DATA, '$.new');

-- Returns number of elements
SELECT JSON_LENGTH(DATA) FROM JSON_TYPE;
SELECT JSON_LENGTH(DATA->'$.skills') FROM JSON_TYPE;

-- Create object
SELECT JSON_OBJECT('name','Alex','age',16);

-- Returns key of an object
SELECT JSON_KEYS(JSON_OBJECT('name','Alex','age',16));