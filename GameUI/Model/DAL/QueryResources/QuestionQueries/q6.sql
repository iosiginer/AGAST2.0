#6
#Who is the artist with the most cooperations? 
SELECT name FROM artist WHERE id=(
SELECT artist
FROM artist_credit_name
GROUP BY artist 
ORDER BY COUNT(artist) DESC
LIMIT 1);
