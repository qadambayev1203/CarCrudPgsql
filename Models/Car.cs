using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace CarCrudPgsql.Models
{
    public class Car
    {
        public int id { get; set; }

        [Required]
        [MaxLength(250)]
        public string companyName { get; set; }

        [Required]
        [MaxLength(250)]
        public string carName { get; set; }

        [Required]
        public decimal price { get; set; }

        public Car(){ }

        public Car(DataRow row)
        {
            id = int.Parse("" + row["id"]);
            companyName = row["companyname"].ToString();
            carName = row["carname"].ToString();
            price = decimal.Parse("" + row["price"]);
        }
    }
}
