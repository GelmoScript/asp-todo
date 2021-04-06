using System;
using System.Collections.Generic;
using TodoItemApi.Entities;

namespace TodoItemApi.Services.Repositories
{
    public interface IPointsOfInterestRepository
    {
        IEnumerable<PointOfInterest> GetPointsOfInterest();
        PointOfInterest GetPointOfInterestById(int id);
        PointOfInterest Create(PointOfInterest interest);
        PointOfInterest Update(PointOfInterest interest);
        PointOfInterest Delete(int id);
    }
}
