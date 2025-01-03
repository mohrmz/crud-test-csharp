# CRUD Code Test 

Please read each note very carefully!
Feel free to add/change project structure to a clean architecture to your view.
and if you are not able to work on FrontEnd project, you can add a Swagger UI
in a new Front project.

Create a simple CRUD application with ASP NET that implements the below model:
```
Customer {
	Firstname
	Lastname
	DateOfBirth
	PhoneNumber
	Email
	BankAccountNumber
}
```
## Practices and patterns (Must):

- [TDD](https://docs.microsoft.com/en-us/visualstudio/test/quick-start-test-driven-development-with-test-explorer?view=vs-2022)
- [DDD](https://en.wikipedia.org/wiki/Domain-driven_design)
- [BDD](https://en.wikipedia.org/wiki/Behavior-driven_development)
- [Clean architecture](https://github.com/jasontaylordev/CleanArchitecture)
- [Clean Code](https://en.wikipedia.org/wiki/SonarQube)
- [CQRS](https://en.wikipedia.org/wiki/Command%E2%80%93query_separation#Command_query_responsibility_separation) pattern ([Event sourcing](https://en.wikipedia.org/wiki/Domain-driven_design#Event_sourcing)).
- Clean git commits that shows your work progress.

### Validations (Must)

- During Create; validate the phone number to be a valid *mobile* number only (Please use this library [Google LibPhoneNumber](https://github.com/google/libphonenumber) to validate number at the backend).

- A Valid email and a valid bank account number must be checked before submitting the form.

- Customers must be unique in database: By `Firstname`, `Lastname` and `DateOfBirth`.

- Email must be unique in the database.

### Storage (Must)

- Store the phone number in a database with minimized space storage (choose `varchar`/`string`, or `ulong` whichever store less space).

### Delivery (Must)
- Please clone this repository in a new github repository in private mode and share with ID: `mason-chase` in private mode on github.com, make sure you do not erase my commits and then create a [pull request](https://docs.github.com/en/pull-requests/collaborating-with-pull-requests/proposing-changes-to-your-work-with-pull-requests/about-pull-requests) (code review).

## Nice to do:
- Blazor Web.
- Docker-compose project that loads database service automatically which `docker-compose up`


----------------------------------------------------------------------------------------------------------
This project demonstrates a CRUD application built with ASP.NET Core, showcasing best practices in software development with principles like Clean Architecture, CQRS, TDD, DDD, and BDD. It manages customer data with a model including attributes such as Firstname, Lastname, Date of Birth, Phone Number, Email, and Bank Account Number, ensuring data integrity through comprehensive validation using the Google LibPhoneNumber library and custom logic for emails and bank accounts. The database design enforces uniqueness for customers (Firstname, Lastname, Date of Birth) and emails, while optimizing storage
The project is structured into distinct layers: Domain, Application, Infrastructure, and Presentation, promoting modularity and maintainability. The CQRS pattern separates command and query responsibilities, enhancing scalability and simplifying business logic management. Docker Compose is used for rapid setup and deployment, easing the process for developers.
To facilitate interaction, the project integrates Swagger UI, enabling intuitive API testing and debugging. The inclusion of optional Blazor Web further extends user experience, allowing for a robust and interactive frontend. Validations ensure that only clean and reliable data is entered, reducing potential bugs or inconsistencies
Adherence to Clean Code principles is evident through consistent naming conventions, modular functions, and clear documentation. The Git history is meticulously maintained with clean, incremental commits, reflecting a logical progression of work and enabling easier collaboration. 
This sample project is a testament to modern development standards, providing a maintainable, scalable, and well-documented codebase, ideal for showcasing advanced engineering practices. Its thoughtful implementation of software patterns and automated setup makes it a valuable reference for developers aiming to learn and apply clean architecture and efficient coding practices
