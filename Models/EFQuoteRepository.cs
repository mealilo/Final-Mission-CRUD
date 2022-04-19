using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Final_Mission.Models
{
    public class EFQuoteRepository : IQuoteRepository
    {
        // creates context and constructor
        private Context context { get; set; }

        public EFQuoteRepository(Context temp)
        {
            context = temp;
        }


        public IQueryable<Quote> Quotes => context.Quotes;

        public void DoQuote(Quote quote)
        {
            if (quote.QuoteId == 0)
            {

                quote.Author = quote.Author.ToUpper();
                context.Quotes.Add(quote);
            }
            else
            {
                quote.Author = quote.Author.ToUpper();
                context.Update(quote);
            }

            context.SaveChanges();
        }

        public void Delete(Quote quote)
        {
            context.Remove(quote);
            context.SaveChanges();
        }
    }
}
