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