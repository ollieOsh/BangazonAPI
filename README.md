# Bangazon Platform API - Teamname-Teamname-Teamname

This .NET Web API makes each resource in the Bangazon ERD available to application developers throughout the entire company.

1. Products
1. Product types
1. Customers
1. Orders
1. Payment types
1. Employees
1. Computers
1. Training programs
1. Departments

Version 1.0 of the API will be completely open. Future versions will include an authentication method.

## Restrictions:
Only requests from the `www.bangazon.com` domain are allowed. Requests from that domain are able to access every resource, and perform any operation in a resource.

## Steps:

1. Create an environment variable in your `.zschrc` or `.bashrc` file with the following syntax:
`export BANGAZON_DB="/Users/mitchellblom/workspace/c19/bangazon/BangazonAPI/bang.db"`

2. Clone from github using `git clone` `https://github.com/teamname-teamname-teamname/BangazonAPI.git`
`cd` into the directory you created

3. Execute the following commands in your terminal:
    ```
    dotnet ef migrations add Initial
    dotnet ef database update
    dotnet run
    ```

## System configurations:

Install Postman to POST, PUT, and DELETE as needed. https://www.getpostman.com/
Install DB Browser for SQLite to view the database. http://sqlitebrowser.org/

## Contributors

* Joey Biotti
* Kathy Weisensel
* Ollie Osinusi
* Dilshod Nurmamatov