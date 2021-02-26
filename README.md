# SuivProj-Projet-ESIMED .NET

### GESTION DES EXIGENCES ET SUIVI DE PROJET

#### EXPRESSION DES BESOINS

```
L'application demandée consiste en une application de gestion et de suivi des exigences d'un projet. Les exigences
correspondent aux demandes du client et résument de façon formelle le cahier des charges d'un projet. Les chefs de
projet ont besoin d'un outil permettant la saisie, la modification et le suivi des exigences. Ce suivi devant être réalisé
par l'intermédiaire de l'avancement des tâches liées aux exigences, elles même regroupées en jalons livrables.
Les utilisateurs chefs de projets de l'application devront pouvoir tout d'abords gérer la liste des projets. Pour chaque
projet, ils devront pouvoir enregistrer le nom du projet et leur associer un utilisateur responsable sous la forme d’un
trigramme (affichage des utilisateurs sous forme de trigramme), puis gérer la liste des exigences du projet.
Une exigence est simplement une phrase décrivant un besoin précis du client, tel que décrit dans un cahier des
charges, et chaque exigence à un identifiant unique. Une exigence peut être du type fonctionnel, ou non
fonctionnelle. Dans ce deuxième cas, les utilisateurs chefs de projets doivent pouvoir en plus spécifier si l'exigence
porte sur les données, les performances, les interfaces utilisateur, la qualité ou les services.
Le suivi du projet est centré autour des tâches à réaliser. Chaque tâche à un libellé et une description des opérations
à effectuer (texte multi lignes), un identifiant, un utilisateur attaché et est associée à une ou plusieurs exigences. A
la création d'une tâche, on doit pouvoir donner une date de début théorique d'exécution de la tâche, une charge en
nombre de jours et, au besoin, une tâche précédente qui doit être terminée avant que celle-ci puisse commencer.
Notez qu'une exigence peut être réalisée par plusieurs tâches, tout comme une tâche peut réaliser plusieurs exigences.
Pour réaliser ce suivi, les tâches peuvent être modifiées pour indiquer si elles sont commencées ou non (on considère
qu’une tâche est commencée si elle une date de démarrage réelle) et bien entendu si elles sont terminées.
Enfin, les tâches sont regroupées dans des jalons qui représentent des livraisons aux client. Un ensemble de tâche
terminées donne une version livrable du produit, à une date donnée. Un jalon correspond donc à un ensemble
d'exigences complètement réalisées. Un jalon d'un projet possède donc un libellé, une date de livraison prévue, un
responsable, une liste de tâche qui doivent être terminées et une date de livraison réelle, une fois celle-ci effectuée.
Ainsi, les utilisateurs chefs de projets peuvent suivre l'avancement des projets de plusieurs manières : par projet, en
fonction des jalons terminées ou jalon par jalon, en fonction des tâches terminées dans le jalon en cours de
développement. Ils peuvent aussi consulter la date théorique calculée de fin d'un jalon ou de fin d'un projet, et les
comparer aux dates prévues, et enfin ils peuvent avoir une idée de l'avancement global à l'aide du taux de couverture
des exigences.
```
#### CONTRAINTES FONCTIONNELLES

- Les utilisateurs seront prés créés.
- L'avancement d'un jalon, en pourcentage de sa totalité, se calcule comme suit : une tâche non démarrée est
considérée comme étant à 0%, une tâche démarrée est étant à 50% et enfin une tâche peut être terminée à 100%.
- L'avancement d'un projet, en pourcentage de sa totalité, se calcule à l'aide du nombre de jalon terminés, plus
l'avancement du jalon en cours.
- La date de fin théorique d'un jalon se calcule en fonction de la tâche qui doit se terminer en dernier, en prenant en
compte la charge de la tâche et sa date de démarrage réelle ou de sa date de démarrage prévue si elle n'est pas
commencée.
- La date de fin théorique d'un projet se calcule en fonction de la date de fin théorique du dernier jalon à laquelle on
a ajouté ou soustrait le décalage de temps de chaque jalon terminé.

#### FONCTIONNALITES ET CONTRAINTES SUPPLEMENTAIRES

```
Les utilisateurs chefs de projets peuvent avoir une idée de l'avancement global à l'aide du taux de couverture des
exigences. Le taux de couverture des exigences d'un projet, en pourcentage de la totalité du projet, se calcule à l'aide
du nombre d'exigences complètement réalisées (pour qu'une exigence soit complètement réalisée il faut que toutes
ses tâches liées soient terminées).
```
- Une fois une exigence liée à une tâche, elle ne peut être liée qu'à d'autres tâches du même jalon.
- Une authentification sera nécessaire.
- Les utilisateurs chefs de projets peuvent gérer toutes les données, les utilisateurs responsables uniquement les
projets qui leur sont assignés.

#### CONTRAINTES NON FONCTIONNELLES

- Tout ou partie de l'application devra être développée à l'aide de la technologie suivantes : Framework Microsoft
    .Net.
- Un design clair et fonctionnel devra être appliqué pour l'ensemble de l'application.
- L’architecture de l’application est libre et doit respecter les consignes de bonnes pratiques données en cours.
- L’utilisation de librairies et frameworks tiers est autorisée.


