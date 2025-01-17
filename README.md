# Gestion d'Événements et de Participants

## Description

Une application web en **ASP.NET Core MVC** utilisant **Entity Framework Core**, permettant de gérer des événements et des participants, ainsi que leurs relations.

---

## Fonctionnalités

- **Événements** : Création, édition, suppression, et consultation.
- **Participants** : Création, édition, suppression, et consultation.
- **Relations** : Association des participants à des événements.
- **Interface utilisateur** : Design responsive basé sur **Bootstrap**.

---

## Installation

1. Clonez ce dépôt :
   ```bash
   git clone https://github.com/NathanManiezPro/ECFJanvier.git
   ```

2.  Restaurez les dépendances :
	```bash
	dotnet restore
	```

3.	Appliquez les migrations
	``` bash
	dotnet ef database update
	```
5. Lancez l'application :

	```bash
	dotnet run
	```

	# UML
	Voici le diagramme UML du projet :
   ```
   @startuml
    class Participant {
    - int Id
    - string Nom
    - string Prenom
    - string Email
    --
    + List<EvenementParticipant> Evenements
    }

    class Evenement {
    - int Id
    - string Titre
    - DateTime Date
    - string Lieu
    --
    + List<EvenementParticipant> Participants
    }

    class EvenementParticipant {
    - int ParticipantId
    - int EvenementId
    --
    + Participant Participant
    + Evenement Evenement
    }

    Participant "1" -- "0..*" EvenementParticipant
    Evenement "1" -- "0..*" EvenementParticipant


    @enduml
    ```

    ## Design UI
Le design de l'interface utilisateur est disponible sur Figma. Téléchargez ou consultez le lien Figma ci-dessous :
https://www.figma.com/design/TLaDdmTWfiM5hH2muDP4eG/Untitled?node-id=0-1&t=zoIpG1fCd8MLZcHn-1


## Auteur
### Maniez Nathan
