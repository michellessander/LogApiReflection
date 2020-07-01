using System.Collections.Generic;
using LogApiReflection.Domain;

namespace LogApiReflection.Services
{
    public interface IOrderedService
    {
        IEnumerable<Ordered> GetAll();
        Ordered GetById(int id);
    }
}