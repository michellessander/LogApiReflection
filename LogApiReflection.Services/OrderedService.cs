using System.Collections.Generic;
using LogApiReflection.Domain;
using LogApiReflection.Repositories;

namespace LogApiReflection.Services
{
    public class OrderedService: IOrderedService
    {
        private readonly IOrderedRepository _orderedRepository;
        
        public OrderedService(IOrderedRepository orderedRepository)
        {
            _orderedRepository = orderedRepository;
        }

        public IEnumerable<Ordered> GetAll() => _orderedRepository.GetAll();

        public Ordered GetById(int id) => _orderedRepository.GetById(id);
    }
}