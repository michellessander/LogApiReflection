using System.Collections;
using System.Collections.Generic;

namespace LogApiReflection.Domain
{
    public class Ordered : EntityBase
    {
        public IEnumerable<Book> Books { get; set; }
        public double TotalValue { get; private set; }

        public double SetTotalValue()
        {
            foreach (var book in Books)
            {
                TotalValue += book.Value;
            }

            return TotalValue;
        }
    }
}