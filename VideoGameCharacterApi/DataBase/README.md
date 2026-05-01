# DataBase Folder

Welcome to the **DataBase** folder!

## What happens here?
This folder acts as a bridge between our C# application and the actual SQL Server database. 

It holds `AppDbContext`, which is part of Entity Framework Core. You can think of this class as a "Database Translator". When our **Services** say "give me all characters" in C#, `AppDbContext` translates that request into SQL commands, talks over the network to the database, and converts the resulting rows back into C# objects that our code can understand.