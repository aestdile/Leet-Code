SELECT p.product_name, s.year, s.price  
FROM Sales s  
JOIN Product p  
using(product_id) 
order by p.product_name
