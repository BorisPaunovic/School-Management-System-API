# School Management System API

Welcome to the School Management System API repository! This repository contains the source code and files for the RESTful API component of a school management system. The API is built using ASP.NET Core MVC and provides endpoints to manage various aspects of the school system, including students, teachers, courses, and more.

## Features

The School Management System API offers the following features:

- **Students:** Endpoints to manage student information, including creating, retrieving, updating, and deleting student records.
- **Teachers:** API endpoints for managing teacher details, such as creating, retrieving, updating, and deleting teacher profiles.
- **Courses:** Endpoints to handle course management operations, including creating, retrieving, updating, and deleting courses.
- **Coubtries:*Endpoints for managing coutries information : updating ,deleting, retrieving and deleting.
- - **Subjects:*Endpoints for managing Subject information : updating ,deleting, retrieving and deleting.
  - And the linking tables : CoursesSubjects,StudentsCourses,TeacherCourses
Additional features include:

- **Authentication and Authorization:**(In progress) Secure endpoints using authentication and authorization mechanisms to control access to sensitive data and operations.
- **Validation and Error Handling:** Built-in validation and error handling mechanisms to ensure data integrity and provide meaningful error responses.
- **Swagger Documentation:** Integration with Swagger UI for interactive API documentation, allowing easy exploration of available endpoints and testing of requests.

## Installation

To set up the School Management System API on your local machine, follow these steps:

1. Clone the repository
2. Navigate to the project directory
3. Restore the required NuGet packages: `dotnet restore`.
4. Configure the database connection string in the `appsettings.json` file.
5. Apply the database migrations to create the required tables.
6. Start the API server: `dotnet run`, or start the API in Visual Studio.
7. Access the API endpoints through your preferred API client or use Swagger UI at [http://localhost:5000/swagger/index.html](http://localhost:5000/swagger/index.html).

## Usage

Once the School Management System API is up and running, you can make HTTP requests to interact with the various endpoints. Refer to the Swagger documentation(when the api is running http://localhost:5000/swagger/index.html).

To authenticate requests that require authorization, include the appropriate authentication token in the request headers.

![Screenshot 2023-12-21 at 22-29-24 Swagger UI](https://github.com/BorisPaunovic/School-Management-System-API/assets/119711363/cf81f6a7-fa14-4ddd-986d-490c5d275628)

Figure 1 Swager Documentation

## Contributing

Contributions to the School Management System API project are welcome. If you would like to contribute, please follow these guidelines:

1. Fork the repository and create your branch.
2. Make your changes and ensure they follow the project's coding conventions.
3. Write tests to cover your changes and ensure they pass.
4. Commit your changes.
5. Push to the branch.
6. Open a pull request.

## License

The School Management System API project is released under the MIT License. You are free to use, modify, and distribute the code according to the terms of the license.

## Contact

If you have any questions, suggestions, or feedback, please feel free to reach out. You can contact the project maintainers by opening an issue on the repository.

Thank you for your interest in the School Management System API project. We hope it proves to be a valuable component for building your school management system!
