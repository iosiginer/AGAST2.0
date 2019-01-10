#8
#Which of the following song create by the artists who retired sooner?
SELECT sub.* FROM 


(SELECT track.name 'answer'  


FROM artist JOIN artist_credit_name JOIN track


WHERE not artist.end_year=0 and track.artist_credit = artist_credit_name.artist_credit 

and artist_credit_name.artist = artist.id
ORDER BY RAND()
limit 4
) sub
ORDER BY sub.end_year + 0 desc;
