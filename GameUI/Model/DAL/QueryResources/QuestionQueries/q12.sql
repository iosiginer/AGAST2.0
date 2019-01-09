#12
#Which of the songs made by a band?
SELECT track.name AS 'answer'
FROM track JOIN artist_credit_name JOIN artist
WHERE track.artist_credit=artist_credit_name.artist_credit 
AND artist_credit_name.artist=artist.id
#type 2 is a band
AND artist.type=2
ORDER BY RAND()
limit 1;