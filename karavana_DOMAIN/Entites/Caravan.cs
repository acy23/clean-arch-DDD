using karavana_DOMAIN.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace karavana_DOMAIN.Entites
{
    public sealed class Caravan : BaseSqlEntity
    {
        public Caravan(
                string name, 
                double price,
                Currency currency,
                double rate,
                FuelType fuelType,
                CaravanType caravanType,
                string city,
                string district)
        {
            Name = name;
            Price = price;
            Currency = currency;
            Rate = rate;
            FuelType = fuelType;
            CaravanType = caravanType;
            City = city;
            District = district;
        }

        public string Name { get; private set; }
        public double Price { get; private set; }
        public Currency Currency { get; private set; }
        public double Rate { get; private set; }
        public FuelType FuelType { get; private set; }
        public CaravanType CaravanType { get; private set; }
        public string City { get; set; }
        public string District { get; set; }
    }
}
