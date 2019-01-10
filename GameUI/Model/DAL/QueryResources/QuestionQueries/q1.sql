#1
#Which of the following album by {0} ?
SELECT artist.name AS 'template' , _release_.name AS 'answer' FROM
_release_ JOIN artist JOIN artist_credit
WHERE artist.id = _release_.artist_credit 
and artist.line_num = floor(RAND() * 750)
LIMIT 1;