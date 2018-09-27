using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace DementiaWebsite.Controllers
{
    [Route("player")]
    public class PlayerController : Controller
    {
        [Route("")]
        public IActionResult Index()
        {
            return View();
        }

        [Route("{firstName}/{lastName}/{age:range(1,150)}")]
        public IActionResult PlayerName(string firstName, string lastName, int age)
        {
            return new ContentResult { 
                Content = string.Format("firstName: {0}; lastName: {1}; age: {2}",
                                                         firstName, lastName, age)
            };
        }
    }
}
