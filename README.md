# DotVVM Northwind LOB Sample

This repository contains a sample line of business application written in DotVVM, based on the Microsoft sample [Northwind](https://northwinddatabase.codeplex.com/) database. 

## Preparing the database

1. Go to the `db` folder. 

1. If you don't have Micrososft SQL Server Express edition installed (`.\SQLEXPRESS`), edit the `northwind.cmd` file and change the server name.
You will have change the connection string in the application too (`src/NorthwindStore.DAL/AppDbContext.cs`).

1. Run the `northwind.cmd`. It should create the database called `Northwind` with all the data.

## Running the application 

1. Install the [DotVVM for Visual Studio](https://marketplace.visualstudio.com/items?itemName=TomasHerceg.DotVVMforVisualStudio-17892) extension if you don't have it.

1. Sign up for an account on DotVVM.com and request access to [DotVVM Business Pack Beta Program](https://www.dotvvm.com/login) to get the beta version.

1. Make sure to set up the [DotVVM Private Nuget Feed](https://www.dotvvm.com/docs/tutorials/commercial-dotvvm-private-nuget-feed/latest).

1. Open the solution (`src/NorthwindStore.sln`) in Visual Studio 2017. 

## What's inside

The application tries to explain how DotVVM should be used in larger applications.

1. The `DAL` project contains the `Entity Framework Core` model describing the SQL database.

2. The `BL` project contains the infrastructure for the application logic. It utilizes the [Riganti Utils Infrastructure](https://github.com/riganti/infrastructure) library.
From the DotVVM perspective, only the classes in the `Facades` and `DTO` directories are interesting, because they contain all methods and model classes the application needs.
DotVVM doesn't have any specific requirements on the business layer, however it is a good idea to have the application logic and DTO objects in a separate class library project.

3. The `App` project contains the application itself.

	* The `RegionList` and `RegionDetail` pages demonstrate how to do a simple CRUD functionality, by just using the facade.
	
	* The `CategoryList` and `CategoryDetail` pages demonstrate how to generalize the CRUD using a generic class and interfaces for facades.
	
	* The `ProductList` and `ProductDetail` pages shows how to customize the CRUD with combobox selectors, custom controls and modal dialogs.
	
	* The `Default` page shows how to use authentication and authorization.
	
	* Using custom presenters to serve images.
	
	* And finally, the Application Insights and MiniProfiler integration is demonstrated.

## Libraries Used

The sample uses the following libraries:

* Entity Framework Core
* AutoMapper
* Castle Windsor
* Riganti Utils Infrastructure

## More Resources

* [DotVVM Website](https://www.dotvvm.com)
* [DotVVM GitHub](https://github.com/riganti/dotvvm)
* [Documentation](https://dotvvm.com/docs)
* [Gitter Chat](https://gitter.im/riganti/dotvvm)
* [DotVVM Business Pack](https://www.dotvvm.com/landing/business-pack)

