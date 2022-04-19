using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Final_Mission.Models
{
    public class Context :DbContext
    {
        public Context()
        {

        }

        public Context(DbContextOptions<Context> options): base(options)
        {

        }

        public DbSet<Quote> Quotes { get; set; }
        protected override void OnModelCreating(ModelBuilder mb)
        {


            mb.Entity<Quote>().HasData(
                new Quote { Date = DateTime.Parse("4/5/2022 08:00:00"), QuoteId = 1, Author = "Brennan Williams", QuoteText="We are all sons and daughters of a loving heavenly father", Citation="Book of mormon"
                , Subject="Book of Mormon History"  },
                new Quote { Date = DateTime.Parse("4/5/2022 09:00:00"), QuoteId = 2, Author = "Brennan Williams", QuoteText="We are all sons and daughters of a loving heavenly father", Citation="Book of mormon"
                , Subject="Book of Mormon History"  },
                new Quote { Date = DateTime.Parse("4/5/2022 10:00:00"), QuoteId = 3, Author="Brennan Williams", QuoteText="We are all sons and daughters of a loving heavenly father", Citation="Book of mormon"
                , Subject="Book of Mormon History" }

                );


        }
    }
}
