using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;

using OSharp.AspNetCore.Mvc;


namespace OSharp.Samples.MasterSlaveSplit.Controllers
{
    public class HomeController : BaseController
    {
        public IActionResult Index()
        {
            return Content("Index Page");
        }
    }
}
