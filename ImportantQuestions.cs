1.Output caching in MVC--> prevents same content to be generated each time controller method is invoked.

OutputCache label has a "Location" attribute and it is fully controllable.
Its default value is "Any", however there are the following locations available; as of now, we can use any one.
-Any
-Client
-Downstream
-Server
-None
-ServerAndClient
With "Any", the output cache is stored on the server where the request was processed. 
=============
2.Display mode in MVC--> for having an alternative view
=============
3.Default route in MVC--> URL:{controller}/{action}/{id}
=============
4.MVC application cycle
-->creating the request object and second sending our response to the browser.

Creating the request object includes four basic steps: 

Step 1: Fill route
Step 2: Fetch route
Step 3: Request context created
Step 4: Controller instance created 
=============
5.Action filters
-->Action Filters are additional attributes that can be applied to either a controller section or the entire controller to modify the way in which action is executed. 
These attributes are special .NET classes derived from system attributes, which can be attached to classes, methods, properties, and fields.
=============
6.Routing 
--> Routing is a mechanism to process the incoming URL that is more descriptive and gives the desired response. 
In this case, URL is not mapped to specific files or folder, as was the case of websites in the past.
=============
7.Partial view
--> A partial view is a chunk of HTML that can be safely inserted into an existing DOM. 
Most commonly, partial views are used to componentize Razor views and make them easier to build and update. 
Partial views can also be returned directly from controller methods. 
In this case, the browser still receives text/HTML content but not necessarily HTML content that makes up an entire page. 
As a result, if a URL that returns a partial view is directly invoked from the address bar of a browser, an incomplete page may be displayed. 
This may be something like a page that misses title, script and style sheets.
=============
8.TempData 
--> TempData is a dictionary object to store data temporarily. 
It is a TempDataDictionary class type and instance property of the Controller base class. 
TempData can keep data for the duration of an HTTP request; in other words, it can keep live data between two consecutive HTTP requests.
It will help us to pass the state between action methods. 
TempData only works with the current and subsequent request.
TempData uses a session variable to store the data. 
TempData Requires type casting when used to retrieve data.
=============
9.Razor 
--> SP.NET MVC has always supported the concept of “view engines” – which are the pluggable modules, which practically implement different template syntax options. 
The “default” view engine for ASP.NET MVC uses the same .aspx/.ascx/. master file templates as ASP.NET Web Forms.
Other popular ASP.NET MVC view engines are Spart&Nhaml. 
Razor is the new view engine introduced by MVC 3.
=============
10.DB first approach in MVC using Entity framework
--> Database First Approach is an alternative or substitutes to the Code First and Model First approaches to the Entity Data Model. 
The Entity Data Model creates model codes (classes, properties, DbContext, etc.) from the database in the project and
that class behaves as the link between database and controller.

There are the following approaches, which are used to connect the database with the application.

#Database First
#Model First
#Code First
=============
11.Bundling and Minification
--> Bundling and minification are two new techniques introduced to improve request load time. 
It improves load time by reducing the number of requests to the server and reducing the size of requested assets (such as CSS and JavaScript).
Bundling: It lets us combine multiple JavaScript (.js) files or multiple cascading style sheet (.css) files so that they can be downloaded as a unit, 
rather than making individual HTTP requests.

Minification: It extracts the whitespace and performs other types of compression to make the downloaded files as small as possible.
At runtime, the process recognizes the agent of the user, for example, IE, Mozilla, etc. and then removes whatever is specific to Mozilla when the request comes from IE.
=============
12.Action Filters
--> Action Filters are additional attributes that can be applied to either a controller section or the entire controller to modify the way in which action is executed.
These attributes are special .NET classes derived from System.Attribute which can be attached to classes, methods, properties and fields.

ASP.NET MVC provides the following action filters,
#Output Cache
This action filter caches the output of a controller action for a specified amount of time.

#Handle Error
This action filter handles errors raised when a controller action executes.

#Authorize
This action filter enables you to restrict access to a particular user or role.
=============
13. Session in MVC application
Using session variable we can pass data from model to controller or controller to view.
->>Create a Model
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
 
namespace MVC3.Models
{
    public class Customer
    {
        public String Name { get; set; }
        public String Surname { get; set;}
    }
}

->>Create a Controller to process model data and set in session variable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC3.Models;
 
namespace MVC3.Controllers
{
    public class CustomerController : Controller
    {
        public ActionResult Index()
        {
            Customer Obj = new Customer();
           
            Obj.Name = "Sourav ";
           
            Obj.Surname = "Kayal";
           
            Session["Customer"] = Obj;
            return View();
        }
 
    }
}

->>Create a view to display data
@{
    Layout = null;
}
 
<!DOCTYPE html>
 
<html>
<head>
    <title>Index</title>
</head>
<body>
    <div>
        @{
            var CustomerInfo = (MVC3.Models.Customer) Session["Customer"];
        }
       
        Customer Name is :- @CustomerInfo.Name;
        <br />
       
        Customer Surname is :-@CustomerInfo.Surname;
    </div>
</body>
</html>
-----
ASP.NET MVC provides three ways (TempData, ViewData and ViewBag) to manage session, apart from that we can use session variable, hidden fields and HTML controls for the same.
But like session variable these elements cannot preserve values for all requests; value persistence varies depending the flow of request.
==========
14.SESSION MODES IN ASP.NET:
ASP.NET provides various Session Modes for storage of Session Data.
->>InProc mode: This is the default Session State modes which store the session data in memory on the web server.
->>StateServer (Out-Proc) mode: This stores the session data in separate memory called the ASP.NET Service. 
 This mode ensures that the session data preserves when the Application Process restarts.
->>SQL Server mode: In this mode session data is stored in the SQL Server Database. 
 This mode also ensures that the session data preserves when the Web Application restarted. Also, this mode makes session data available to several Web Server.
->>Custom mode: This mode enables you to specify the custom storage option.
->>Off mode: This mode disables the session state. This increases the performance of the application.
 
