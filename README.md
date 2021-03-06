# study-exception-filter
A small use case of custom exception handler filte.

This study covers: 
+ Creating a custon filter to handle any exception throed by the App.
+ Creating a generic Class Object response - overriding the ActionResult
+ Setting the Startup.cs 
+ Configuring API controller to set all it's actions to be handled by the Exception Handler Filter
+ Configuring specific API controller's action to use Exception Handler Filter

DotNet Framwwork version:
+ DotNetCore



#### API/Filter/ExceptionHandlingFilter
Will handle every exception thrown by classes decorated with ```[ExceptionHandlingFilter]```
Call the ApiResponse and perform client response.

At this point, you can call a Log Method - this is byond  the scope of this study.

#### API/Response/ApiResponse
Override the ```ActionResult``` and crete response object

#### API/Controller/CaosController
Decorate the controller class with ```[ExceptionHandlingFilter]``` and every exception will be haldled by ExceptionHandlingFilter class.

#### API/Controller/SpecificTreatedController
WithTreatment action is configured to use the exception custom filter, by adding the decorator ```[ExceptionHandlingFilter]```
NoTreatment action doesn't use the exception custon filter so it throws a 500 http status code to the client.


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

##### Conclusion

Configuring a exception filter will help you handling exceptions in a singular way.
This way you will avoid creating Tries and Catches all over the project.

You can configure the exception filter to be applied for your project using the Services.AddMvc where no other configuration will be needing or you can do it for a specific Controller or even an Action, just adding the filter as decorator.

Adding it to a specific controller or action will keep you with the possibility to treat other controllers or actions in a different way.
