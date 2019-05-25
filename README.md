# ennemi-fini
L'ennemi est capable de se déplacer tout seul. Pour modifier la taille de la zone dans laquelle il se deplace il suffit de changer le paramettre area.
Dès que l'ennemi détecte le personnage il le poursuit parcontre pour changer sa vitesse, il faut changer son script. Dans son script les fonctions qui gèrent sa vitesse son Walk et Follow. Il suffit de changer la valeur qui est additionée à transform.position.x.
Dès que l'ennemi touche joueur la scène dans laquelle il se trouve se recharge.
