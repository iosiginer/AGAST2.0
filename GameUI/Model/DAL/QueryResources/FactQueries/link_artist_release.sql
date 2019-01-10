#3fact
SELECT link_artist_release.artist,link_artist_release.release,link_type.link_phrase ,reverse_link_phrase,short_link_phrase
FROM 
link_artist_release JOIN artist_facts JOIN link JOIN link_type JOIN release_facts

WHERE link_artist_release.line_num = #50 #{parameter}

(SELECT link_artist_release.line_num from link_artist_release 
ORDER BY RAND() limit 1)

and (link_artist_release.artist = artist_facts.id OR link_artist_release.release = release_facts.id) AND

link_artist_release.link = link.id AND link.link_type = link_type.id limit 1