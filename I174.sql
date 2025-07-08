
select id,count(*) as num
from (
select requester_id as id
from RequestAccepted

UNION ALL

select accepter_id as id
from RequestAccepted
) as friend_count
group by id
order by num desc
limit 1
