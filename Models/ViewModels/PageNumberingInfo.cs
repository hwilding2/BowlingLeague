using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BowlingLeague.Models.ViewModels
{
    public class PageNumberingInfo
    {
        public int PageItems { get; set; }
        
        public int CurrentPage { get; set; }

        public int TotalItems {get;set;}

        //Calculate total num pages
        public int NumPages => (int)Math.Ceiling((TotalItems / (decimal)PageItems));
    }
}
