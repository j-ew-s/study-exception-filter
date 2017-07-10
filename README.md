# study-exception-filter
A small use case of custom exception handler filter.

#### API/Filter/ExceptionHandlingFilter
Will handle every exception thrown by classes decorated with [ExceptionHandlingFilter]
Call the ApiResponse and perform client response.

#### API/Response/ApiResponse
Override the ActionResult and crete response object

#### API/Controller/CaosController
Decorate the controller with [ExceptionHandlingFilter] and every exception will be haldled by ExceptionHandlingFilter class

#### API/Startup
Configured the app to handle all the exceptions to use your customized filter.
services.AddMvc(options =>{
                options.Filters.Add(new ExceptionHandlingFilter());
            });
Not setting this to service.Add.MVC, you will need to add a decorator over all the Controllers or Actions you whant to be handled by your filter, as you can see in the CaosController.cs file.

#### OuterLib
Collection of some Exceptions.

