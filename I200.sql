SELECT  
    CASE 
        WHEN id % 2 = 0 THEN id - 1
        WHEN id % 2 = 1 AND id + 1 NOT IN (SELECT id FROM Seat) THEN id
        ELSE id + 1
    END AS id, 
    student 
FROM Seat
ORDER BY id;
