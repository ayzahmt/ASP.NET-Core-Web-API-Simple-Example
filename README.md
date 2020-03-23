# ASP.NET Core Web API Simple Example
CRUD operations in Web API

### Purpose

Within the scope of the project, article api was developed using ASP.NET Core Web API. Listing, searching, adding, updating and deleting articles via this api are done with REST calls. Adding, deleting and updating comments can also be done.

### Technologies and structures used
- .Net Core Framework 
- ASP.NET Web API 
- Microsoft SQL
- Entity Framework
- Repository Pattern for database access.  
- Logging 
- Cache

### Project Content
- Database script. Database has two table (**Article** and **ArticleDetails**). Article table includes the information for the article (Columns: **Id**, **Name**, **Author**, **Subject**, **PublishDate**). ArticleDetails table includes comments for article (Columns: **Id**, **ArticleId**, **Comment**, **Commentator**, **CommentDate**).
- Two entity class names are Article and ArticleDetails. 
- Log folder. In Logger class has a method which log informations are written a file.
- Contains repository classes to database access.

### Questions

- Which design patterns are used in the project? Why did you use these patterns?

	- Repository Pattern used to access database. 

- Have you ever experienced the technology and libraries you use? Can you write one by one?

	- No experience .Net Core Framework
	- Experience Microsoft SQL
	- Experience Entity Framework
	- Experience Microsoft.Extensions.Logging library
	- Experience Newtonsoft.Json library

- What would you like to add to the project if you had more time?

	- I didn't have enough time for the authentication part. If I had time, I would.

- Do you have any comments?
	- I've never done development on the Web API using the .Net core framework before. This project was useful to me. I gained experience.


