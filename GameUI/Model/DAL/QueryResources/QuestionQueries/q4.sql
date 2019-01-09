#4
#The release {0} made by artist from 
SELECT area.name AS 'answer' , _release_.name AS 'template' 
FROM _release_ JOIN artist_credit_name JOIN artist JOIN area
WHERE _release_.artist_credit=artist_credit_name.artist_credit AND artist.id = artist_credit_name.artist
AND artist.area=area.id 
ORDER BY RAND() limit 1; 