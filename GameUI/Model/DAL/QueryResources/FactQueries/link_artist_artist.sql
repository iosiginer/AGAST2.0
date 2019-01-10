#1fact
SELECT a1.name AS name1 , a2.name AS name2 ,link_phrase,reverse_link_phrase,short_link_phrase FROM

(

SELECT link_artist_artist.artist_1,link_artist_artist.artist_2,link_type.link_phrase,reverse_link_phrase,short_link_phrase 
FROM 
link_artist_artist JOIN artist_facts JOIN link JOIN link_type

WHERE link_artist_artist.line_num =  #{parameter}

(SELECT line_num from link_artist_artist ORDER BY RAND() limit 1)

and (link_artist_artist.artist_1 = artist_facts.id OR link_artist_artist.artist_2 = artist_facts.id) AND

link_artist_artist.link = link.id AND link.link_type = link_type.id limit 1) sub


JOIN artist_facts as a1 ON a1.id=artist_1

JOIN artist_facts as a2 ON a2.id=artist_2