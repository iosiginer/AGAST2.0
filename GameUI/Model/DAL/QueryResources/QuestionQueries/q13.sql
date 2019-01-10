#13
#Which of the songs made by a solo artist?

SELECT track.name AS 'answer'
FROM track JOIN artist_credit_name JOIN artist 
WHERE track.artist_credit = artist_credit_name.artist_credit
AND artist_credit_name.artist = artist.id
AND artist_credit_name.artist_credit=artist.id
AND artist.type = 3
ORDER BY RAND()
LIMIT 1;
