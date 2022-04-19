using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Final_Mission.Models
{
    public interface IQuoteRepository
    {

        IQueryable<Quote> Quotes { get; }
    }
}
