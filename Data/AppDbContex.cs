using CarCrudPgsql.Models;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace CarCrudPgsql.Data
{
    public class AppDbContex
    {
        private readonly NpgsqlConnection conn = new("Server=localhost;Port=5432;Database=postgres;User Id=postgres;Password=1203");

        public List<Car> Shov()
        {
            List<Car> cars = new();
            DataTable table = null;

            string query = "SELECT * FROM carss";

            try
            {
                conn.Open();

                using (NpgsqlCommand cmd = new(query, conn))
                {
                    using (NpgsqlDataAdapter da = new(cmd))
                    {
                        table = new DataTable();
                        da.Fill(table);
                    }
                }
            }
            catch { }
            finally { conn.Close(); }

            if (table != null && table.Rows.Count > 0)
            {
                foreach (DataRow row in table.Rows)
                {
                    Car car = new(row);
                    cars.Add(car);
                }
            }
            return cars;

        }

        public Car GetById(int id)
        {
            List<Car> cars = Shov();
            Car car = (Car)cars.Where(x => x.id == id).FirstOrDefault();
            return car;
        }

        public void Create(Car car)
        {
            if (car != null)
            {
                try
                {
                    conn.Open();
                    string query = $"INSERT INTO carss VALUES (DEFAULT,'{car.companyName}','{car.carName}','{car.price}');";

                    using (NpgsqlCommand cmd = new(query, conn))
                    {
                        var a = cmd.ExecuteNonQuery();
                    }
                }
                catch { }
                finally { conn.Close(); }
            }
        }

        public void Update(Car car)
        {
            if (car != null)
            {
                try
                {
                    conn.Open();
                    string query = $"UPDATE carss SET companyname='{car.companyName}',carname='{car.carName}',price='{car.price}' WHERE id='{car.id}';";

                    using (NpgsqlCommand cmd = new(query, conn))
                    {
                        var a = cmd.ExecuteNonQuery();
                    }
                }
                catch { }
                finally { conn.Close(); }
            }
        }

        public void Remove(Car car)
        {
            if (car != null)
            {
                try
                {
                    conn.Open();
                    string query = $"DELETE FROM carss WHERE id='{car.id}';";

                    using (NpgsqlCommand cmd = new(query, conn))
                    {
                        var a = cmd.ExecuteNonQuery();
                    }
                }
                catch { }
                finally { conn.Close(); }
            }
        }

    }
}
