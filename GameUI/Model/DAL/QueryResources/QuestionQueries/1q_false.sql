#1false
#Which of the following album by {0} ?
SELECT artist.name as 'template' , _release_.name as 'false_answer' FROM
_release_ JOIN artist JOIN artist_credit

WHERE artist.id = _release_.artist_credit
and artist.line_num = floor(rand()*750) 
LIMIT 3;