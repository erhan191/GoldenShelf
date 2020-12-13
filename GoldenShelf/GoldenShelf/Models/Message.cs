using System;
using System.Collections.Generic;
using System.Text;

namespace GoldenShelf.Models
{
    class Message
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Sender { get; set; }
        public string MessageText { get; set; }
        public string ImageUrl { get; set; }
        public string BGColor { get; set; }
    }
}
