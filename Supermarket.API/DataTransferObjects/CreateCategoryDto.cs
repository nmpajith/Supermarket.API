using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Supermarket.API.DataTransferObjects
{
    public class CreateCategoryDto
    {
        [Required]
        [MaxLength(30)]
        public string Name { get; set; }
    }
}
