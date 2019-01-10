#6false
#Who is the artist with the most cooperations? 
SELECT name FROM artist WHERE id=(
SELECT artist
FROM artist_credit_name
GROUP BY artist 
LIMIT 3);
