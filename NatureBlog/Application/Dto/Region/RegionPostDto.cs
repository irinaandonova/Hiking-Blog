using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dto.Region
{
    public class RegionPostDto
    {
        [Required]
        [MinLength(3)]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required]
        [MinLength(20)]
        [MaxLength(100)]
        public string Cordinates { get; set; }
    }
}
