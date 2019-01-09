#5
#Where the most artist from ?
SELECT name FROM area WHERE id=(
SELECT area
FROM artist
GROUP BY area 
ORDER BY COUNT(area) DESC
LIMIT 1);