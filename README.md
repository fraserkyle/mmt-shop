# mmt-shop
MMT Shop - Technical Test

# Running the solution

The solution has been developed using docker compose orchestration.  I have done this to ensure identical execution environment when running the solution on your machine.

- Follow the instructions within the console window
## Running the solution
- Open the Mmt.Shop solution in visual Studio (I used 2019 Pro)
- Ensure "Debug" configuration is selected
- Update CATALOGUE_CONN_STRING environment variable (connection string for your SQL Server).  This can be updated within the Mmt.Shop.Api and Mmt.Shop.Console project properties under the "Debug" tab
- Update startup project settings to run Mmt.Shop.Console and Mmt.Shop.Api project
- Build the solution
- Click debug in Visual Studio
- Follow the instructions within the console window

# Recommendations
- Update ASP.Net logging mechanism to log to database, message queue or other storage
- Update data access project to use metadata rather than static strings