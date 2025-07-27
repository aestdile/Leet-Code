(select name as results 
from MovieRating join Users
using (user_id)
group by name
order by count(*) desc , name
limit 1)

union all

(select title as results
from MovieRating join Movies
using (movie_id) 
where date_format(created_at , '%Y-%m') = '2020-02'
group by title
order by avg(rating) desc , title
limit 1);
