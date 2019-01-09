#1
#Which of the following album by {0} ?
SELECT artist.name AS 'template' , _release_.name AS 'answer' FROM
_release_ JOIN artist JOIN artist_credit
WHERE artist.id = _release_.artist_credit 
ORDER BY RAND() 
LIMIT 1;