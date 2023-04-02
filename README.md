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


How long did you spend on your solution?
	Around 4 hours

What technical and functional assumptions did you make when implementing your solution?

	```I assumed there would be some kind of data store required. In this instance I used the in memory database 
	but in production this can easily be swapped out for any other provider.
	I also assumed the tests for the front end would be initialised for me. 
	In my work the front end tests framework has always been pre written and I have only altered and added to already existing code.
	In this case I stuck with my strengths and concentrated on the back end design and architecture.

	I have also assumedso kind of swagger should be availble to document api calls. so i have added that
  
	

Briefly explain your technical design and why do you think is the bestapproach to this problem.

	```The tests on the api are for the controller only but in a production solution each layer/ class method would have their own well defined tests.
	Both unit tests and outside in tests would be written.
	Good spearation of concerns promotes testability 
	



