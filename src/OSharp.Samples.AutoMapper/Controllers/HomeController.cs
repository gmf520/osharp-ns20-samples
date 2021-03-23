
using System;
using System.Collections.Generic;

using Microsoft.AspNetCore.Mvc;

using OSharp.Collections;


namespace OSharp.Samples.AutoMapper.Controllers
{
    public class HomeController : Controller
    {
        private const string NewLine = "\r\n";
        private readonly IServiceProvider _provider;

        public HomeController(IServiceProvider provider)
        {
            _provider = provider;
        }

        public IActionResult Index()
        {
            List<string> list = new List<string>();

            list.Add("index");



            return Content(list.ExpandAndToString(NewLine));
        }
    }
}
