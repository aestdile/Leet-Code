SELECT U.name AS name, COALESCE(SUM(R.distance), 0) AS travelled_distance
FROM Users U
LEFT JOIN Rides R ON U.id = R.user_id
GROUP BY U.id, U.name
ORDER BY travelled_distance DESC, U.name ASC;
