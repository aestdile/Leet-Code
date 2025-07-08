select s.name
from salesperson s
where s.name not in
(select sp.name
from salesperson sp
left join orders o on sp.sales_id=o.sales_id
left join company c on o.com_id = c.com_id
where c.name = 'Red');
