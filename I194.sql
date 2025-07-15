select a.customer_id
from (
    select c.customer_id, count(distinct(c.product_key)) from customer as c
    group by c.customer_id
    having count(distinct(c.product_key)) = (select count(product_key) from product)
) as a;
