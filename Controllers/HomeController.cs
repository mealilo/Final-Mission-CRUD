using Final_Mission.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Final_Mission.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;


        // creates repo instance

        private IQuoteRepository repo { get; set; }

        // instantiates iquoterepository object for use in the controller
        public HomeController(ILogger<HomeController> logger, IQuoteRepository temp)
        {
            _logger = logger;
            repo = temp;
        }

        public IActionResult Index()
        {
            // gets all quotes, orders by author name
            ViewBag.Quotes = repo.Quotes.OrderBy( x => x.Author).ToList();
            return View();
        }


        public IActionResult Details(int QuoteId)
        {
            //Returns single object where the id is equal to the specified ID
            Quote quote = repo.Quotes.Single(x => x.QuoteId == QuoteId);


            // returns model to the view
           return View(quote);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
