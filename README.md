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
Si l’emplacement est valide la pièce est placée et on passe à la suivante. Sinon on génère une nouvelle position et on réessaie.
Apres une limite de tentative échoué on arrête pour éviter de crée boucle infinie quand la zone devient trop pleine.

C’est une méthode utile pour générer des zones aléatoires dispersées sans forcément les placer proche les unes des autres.


![Sans titre (1)](https://github.com/user-attachments/assets/5f7edf57-f07b-46bd-8215-9c198c9228c8)
![Sans titre (2)](https://github.com/user-attachments/assets/9aa49864-3b1a-4dbc-b73f-dbc146f73a8c)
![Sans titre (3)](https://github.com/user-attachments/assets/0f09c92a-48f2-4440-a107-7e8dcab333bc)
![Sans titre (4)](https://github.com/user-attachments/assets/24c26ca4-5035-4d5b-a746-dd7b050aee8e)
![Sans titre (5)](https://github.com/user-attachments/assets/876a6e14-0562-486f-9d79-9a4fa038790a)
![Sans titre (5)](https://github.com/user-attachments/assets/e31952a7-6494-45ec-8f90-50188cdd7104)
![Sans titre (6)](https://github.com/user-attachments/assets/18217686-9417-414b-b71a-abdd691b8f39)




# /// Binary Space Partition (BSP) ///

Le BSP commence avec une zone de départ qu'il divise en deux parties selon les paramètres entrée (taille écart de coup…).
Chaque zone est ensuite découpée de la même manière pour atteindre une taille minimale ou un nombre maximal de coup.

On peut créer des sous-zones plus petites que la zone finale pour ajouter des marges et générer des connexions entre les différentes zones.

Cette méthode est très utile pour créer des donjons et des bâtiments ou des zones organisées.




# /// Cellular Automata ///

Le Cellular Automata est utilisé après une première génération aléatoire souvent un bruit blanc.
Le principe est de prendre chaque cellule et de vérifier c'elles qui l'entour pour décider si elle doit rester disparaître ou se transformer.
Le fonctionnement est proche du jeu de la vie.
On peut améliorer la méthode en augmentant la zone de vérification ou en ajoutant des règles différentes selon la distance des cellules voisines.

C’est une méthode efficace pour obtenir des formes naturelles lissées comme des grottes ou des cavernes.




# /// Gradient Noise ///

Le Gradient Noise génère un bruit basé sur plusieurs paramètres (fréquence amplitude speed…) produisant une image en niveaux de gris allant du noir au blanc.
Chaque valeur peut ensuite être lue pour créer un terrain une carte ou n’importe quelle zone procédurale.

Selon les réglages on peut obtenir différents types de variations : montagnes plaines îles etc.
C’est une méthode très efficace peu coûteuse en ressources si elle est bien gérée et très utilisée.
