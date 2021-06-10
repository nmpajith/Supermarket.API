using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Supermarket.API.DataTransferObjects
{
    public class QueryDto
    {
        public int Page { get; set; }
        public int ItemsPerPage { get; set; }
    }
}
