# Running the project
Load up the solution in Microsoft Visual Studio ensure the project selected is DavisMotorVehicles.Server.  
The project is build with .NET 7.0.
The nuget dependencies will need to be restored. This can be done in with the nuget package manager or with `dotnet restore` on the command line.  
Once all the dependancies have been loaded it click the "Run" button or press F5.  
This will start up both the front end and webserver.  


# Project Structure   
DavisMotorVehicles.Client is front end is Blazor web assembly.  
DavisMotorVehicles.Server is the .NET 7.0 Api.  
DavisMotorVehicles.Data is the Database sturucture for Entity Framework Core it uses a code first approach using Sqlite as the storage. When the database is created is seeds it with data and stores the Sqlite file in this projects directory.
DavisMotorVehicles.Shared Contains the classes that the server and the client uses to pass data.  
DavisMotorVehicles.Test has the unit tests for the vehicle controller.  



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
