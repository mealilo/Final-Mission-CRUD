using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Final_Mission.Models
{
    public class Quote
    {

        [Key]
        [Required]
        public int QuoteId { get; set; }
        [Required]
        public string QuoteText { get; set; }

        [Required]
        public string Author { get; set; }
        public DateTime Date { get; set; }
        public string Subject { get; set; }
        public string Citation { get; set; }

    }
}
