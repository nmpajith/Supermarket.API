using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Supermarket.API.DataTransferObjects
{
    public class ProductDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int QuantityInPackage { get; set; }
        public string UnitOfMeasurement { get; set; }
        public CategoryDto Category { get; set; }
    }
}
