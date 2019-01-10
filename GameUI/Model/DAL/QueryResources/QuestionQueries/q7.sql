#7
#Where are {0} came from  ?

SELECT artist.name AS 'template' , area.name AS 'answer'
FROM artist JOIN area
WHERE artist.line_num = floor(Rand() * (SELECT count(*) from artist)) 
and artist.type = 2 
and artist.area=area.id
order by rand()
limit 1;
