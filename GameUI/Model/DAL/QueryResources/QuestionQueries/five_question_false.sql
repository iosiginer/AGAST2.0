#5false
#Where the most artist from ?
SELECT area.name FROM area JOIN (
SELECT area
FROM artist
GROUP BY area 
ORDER BY RAND()
LIMIT 3) as sub 
where area.id = sub.area;
 