#3
#What is the nickname of {0} ?
SELECT artist.name AS 'template' , artist_alias.name AS 'answer'
FROM artist JOIN artist_alias JOIN artist_alias_type
WHERE artist_alias.type=artist_alias_type.id And artist_alias_type.id = 2
ORDER BY RAND() LIMIT 1;