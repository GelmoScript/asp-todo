using System;
using System.Collections.Generic;
using System.Linq;
using TodoItemApi.Contexts;
using TodoItemApi.Entities;

namespace TodoItemApi.Services.Repositories
{
    public class PointOfInterestRepository : IPointsOfInterestRepository
    {
        private readonly CityInfoContext _context;

        public PointOfInterestRepository(CityInfoContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public PointOfInterest Create(PointOfInterest interest)
        {
            var queryResult = _context.PointOfInterests.Add(interest);
            _context.SaveChanges();
            return queryResult.Entity;
        }

        public PointOfInterest Delete(int id)
        {
            PointOfInterest interestToDelete = GetPointOfInterestById(id);
            interestToDelete.IsDeleted = true;
            interestToDelete.DeleteDate = DateTime.Now;
            return interestToDelete;
        }

        public PointOfInterest GetPointOfInterestById(int id)
        {
            return _context.PointOfInterests.Where(poi => poi.Id == id).FirstOrDefault();
        }

        public IEnumerable<PointOfInterest> GetPointsOfInterest()
        {
            return _context.PointOfInterests.Where(p => !p.IsDeleted).ToList();
        }

        public PointOfInterest Update(PointOfInterest interest)
        {
            interest.LastUpdateDate = DateTime.Now;
            _context.SaveChanges();
            return interest;
        }
    }
}
