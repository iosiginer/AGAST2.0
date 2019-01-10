#9false
#What release is made by woman?

SELECT _release_.name as 'false_answer'
FROM artist JOIN _release_ JOIN artist_credit_name

WHERE NOT artist.gender=2

AND artist.id=artist_credit_name.artist and artist_credit_name.artist_credit=_release_.artist_credit

ORDER BY RAND()

limit 3;
