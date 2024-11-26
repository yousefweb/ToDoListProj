#To-Do List Application
This is a simple task management application built using ASP.NET Core. It allows users to add, delete, and mark tasks as complete. The data is persisted in a tasks.json file located in the Data directory. The application follows the Model-View-Controller (MVC) architecture to separate concerns, making it easier to maintain and extend.

Features
Add a new task
Mark a task as completed
Delete a task
Data is persisted in a JSON file (tasks.json)
Folder Structure
Controllers: Contains controllers to handle HTTP requests and manage the flow between the model and the view.
Models: Contains the data structure for the task items.
Views: Contains Razor views (UI) that are rendered by the controller.
Services: Contains the service classes responsible for handling business logic and data persistence.
Data: Contains the tasks.json file used for storing tasks.
