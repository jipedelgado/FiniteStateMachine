/*
 * 4 février 2017

 Scene main : Principe = 
 des préfabs "Drunkards" sont créées dans un volume limité, à des positions aléatoires.Ils se déplacent aléatoirement dans toutes les directions avec un pas réglable.Ils sont taggés "Prey".

Puis un préfab "Collector" est créé, dans les mêmes conditions.
Il est controlé par Joystick.
Il dispose d'un objet "Bee" qui détecte les "Prey" les plus lointaines, les capture, et les ramène à son "Collector". 

Bee posséde un "panier", une pile qui contient la proie capturée pendant le trajet vers "Home". Home atteint, "panier" est dépilé, l'objet capturé est transmis au "panier" de "Home".

En même temps, de nouveaux "Drunkard" sont créés selon une fréquence réglable.


REMARQUES:
   La détection des objets se fait selon leur "tag", qui est fixé au cours deu jeu par "GameController.cs".

TODO = 
créer un scénario de jeu 

TODO: fixer les bugs suivants
bug #1 =
  Quand "Bee" a attrapé toutes les proies, sa position est celle du collector, et la création de nouvelles proies n'y change rien
suggestion = arrèter le jeu dans ce cas, ou redémarrer la détection des proies par bee

bug #2 =
 Deux collectors entrainent un phénomène étrange = le bee de l'un vient se réfugier sur le Home de l'autre ???

*/