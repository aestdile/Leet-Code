select u.name as NAME, sum(t.amount) as BALANCE from Users u 
left join Transactions t 
on u.account=t.account 
group by u.account having sum(t.amount)>10000;
