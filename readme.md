# Article Assignment

This is my implementation of the article assignment. It demonstrates my current way of coding. Obviously, there is always room for improvement and suggestions.

## Testing the API

The API is published in Azure and can be tested [here](https://artikelopdracht.azurewebsites.net/swagger/index.html) by using the Swagger UI.

## Running the code / Test locally

- Before running the code, change the connection string located in the file 'appsettings.json' in the project 'WebApi'
- Then open the package manager console (In VS 2022: View -> Other Windows -> Package Manager Console)
- Make sure that DataRepositories is selected as Default project
- Execute the command 'Update-database'

The test database should now be created on the location dictated in the connection string. For demonstration purposes for this assignment, a seed procedure is executed as well.
