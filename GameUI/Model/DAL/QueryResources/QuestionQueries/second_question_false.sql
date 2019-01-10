#2false
#false option
SELECT artist.name as 'template' , track.name as 'false_answer' 
FROM artist_credit_name JOIN artist JOIN track 
WHERE 
track.artist_credit=artist_credit_name.artist_credit AND NOT 
artist.line_num=floor(rand()*750)

LIMIT 1;