# Model Folder

Welcome to the **Model** folder!

## What happens here?
This is where we define the core "Blueprints" (or Entities) of our application. 

If our application is about Video Game Characters, we will have a `Character.cs` class here. This class tells Entity Framework Core exactly what a Character looks like (e.g., it has an Id, a Name, a Game, and a Role). Entity Framework reads these classes so it knows how to build the actual tables in our SQL database. 

Everything in this folder typically has a direct 1-to-1 relationship with how data is stored on disk in the database.