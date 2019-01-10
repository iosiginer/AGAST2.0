#2fact
SELECT a1.name , a2.name ,link_phrase,reverse_link_phrase,short_link_phrase FROM
(

SELECT link_release_release.release_1,link_release_release.release_2,link_type.link_phrase,reverse_link_phrase,short_link_phrase 
FROM 
link_release_release JOIN release_facts JOIN link JOIN link_type

WHERE link_release_release.line_num =  #{parameter}

(SELECT line_num from link_release_release ORDER BY RAND() limit 1)

and (link_release_release.release_1 = release_facts.id OR link_release_release.release_2 = release_facts.id) AND

link_release_release.link = link.id AND link.link_type = link_type.id limit 1) sub


JOIN release_facts as a1 ON a1.id=release_1

JOIN release_facts as a2 ON a2.id=release_2