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
        [HttpGet]
        public IActionResult AddEdit(int QuoteId)
        {
            // if not a new quote, then return the model to the view
            if(QuoteId != 0)
            {
                Quote quote = repo.Quotes.Single(x => x.QuoteId == QuoteId);
                return View(quote);
          
            }

            else
            {
                return View();
            }
       
        }
        //For when they submit an edit or adding a new quote

        [HttpPost]
        public IActionResult AddEdit(Quote quote)
        {
            // only process if valid
            if (ModelState.IsValid)
            {

                repo.DoQuote(quote);
                return RedirectToAction("Index");
            }


            return View(quote);
        }

        // For when they delete a q uote

        public IActionResult Delete(int QuoteId)
        {
            Quote quote = repo.Quotes.Single(x => x.QuoteId == QuoteId);

            repo.Delete(quote);

            return RedirectToAction("Index");
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
