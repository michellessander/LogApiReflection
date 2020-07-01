using System.Collections.Generic;
using System.Linq;

namespace LogApiReflection.Domain
{
    public class Ordered : EntityBase
    {
        public Ordered()
        {
            
        }

        public IEnumerable<Book> Books { get; set; }

        public double TotalValue => Books.Sum(book => book.Value);
    }
}