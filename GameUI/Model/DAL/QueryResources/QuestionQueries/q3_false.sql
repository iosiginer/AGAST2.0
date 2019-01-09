#3false
#false ?
SELECT artist.name AS 'template' , artist_alias.name AS 'false_answer'

FROM artist JOIN artist_alias JOIN artist_alias_type

WHERE NOT artist_alias.type=artist_alias_type.id And NOT artist_alias_type.id = 2

ORDER BY RAND() LIMIT 3;