using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core2Base.Data;
using Core2Base.Models;
using Microsoft.AspNetCore.Mvc;

namespace Core2Base.Controllers
{
    public class SearchController : Controller
    {
        public IActionResult Index(string searchtext)
        {

            List<Product> SearchList = SearchData.GetSearchInfo(searchtext);

            ViewData["Searches"] = SearchList;
            return View();
        }
    }
}