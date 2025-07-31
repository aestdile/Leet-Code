select round(100.0 * sum(order_date = customer_pref_delivery_date) / count(*), 2) as immediate_percentage
from delivery
where (customer_id, order_date) in (
    select customer_id, min(order_date)
    from delivery
    group by customer_id
);
