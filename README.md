
# City West Water coding test  

## Author

Max Zhou

## Description
The api project is build on .NET core 2.2, please install the SDK if you don't have it installed.
I also include the nodejs installer inside the repository, please install it if you don't have it installed.
## Example usage

Invoke api project
```sh
Use visual studio 2017 or laster to open the solution project and run
```
.NET project is require visual stuido to open

Create Database
##### The Code First Approach was used in this project. The migration scripts are stored under project_root/Migrations folder. To create a new databaes, please fill in the database ConnectionString in project_root/appsettings.json, then run below script.
```sh
.\create-database.ps1
```

Invoke the UI

```sh
.\run-UI.ps1
```

### Test
```sh
.\run-tests.ps1
```
I also added swagger to the api project, you can simply run the api project and test the api from swagger ui.