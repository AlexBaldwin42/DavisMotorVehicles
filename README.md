# Running the project
The project uses .NET 7.0.  
## Nuget packages 
The nuget dependencies will need to be restored. This can be done with the nuget package manager or with `dotnet restore` on the command line.  
## Visual Studio  
Open DavisMotorVehicles.sln in the main directory with Microsoft Visual Studio ensure the project selected is DavisMotorVehicles.Server.  
Once all the dependancies have been loaded click the "Run" button or press F5.  
This will start up both the front end and webserver.  
## Command Line  
From within the /DavisMotorVehicles/Server folder run `dotnet run`  
Once building is finished it can be accessed at http://localhost:5122/  
  
# Project Structure   
DavisMotorVehicles.Client is a Blazor web assembly front end.
DavisMotorVehicles.Server is the .NET 7.0 API.  
DavisMotorVehicles.Data contains the Entity Framework Core ORM. It is a code first approach using Sqlite as the database. When the database is created it is seeded with data and stores the Sqlite file in this projects directory.  
DavisMotorVehicles.Shared contains the classes that the server and client use to pass data.  
DavisMotorVehicles.Test has the unit tests for the vehicle controller.  
  
# Screenshots
![](/Pictures/Layout.png)  
![](/Pictures/EditVehicle.png)  
