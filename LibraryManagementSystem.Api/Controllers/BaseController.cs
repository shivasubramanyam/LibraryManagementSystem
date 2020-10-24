using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace LibraryManagementSystem.Api.Controllers
{
    public abstract class BaseController : ControllerBase
    {
        public int UserId
        {
            get { return int.Parse(User.Claims.First(i => i.Type == "UserId").Value); }
        }
    }
}