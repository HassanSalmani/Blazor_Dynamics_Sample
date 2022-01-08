
using Blazor_Dynamics_Sample.Shared.DataAccess;
using Blazor_Dynamics_Sample.Shared.Models;
using Blazor_Dynamics_Sample.Shared.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Blazor_Dynamics_Sample.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : Controller
    {
        DataService dataService = new DataService();

        public ActionResult<List<XrmAccount>> GetAssessmentTemplates()
        {
            var xrmAccounts = dataService.GetAccounts();

            return xrmAccounts.Take(10).ToList();
        }
    }
}
