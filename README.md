# study-exception-filter
A small use case of custom exception handler filte.

This study covers: 
+ Creating a custon filter to handle any exception throed by the App.
+ Creating a generic Class Object response - overriding the ActionResult
+ Setting the Startup.cs 
+ Configuring controllers to set all it's actions to be handled by the Exception Handler Filter
+ Configuring specific actions to use Exception Handler Filter


#### API/Filter/ExceptionHandlingFilter
Will handle every exception thrown by classes decorated with ```[ExceptionHandlingFilter]```
Call the ApiResponse and perform client response.

#### API/Response/ApiResponse
Override the ```ActionResult``` and crete response object

#### API/Controller/CaosController
Decorate the controller class with ```[ExceptionHandlingFilter]``` and every exception will be haldled by ExceptionHandlingFilter class.

#### API/Controller/SpecificTreatedController
WithTreatment action is configured to use the exception custom filter, by adding the decorator ```[ExceptionHandlingFilter]```
NoTreatment action dont use the exception custon filter so it throws a 500 without any information to the client.


#### API/Startup
Configured the app to handle all the exceptions to use your customized filter.
```cs
services.AddMvc(options =>{
                options.Filters.Add(new ExceptionHandlingFilter());
            });
```
Not setting this to ```service.Add.MVC```, you will need to add a decorator over all the Controllers or Actions you whant to be handled by your filter, as you can see in the CaosController.cs file.

#### OuterLib
Collection of some Exceptions.

