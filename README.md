![Screenshot](https://raw.githubusercontent.com/riganti/dotvvm-samples-northwind/master/images/ns001.png)

## Northwind Store in DotVVM

This is a simple line of business application written in DotVVM, based on the well-known Microsoft sample Northwind database. 

### Prerequisites
* Get access to the [DotVVM Business Pack](https://www.dotvvm.com/products/dotvvm-business-pack)
    * You can request a **free 30-days trial**. To do that, [sign up for an account](https://www.dotvvm.com/login) at DotVVM website and request the trial of DotVVM Business Pack.
    * If you have already purchased the license, you are all set.
* Make sure you have installed [DotVVM for Visual Studio](https://www.dotvvm.com/install)
* Sign in with your account in DotVVM for Visual Studio in order to be able to access the NuGet package with DotVVM Business Pack: ![Screenshot](https://raw.githubusercontent.com/riganti/dotvvm-samples-northwind/master/images/ns002.png)

### How to run the sample

1. [Open the GitHub repo in Visual Studio](git-client://clone/?repo=https%3A%2F%2Fgithub.com%2Friganti%2Fdotvvm-samples-northwind)
or 
`git clone https://github.com/riganti/dotvvm-samples-northwind.git`

2. Open `src/NorthwindStore.sln` 
![Open the solution file](https://raw.githubusercontent.com/riganti/dotvvm-samples-northwind/master/images/ns003.png)

3. Right-click the `NorthwindStore.App` project and select **View > View in Browser**
![View FlightFinder.Api in Browser](https://raw.githubusercontent.com/riganti/dotvvm-samples-northwind/master/images/ns004.png)

4. Use **admin** / **admin** credentials on the login screen.

### What you can learn in the sample

* How to make a simple CRUD page with DotVVM components (Regions section)
* How to make generic CRUD ViewModels with extensibility points (Categories section)
* How to work with modal dialogs and row selections (Products section)
* How to generate the UI dynamically from the data model using [DotVVM Dynamic Data](https://github.com/riganti/dotvvm-dynamic-data) (Suppliers section)
* How to create a global error-handling action filter
* How to use a custom presenter to serve images from the database
* How to use Application Insights and MiniProfiler with DotVVM to get diagnostics data

---

# What's inside

The application demonstrates how DotVVM can be used in larger applications.

1. The `DAL` project (Data Access Layer) contains the `Entity Framework Core` model describing the SQL database.

2. The `BL` project (Business Layer) contains the application logic. It utilizes the [Riganti Utils Infrastructure](https://github.com/riganti/infrastructure) library, but any other way of implementing and exposing business logic can be used.
From the DotVVM perspective, only the classes in the `Facades` and `DTO` directories are interesting, because they contain all methods and model classes the application needs (aka __Model__).
DotVVM doesn't have any specific requirements on the business layer, however it is a good idea to have the application logic and DTO objects in a separate class library project - do not pass Entity Framework entities in the presentation layer.

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

---

## Other resources

* [Gitter Chat](https://gitter.im/riganti/dotvvm)
* [DotVVM Official Website](https://www.dotvvm.com)
* [DotVVM Documentation](https://www.dotvvm.com/docs)
* [DotVVM GitHub](https://github.com/riganti/dotvvm)
* [Twitter @dotvvm](https://twitter.com/dotvvm)
* [Samples](https://www.dotvvm.com/samples)
* [DotVVM Business Pack](https://www.dotvvm.com/products/dotvvm-business-pack)
