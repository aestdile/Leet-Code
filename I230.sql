select user_id,
    concat(UPPER(substring(name,1,1)),
            LOWER(substring(name,2))) as name
from Users
order by user_id
