with cte as(
    select *, dense_rank() over(partition by  actor_id,director_id 
      order by  timestamp ) rnk 
from ActorDirector )

    select actor_id ,director_id 
    from cte
    where rnk=3
