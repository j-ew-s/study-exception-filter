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
Configured the exception for the app
 services.AddMvc(options =>{
                options.Filters.Add(new ExceptionHandlingFilter());
            });

#### OuterLib
Collection of some Exceptions.

