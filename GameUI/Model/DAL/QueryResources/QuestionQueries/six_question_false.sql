#6false
#Who is the artist with the most cooperations? 
SELECT artist.name FROM artist join (
SELECT artist
FROM artist_credit_name
GROUP BY artist 
order by rand()
LIMIT 3) sub
where sub.artist = artist.id;