using CarCrudPgsql.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarCrudPgsql.Data
{
    public interface ICarRepository
    {
        IEnumerable<Car> GetAll();

        Car GetById(int id);

        void Create(Car car);

        void Update(Car car);

        void Delete(Car car);
    }
}
