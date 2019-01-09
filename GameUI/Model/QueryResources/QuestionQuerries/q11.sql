#11
#Which of the following artist create {0}?
SELECT _release_.name AS 'template' , artist_alias.name AS 'answer'
FROM _release_ JOIN artist_credit_name join artist join artist_alias
WHERE _release_.artist_credit = artist_credit_name.artist_credit
AND artist_credit_name.artist=artist.id AND artist_alias.artist=artist.id
ORDER BY RAND() 
LIMIT 1;