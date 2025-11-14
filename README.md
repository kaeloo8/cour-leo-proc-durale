procédurale – informations (Léo Chevalier)

Semaine théorique – génération procédurale



# /// Sommaire ///


- Simple Room Placement

- Binary Space Partition (BSP)

- Cellular Automata

- Gradient Noise

Toutes ces techniques procédurales ont leurs avantages et leurs inconvénients et doivent être choisies en fonction du résultat que l’on souhaite obtenir.




# /// Simple Room Placement ///

Le Simple Room Placement consiste à créer une pièce puis à vérifier si l’emplacement choisi est libre (pas de chevauchement ou de superposition).
<p align="center">
  <img src="" width="350" title="hover text">
</p>
Si l’emplacement est valide la pièce est placée et on passe à la suivante sinon on génère une nouvelle position et on réessaie.
<p align="center">
  <img src="" width="350" title="hover text">
</p>
Apres une limite de tentative échoué on arrête pour éviter de crée une boucle infinie quand la zone devient trop pleine.
Une fois les piece genere on conacte les piece avec des couloir en reliant les salle les plus proche.
<p align="center">
  <img src="" width="350" title="hover text">
</p>

C’est une méthode utile pour générer des zones aléatoires dispersées sans forcément les placer proche les unes des autres.




# /// Binary Space Partition (BSP) ///

Le BSP commence avec une zone (root) de départ qu'il divise en deux parties (sister) et la zone de base garde ses deux zone comme zone enfant.
<p align="center">
  <img src="" width="350" title="hover text">
</p>
Chaque zone est ensuite découpée de la même manière pour atteindre une taille minimale ou un nombre maximal de coup ou de zone (leaf).
On peut créer des sous-zones plus petites que la zone finale pour ajouter des marges entre les différentes zones.
<p align="center">
  <img src="" width="350" title="hover text">
</p>
On peut ensuite conecter tout les leaf qui sont les derienr zone en prenant leur parent se qui conecte deux piece qui son a cote.
<p align="center">
  <img src="" width="350" title="hover text">
</p>
Ensuit on peut conecter les groupe de salle enssemble en les conectant par leur parent.
<p align="center">
  <img src="" width="350" title="hover text">
</p>

Cette méthode est très utile pour créer des donjons et des bâtiments ou des zones organisées.


# /// Cellular Automata ///

Le Cellular Automata est utilisé après une première génération aléatoire souvent un bruit blanc.
<p align="center">
  <img src="" width="350" title="hover text">
</p>
Le principe est de prendre chaque cellule et de vérifier c'elles qui l'entour pour décider si elle doit rester disparaître ou se transformer.
<p align="center">
  <img src="" width="350" title="hover text">
</p>
Le fonctionnement est proche du jeu de la vie avec des condition de quantiter de type avoisiant on modifie dyferament la cellule que l'on regarde.
<p align="center">
  <img src="" width="350" title="hover text">
</p>
On peut améliorer la méthode en augmentant la zone de vérification ou en ajoutant des règles différentes selon la distance des cellules voisines.

C’est une méthode efficace pour obtenir des formes naturelles lissées comme des grottes ou des cavernes.




# /// Gradient Noise ///

Le Gradient Noise génère un bruit basé sur plusieurs paramètres (fréquence amplitude speed…) produisant une image en niveaux de gris allant du noir au blanc.
<p align="center">
  <img src="" width="350" title="hover text">
</p>
Chaque valeur peut ensuite être lue pour créer un terrain une carte ou n’importe quelle zone procédurale.
<p align="center">
  <img src="" width="350" title="hover text">
</p>
On peut apliquer dyferente modification sur diferente partie du noise par raport a des coordoner pour faire varier de maniere plus precise certaine partie.
<p align="center">
  <img src="" width="350" title="hover text">
</p>

Selon les réglages on peut obtenir différents types de variations : montagnes plaines îles etc.
C’est une méthode très efficace peu coûteuse en ressources si elle est bien gérée et très utilisée.
