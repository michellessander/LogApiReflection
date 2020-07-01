using System.Collections.Generic;
using LogApiReflection.Domain;

namespace LogApiReflection.Repositories
{
    public interface IOrderedRepository
    {
        IEnumerable<Ordered> GetAll();
        Ordered GetById(int id);
    }
}