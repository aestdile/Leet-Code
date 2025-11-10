# Write your MySQL query statement below
select employee_id,
if(employee_id%2=1 and name NOT REGEXP '^M', salary, 0) as bonus 
from employees 
order by employee_id;
