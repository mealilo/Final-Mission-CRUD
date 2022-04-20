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

        public IActionResult Random()
        {

            // get max and min to go from min max, this has problems if you delete some  rows, so I have commented it out
            //int minID = repo.Quotes.Min(x => x.QuoteId);
            //int maxID = repo.Quotes.Max(x => x.QuoteId);
            

            // get list of valid ideas
            List<int> listofValidIDs = repo.Quotes.Select(x => x.QuoteId).ToList();


            // package to gen random numbers
            Random Random = new Random();
     

            int minID = 0;

            // to get index, we do count -1 
            int maxID = (listofValidIDs.Count() - 1);


            //gets random number based on random index of valid int's
            int random_index = new Random().Next(minID, maxID); // Generates a number between 1 to 10

            // get index of the random number that is in the list of valid id's
            int random_number = listofValidIDs[random_index];

            // gets quote based on random number
            Quote randomQuote = repo.Quotes.Single(x => x.QuoteId == random_number);
            
            // send quote back to random page
            return View(randomQuote);
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
