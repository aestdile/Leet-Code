SELECT v.customer_id,count(v.visit_id) AS count_no_trans
FROM Visits v 
LEFT JOIN Transactions t 
using(visit_id) 
WHERE t.transaction_id is NULL
GROUP BY v.customer_id
order by v.customer_id;
