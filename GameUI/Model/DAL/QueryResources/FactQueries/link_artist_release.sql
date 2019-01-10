#3fact

SELECT artist_facts.name as 'template_1' , release_facts.name as 'template_2' 
,link_phrase 
reverse_link_phrase,short_link_phrase 
FROM artist_facts , release_facts ,  (
SELECT link_artist_release.artist AS 'template_1' 
,link_artist_release.release AS 'template_2'
,link_type.link_phrase 
,link_type.reverse_link_phrase,link_type.short_link_phrase 

FROM 
link_artist_release JOIN artist_facts JOIN link JOIN link_type JOIN release_facts

WHERE link_artist_release.line_num = floor(rand()*(SELECT count(link_artist_release.line_num) from link_artist_release)) #50 #{parameter}

and (link_artist_release.artist = artist_facts.id OR link_artist_release.release = release_facts.id) AND

link_artist_release.link = link.id AND link.link_type = link_type.id limit 1
) as bb
where artist_facts.id=bb.template_1 and release_facts.id = bb.template_2