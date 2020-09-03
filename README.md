# 200904 MVC Persistence Project

### Project Concepts

- Define routes using controller methods
- Create complex relational models bound in controller methods
- Persist model based data in sqlite database 
- Render data from models in views
- Demonstrate an understanding of .NET conventions
- Demonstrate an ability to gracefully handle exceptions
- Demonstrate good version control practices through pushing at benchmarks with meaningful commit messages
- Demonstrate appropriate planning, use of resources, and testing

### Project Objectives

- Create a .NET MVC `Artist Residency Program` application to view, add, update and delete artists participating in the residency and their works of art. 
- Provide a typed or written draft of models needed in accordance with project details
- Provide wire-frames for all views in accordance with project details
- Provide postman collection for routes created in accordance with project details
- Include useful/meaningful comments in project files
- Remove/replace any unnecessary/unused links in default MVC application

### Project Details
- Set up application to persist data
    - add required packages
    - create database context which extends base class DbContext
    - create database set(s) in accordance with requirements
    - make required updates to app settings and service configuration

- Define a Work of Art Model
    - work of art id : primary key
    - work of art title 
    - work of art medium : required
    - work of art description : required, under 300 characters
    - work of art year completed : required, between this year and 50 years ago
- Define an Artist Model
    - artist id : primary key
    - artist first name : required
    - artist last name : required
    - artist alias
    - artist summary (about me paragraph) : required, under 150 characters
    - artist works of art

- Navigation to view all artists in the residency and artists with over 5 or more works of art 

- View All Artists 
    - GET request
    - use a partial view to display each artist from the database
    - display id, full name, alias, and summary
	- if an artist has 1 or more works of art display the number of works of art and a link to view all associated works of art 

- View Artist Works of Art
    - GET request 
    - use a partial view to display the details of each associated work of art
	- accessed through a link in each artists information if that artist has 1 or more works of art
    - display work of art id, title, medium, description, and year completed

- Add an Artist
	- POST request
    - add an artist to the database using a bound model
    - if data is valid, add Artist to database and display all artists in browser
    - if data is NOT valid, display model error in browser

- Add an Artist's Work of Art
	- POST request
    - add an artist's work of art to the database using a bound model
    - if the artist associated with the new work of art is found and data is valid, add Work of Art to database and display all artist in browser
    - if the artist associated with the new work of art is NOT found or data is NOT valid, display an appropriate message in the browser 

- Update a Work of Art
    - PUT request to update the title and description of a work of art from the database
    - if data is valid, update work of art in database and display all artists in browser
    - if data is NOT valid, display model error in browser

- Delete a Work of Art
    - DELETE request to remove a work of art from the database
    - if deletion is successful display all artists in the
    - if deletion is unsuccessful display useful message in the browser

- BONUS : use bootstrap to style views and partial views
