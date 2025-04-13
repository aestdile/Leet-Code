SELECT ip, COUNT(*) AS invalid_count
FROM logs
WHERE 
    ip REGEXP '(^|\\.)([2][5][6-9]|[2][6-9][0-9]|[3-9][0-9][0-9]|[1-9][0-9][0-9][0-9]+)(\\.|$)'
    OR ip REGEXP '(^|\\.)0[0-9]+'
    OR (LENGTH(ip) - LENGTH(REPLACE(ip, '.', ''))) != 3
GROUP BY ip
ORDER BY invalid_count DESC, ip DESC;
