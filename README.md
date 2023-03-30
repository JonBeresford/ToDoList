### Solution
1. Api Project
A dotnet core api project being used to host a restful api. To run the project, either click debug in Visual Studio or VS Code or run the following from the command line in the api directory: 
    ```
	dotnet restore
	dotnet run
	```
2. UI Website
A VueJs single page application (SPA) being used to host the user interface. To run the project, run the following commands from the command line in the ui directory:
    ```bash
	npm i
	npm run serve
	```
3. Api Test Project
A xUnit test project used to test the Api Project. To run the project, either use Visual Studio Test Explorer or run the following commands from the command line in the api.tests directory:
    ```
	dotnet restore
	dotnet test
	```

 
