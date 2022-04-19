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
        public int QuoteId { get; set; }
        [Required(ErrorMessage = "A Quote Text is required")]
        public string QuoteText { get; set; }

        [Required(ErrorMessage ="A Quote Author Is Required")]
        public string Author { get; set; }
        public DateTime Date { get; set; }
        public string Subject { get; set; }
        public string Citation { get; set; }

    }
}
