# Controllers Folder

Welcome to the **Controllers** folder! 

## What happens here?
Think of Controllers as the "Front Desk" or "Waiters" of our API. When a user (or a web app frontend) wants something from our API, they send an HTTP request (like a `GET` request to see characters or a `POST` request to create one). 

The Controller receives this request, figures out what the user wants, and then asks the **Services** to do the actual heavy lifting. Once the Service finishes its job, the Controller takes the result and gives it back to the user as an HTTP response (like a `200 OK` with the data). By keeping it this way, Controllers stay very thin and only route traffic.