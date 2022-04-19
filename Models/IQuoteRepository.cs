using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Final_Mission.Models
{
    public interface IQuoteRepository
    {
        // get table
        IQueryable<Quote> Quotes { get; }


        // either update or edit a quote
        public void DoQuote(Quote quote);

        // delete quote

        public void Delete(Quote quote);
    }
}
