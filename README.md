# AlgoGenetiqueCSharp
Réalisé par Anaïs KHORN et Loïc PASTOR

Ce projet a pour vocation de créer le chemin le plus rapide en sélectionnant sur une carte de la France les villes à visiter.
Pour cela, nous utilisons des algorithmes génétiques comosées de plusieurs étapes :

1. Création de la 1ere génération

Cette génération est crée aléatoirement en prenant au hasard les villes créees.


Une fois cette génération crée, nous utilisons 3 méthodes différentes pour faire notre algorithme.

2. Algorithmes génétiques

2.1 Le cross-over 

Cette méthode prend deux chemins aléatoires, et choisit aléatoirement un pivot,
et ce dernier va être utilisé pour garder le début de la 1ere chaîne et la fin de la 2e.

Exemple : Chemin 1 : ABCDEF - Chemin 2 : AECBFD - Pivot : 2

New chemin = ABCBFD 

Ici, le new chemin passe deux fois par la ville B, notre script effacera donc cette ville en trop pour mettre la bonne ensuite,
ce qui donne :

ABCBFD => ABC?FD => (en recherchant dans le catalogue, il ne manque que le E, il va donc le remplaçer pour donner) : ABCEFD.
Et il le fait autant de fois que le nombre spécifié par l'utilisateur dans les paramètres, en prenant à chaque fois deux chemins au hasard.


2.2 La mutation

Cette méthode prend simplement un chemin et va changer l'ordre de passage en changeant de place 2 villes choisies aléatoirement.

Exemple :

ABCDEF => On echange la 2e et 5e destination => Nouveau chemin : AECDBF.
Et il le fait autant de fois que le nombre spécifié par l'utilisateur dans les paramètres, en prenant à chaque fois un chemin au hasard.

2.3 L'élitisme

Cette méthode va simplement prendre les 1/5 des meilleurs chemins.

Pour déterminer le meilleur chemin, nous faisons comme calcul :

Pour un chemin ABCDEF

Math.Sqrt(Math.Pow(x(B) - x(A), 2) + Math.Pow(y(B) - y(A), 2)); (x2-x1)² + (y1-y2)²
        
xA et xB représentent respectivement les abscisses de A et B.
yA et yB représentent respectivement les ordonnées de A et B.

Cela permet de déterminer le chemin à parcourir entre A et B.

Nous faisons ensuite la même chose entre B et C, C et D, D et E, E et F, puis nous ajoutons tous ces nombres pour obtenir la distance totale.

Les meilleurs chemins seront donc ceux qui ont le score le plus faible.


2.4 La sélection

Une fois les 3 algorithmes effectués, nous rassemblons les données dans une seule liste, puis nous sélectionnons celles avec la distance la plus faible (nombre choisi par l'utilisateur).


3. Description de l'IHM

Notre IHM présente plusieurs fonctionnalités :

- Nous avons dans l'onglet Carte la carte de la France, et quand nous cliquons dessus, cela va créer un point d'intérêt, qui sera schématisé comme une ville à parcourir, avec ses coordonnées. Cette donnée sera automatiquement enregistrée dans la DB puis affichée comme un point sur la carte avec au-dessus un nom par défaut crée en fonction du nombre de villes existantes (Ville 1, Ville 2,...). 

4. Utilisation de SQLLite

Nous utilisons SQLLite pour stocker les villes dans la DB.

5. Ce qu'il reste à faire
