# DTOs Folder (Data Transfer Objects)

Welcome to the **Dtos** folder!

## What happens here?
DTO stands for **Data Transfer Object**. Think of DTOs as custom delivery boxes for your data. 

Sometimes our **Model** (database blueprint) has sensitive or extra information we don't want to show the user (like internal IDs, passwords, or navigation properties). Or maybe the user sends us data to create a new character, but we only want them to fill out a few specific fields. 

Instead of directly sharing the Model with the outside world, we make custom DTO classes. We map our Model into a DTO when sending data **out**, and we map a DTO into a Model when taking data **in**. This makes our application much more secure and predictable!