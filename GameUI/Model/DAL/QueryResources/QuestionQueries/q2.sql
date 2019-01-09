#2
#Which of the following not song by {0} ?
SELECT artist.name as 'template' , track.name AS 'answer' FROM 
artist_credit_name JOIN artist JOIN track 
WHERE 
track.artist_credit=artist_credit_name.artist_credit AND 
artist.id=
(SELECT id from artist ORDER BY RAND() LIMIT 1)
ORDER BY RAND() 

LIMIT 3;