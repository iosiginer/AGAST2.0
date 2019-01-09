#4false
#false
SELECT area.name AS 'false_answer' , _release_.name AS 'template' 
FROM _release_ JOIN artist_credit_name JOIN artist JOIN area

WHERE _release_.artist_credit=artist_credit_name.artist_credit AND NOT artist.id = artist_credit_name.artist

AND artist.area=area.id 
ORDER BY RAND() limit 1;