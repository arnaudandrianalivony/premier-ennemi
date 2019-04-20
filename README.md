# premier-ennemi

L'ennemi est capable de détecter le joueur. Le joueur entre dans le champ de vision de l'ennemi dès qu'il se trouve à une distance de 10 (l'unité est celle untilisée par unity, à 10 l'ennemi est déjà dans le champ de la camera). 
Lorsque l'ennemi détecte le joueur il déclenche son animation. Pour le moment la seule animation que j'ai pour l'ennemi c'est une animation où il se déplace de gauche à droite et reviens à sa position initiale (normalement il s'agit de l'animation par défaut utilisée quand le joueur n'est pas encore entrer dans le champ de vision de l'ennemi). Pour bien visualiser la détection de l'ennemi essayez de regarder le paramettre dist dans la fenêtre Inspector su script de l'ennemi pendan le jeu.
