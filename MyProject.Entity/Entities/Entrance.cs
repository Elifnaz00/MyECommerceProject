using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.Entity.Entities
{
    public class Entrance: BaseEntity
    {
        [Required]
        public string? Title1 { get; set; }
        [Required]
        public string? Description1 { get; set; }
        public string? Description2 { get; set; }
        public string? Description3 { get; set; }
        public string? ImageUrl { get; set; }

        public bool IsChecked { get; set; }
    }
}
