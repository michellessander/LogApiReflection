using System.Collections.Generic;
using System.Linq;

namespace LogApiReflection.Domain
{
    public class Order : EntityBase
    {
        public IEnumerable<Book> Books { get; set; }
        public double TotalValue => Books.Sum(book => book.Value);
    }
}