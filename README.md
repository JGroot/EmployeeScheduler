# EmployeeScheduler
Senior Project using MVC  6
--very basic functionality--
Website at http://mcwendallkingscheduler.azurewebsites.net/


# EmployeeScheduler
Senior Project using MVC  6
--very basic functionality--
Website at http://mcwendallkingscheduler.azurewebsites.net/

***********************************************************************************************************************************
Setting up the database:
Open solution with VS 2015;

Right-click solution and select 'Restore NugGet Packages'

Right-click in SQL Server Object Explorer and create a new database called "McWendellKingSchedule"

Right-click the database, select Properties, and copy its connection string into the "ConnectionString" in appsettings.JSON

Add MultipleActiveResultSets=true as a parameter in the connection string.  It should look similar to this:
	"ConnectionString": "Data Source=(localdb)\\MSSQLLOCALDB;Initial Catalog=McWendellKingSchedule;MultipleActiveResultSets=true"
	
Save and build again

Right-click the project and select 'Open Folder in File Explorer'

Open a command prompt within form the file explorer.  Make sure the path is in McWendellKingSchedule\src\McWendellKingSchedule

Run the following commands:
	dnvm upgrade (.NET version manager for command line instructions)
	dnu restore (.NET Development Utility to build with DNX)
	dnx ef database update (applies the migrations that populates the database)

Close the command prompt and run the application.  	
***********************************************************************************************************************************

Created by Jessica Groot
Senior Final Project 
Spring 2016

project hosted at https://github.com/JGroot/EmployeeScheduler
