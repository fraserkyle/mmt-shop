# mmt-shop
MMT Shop - Technical Test

# Running the solution

- Follow the instructions within the console window
## Running the solution
'''
**Note**
I have included code to generate the database for you within this solution.  Simply follow the instructions below then select option a to generate the MMTShop database on your SQL Server instance.

I run SQL Server 2019 Developer Edition in a docker container by running docker-compose up -d for the below file.  I did consider using docker for the whole solution but encountered issues when trying to test the console application so this change has been reverted within the solution.

version: '3.4'

services:
  mmt.shop.database:
    image: mcr.microsoft.com/mssql/server
    environment:
      - ACCEPT_EULA=Y
      - SA_PASSWORD=Password_01
    ports:
      - '1433:1433'
'''

- Open the Mmt.Shop solution in visual Studio (I used 2019 Pro)
- Ensure "Debug" configuration is selected
- Update CATALOGUE_CONN_STRING environment variable (connection string for your SQL Server).  This can be updated within the Mmt.Shop.Api and Mmt.Shop.Console project properties under the "Debug" tab
- Update startup project settings to run Mmt.Shop.Console and Mmt.Shop.Api project
- Build the solution
- Ensure that the ssl url listed in the Mmt.Shop.api -> properties -> debug section matches the url listed in the Mmt.Shop.Console -> Properties -> Debug - Environment Variables section
- Click debug in Visual Studio
- Follow the instructions within the console window

# Recommendations

Given more time I would consider implementation fo the following changes.

- Update ASP.Net logging mechanism to log to database, message queue or other storage
- Update data access project to use metadata rather than static strings
- Move error message strings to a resource file
- Return user friendly errors when api calls fail
- Update demo console application to return data in tabular form rather than json
- Create unit tests for demo console application
- consider adding a Mmt.Shop.Business solution if any business logic is introduced to the solution

