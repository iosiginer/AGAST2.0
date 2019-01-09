#9
#What release is made by woman?
SELECT _release_.name as 'answer'
FROM artist JOIN _release_ JOIN artist_credit_name

WHERE artist.gender=2

AND artist.id=artist_credit_name.artist and artist_credit_name.artist_credit=_release_.artist_credit

ORDER BY RAND()

limit 3;
