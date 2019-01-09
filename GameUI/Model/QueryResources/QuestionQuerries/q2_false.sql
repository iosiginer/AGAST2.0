#2false
#false option
SELECT artist.name as 'template' , track.name as 'false_answer' 
FROM artist_credit_name JOIN artist JOIN track 
WHERE 
track.artist_credit=artist_credit_name.artist_credit AND NOT 
artist.id=
(SELECT id from artist ORDER BY RAND() LIMIT 1)

LIMIT 1;