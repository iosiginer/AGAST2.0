#7falase
SELECT artist.name as 'template' , area.name 'false_answer' 
FROM artist JOIN area 
WHERE NOT 
artist.type = 2 AND artist.area=area.id AND area.id=

(SELECT area.id FROM area ORDER BY RAND() LIMIT 1)

ORDER BY RAND()

LIMIT 1;
