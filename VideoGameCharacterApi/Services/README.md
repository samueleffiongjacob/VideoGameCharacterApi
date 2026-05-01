# Services Folder

Welcome to the **Services** folder!

## What happens here?
If the Controller is the waiter taking your order, the **Service** is the kitchen line cook actually making the food. 

All the "business logic" lives here. We put this code in a separate folder so our Controllers don't become too big and messy. By keeping our business logic separated:
1. It is easier to read and understand.
2. It's much easier to test.
3. If we decide to use a different database tomorrow, the business rules remain the same.

Services are generally responsible for interacting with the **DataBase** folder to fetch, create, update, or delete data, and then process it before sending it back to the Controller.