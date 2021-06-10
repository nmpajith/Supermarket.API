using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Supermarket.API.DataTransferObjects
{
    public class ProductsQueryDto : QueryDto
    {
        public int? CategoryId { get; set; }
    }
}
