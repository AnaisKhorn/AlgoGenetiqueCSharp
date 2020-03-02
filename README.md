# AlgoGenetiqueCSharp
Réalisé par Anaïs KHORN et Loïc PASTOR

Ce projet a pour vocation de créer le chemin le plus rapide en sélectionnant sur une carte de la France les villes à visiter.
Pour cela, nous utilisons des algorithmes génétiques comosées de plusieurs étapes :

1. Création de la 1ere génération

Cette génération est crée aléatoirement en prenant au hasard les villes créees.
Une fois cette génération crée, nous utilisons 3 méthodes différentes pour faire notre algorithme.

2. Le cross-over 

Cette méthode prend deux chemins aléatoires, et choisit aléatoirement un pivot,
et ce dernier va être utilisé pour garder le début de la 1ere chaîne et la fin de la 2e.

Exemple : Chemin 1 : ABCDEF - Chemin 2 : AECBFD - Pivot : 2

New chemin = ABCBFD 

Ici, le new chemin passe deux fois par la ville B, notre script passera 


3. La mutation

4. L'élitisme

5. LA sélection


6. Description de l'IHM

7. Utilisation de SQLLite

Nous utilisons SQLLite pour stocker les villes dans la DB.

8. Ce qu'il reste à faire
