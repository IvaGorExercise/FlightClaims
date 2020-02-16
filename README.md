FlightClaims

At the moment solution contain two project:

1. Claims.API is ASP.NET Core RESTful API for underlying logic of claim process.
	It can be run from VS or from cmd with dotnet run and is running on http://localhost:5000/api/claims

	1.1 Definition and interaction with the API’s resources can be done on this adresses whent the API is running:
		http://localhost:5000/swagger/index.html
		http://localhost:5000/swagger/v1/swagger.json

	1.2 For development is used local MSSQL dataabase:
		localdb MSSQLLocalDB; Database=ClaimsDB; Trusted_Connection=True;MultipleActiveResultSets=true
			
2. WebMVC is ASP.NET Core MVC aplication and client for interacting with API
	 It can be run from VS or from cmd with dotnet run and is running on http://localhost:5500/

This is the early phase od development of this project and there are many TODOs and codes which will be changed.
It is possible to insert the claim at the moment but vidouth many validation and there is not checking flights and details of product, yet.



