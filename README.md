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


README.md
# Exercise Requirements  

Your choice for the front end framework. We use Angular @ Davis County
Use .NET Core framework
Commit your code to the Github repo no later than Sunday, January 29th at 11:59 p.m.
Write a vehicle tracking system. This should allow someone to track a car, truck, motorcycle, and boat. This system should track the fuel level and the number and state of tires on the vehicle. The fuel level should be able to be adjusted. The tire status should be able to be retrieved and modified. Tire state could be mileage, tread depth, or a simple good/fair/bad condition.
The user interface is up to you.

Please submit instructions for running your application.

We will be choosing interview candidates from this exercise.

If you have something preventing you from being able to finish this task by the 29th, please email me at bdsmith@co.davis.ut.us
