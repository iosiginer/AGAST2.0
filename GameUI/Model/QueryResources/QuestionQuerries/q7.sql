#7
#Where are {0} came from  ?
SELECT area.name AS 'answer' , artist.name AS 'template' 
FROM artist JOIN area 
WHERE 
artist.type = 2 AND artist.area=area.id AND area.id=

(SELECT area.id FROM area ORDER BY RAND() LIMIT 1)

ORDER BY RAND()

LIMIT 1;
