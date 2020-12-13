using System;
using System.Collections.Generic;
using System.Text;

namespace GoldenShelf.Models
{
    public class Advert
    {
        public Guid Id { get; set; }
        public string BookName { get; set; }
        public string BookAuthor { get; set; }
        public string BookCategory { get; set; }
        public string ImageUrl { get; set; }
        public string BGColor { get; set; }
    }
}
