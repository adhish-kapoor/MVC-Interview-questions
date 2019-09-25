//Web API can be accessed in the server side code in .NET and also on client side using JavaScript frameworks such as jQuery, AnguarJS, KnockoutJS etc.
========Consume Web API in ASP.NET MVC
To consume Web API in ASP.NET MVC server side we can use HttpClient in the MVC controller. 
HttpClient sends a request to the Web API and receives a response. 
We then need to convert response data that came from Web API to a model and then render it into a view.
  
public class StudentViewModel
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
        
    public AddressViewModel Address { get; set; }

    public StandardViewModel Standard { get; set; }
}  

Step 1:
create MVC controller class called StudentController in the Controllers folder as shown below. 
Right click on the Controllers folder > Add.. > select Controller..  
  public class StudentController : Controller
{
    // GET: Student
    public ActionResult Index()
    {            
        return View();
    }
}
Step 2:  
We need to access Web API in the Index() action method using HttpClient
  public class StudentController : Controller
{
    // GET: Student
    public ActionResult Index()
    {
        IEnumerable<StudentViewModel> students = null;

        using (var client = new HttpClient())
        {
            client.BaseAddress = new Uri("http://localhost:64189/api/");
            //HTTP GET
            var responseTask = client.GetAsync("student");
            responseTask.Wait();

            var result = responseTask.Result;
            if (result.IsSuccessStatusCode)
            {
                var readTask = result.Content.ReadAsAsync<IList<StudentViewModel>>();
                readTask.Wait();

                students = readTask.Result;
            }
            else //web api sent error response 
            {
                //log response status here..

                students = Enumerable.Empty<StudentViewModel>();

                ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
            }
        }
        return View(students);
    }
}
Step 3:
Now, we need to add Index view. Right click in the Index action method and select Add View.. option.
This will open Add View popup as shown below. Now, select List as template and StudentViewModel as Model class
This will generate following Index.cshtml.
  @model IEnumerable<WebAPIDemo.Models.StudentViewModel>

@{
    ViewBag.Title = "Index";
    Layout = "~/Views/Shared/_Layout.cshtml";
}

<h2>Index</h2>

<p>
    @Html.ActionLink("Create New", "Create")
</p>
<table class="table">
    <tr>
        <th>
            @Html.DisplayNameFor(model => model.FirstName)
        </th>
        <th>
            @Html.DisplayNameFor(model => model.LastName)
        </th>
    <th></th>
    </tr>

    @foreach (var item in Model) {
        <tr>
            <td>
                @Html.DisplayFor(modelItem => item.FirstName)
            </td>
        <td>
            @Html.DisplayFor(modelItem => item.LastName)
        </td>
        <td>
            @Html.ActionLink("Edit", "Edit", new { id=item.Id }) |
            @Html.ActionLink("Details", "Details", new { id=item.Id }) |
            @Html.ActionLink("Delete", "Delete", new { id=item.Id })
        </td>
        </tr>
    }

</table>

To display appropriate error message in the MVC view, add the ValidationSummary() as shown below.
  @model IEnumerable<WebAPIDemo.Models.StudentViewModel>

@{
    ViewBag.Title = "Index";
    Layout = "~/Views/Shared/_Layout.cshtml";
}

<h2>Index</h2>

<p>
    @Html.ActionLink("Create New", "Create")
</p>
<table class="table">
    <tr>
        <th>
            @Html.DisplayNameFor(model => model.FirstName)
        </th>
        <th>
            @Html.DisplayNameFor(model => model.LastName)
        </th>
    <th></th>
    </tr>

    @foreach (var item in Model) {
        <tr>
            <td>
                @Html.DisplayFor(modelItem => item.FirstName)
            </td>
            <td>
                @Html.DisplayFor(modelItem => item.LastName)
            </td>
            <td>
                @Html.ActionLink("Edit", "Edit", new { id=item.Id }) |
                @Html.ActionLink("Delete", "Delete", new { id=item.Id })
            </td>
        </tr>
    }
    <tr>
        <td>
            @Html.ValidationSummary(true, "", new { @class = "text-danger" })
        </td>
    </tr>
        
</table>

========Consume Web API in AngularJS
Web API can be accessed directly from the UI at client side using AJAX capabilities of any JavaScript framework such as AngularJS, KnockoutJS, Ext JS etc.
  
  
