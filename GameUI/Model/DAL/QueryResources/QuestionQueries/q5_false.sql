#5false
#Where the most artist from ?
SELECT name FROM area WHERE id=(
SELECT area
FROM artist
GROUP BY area 
LIMIT 3);
