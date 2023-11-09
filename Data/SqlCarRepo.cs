using CarCrudPgsql.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarCrudPgsql.Data
{
    public class SqlCarRepo:ICarRepository
    {
        private readonly AppDbContex _contex;

        public SqlCarRepo(){ }

        public SqlCarRepo(AppDbContex appDbContex)
        {
            _contex = appDbContex;
        }

        public void Create(Car car)
        {
            _contex.Create(car);
        }

        public void Delete(Car car)
        {
            _contex.Remove(car);
        }

        public IEnumerable<Car> GetAll()
        {
            List<Car> cars = _contex.Shov();

            return cars;
        }

        public Car GetById(int id)
        {
            Car car = _contex.GetById(id);

            return car;
        }

        public void Update(Car car)
        {
            _contex.Update(car);
        }
    }
}
