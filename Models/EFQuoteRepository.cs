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
    }
}
