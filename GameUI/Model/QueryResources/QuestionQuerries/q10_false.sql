#10false
#which is a track by {0}
SELECT artist_credit_name.name AS 'template' , track.name AS 'false_answer'
FROM artist_credit_name JOIN track 
WHERE track.artist_credit=artist_credit_name.artist_credit
ORDER BY RAND()
limit 3;
