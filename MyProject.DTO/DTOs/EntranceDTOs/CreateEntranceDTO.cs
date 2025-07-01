using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.TokenDTOs.DTOs.EntranceDTOs
{
    public class CreateEntranceDTO
    {

        public string? Title1 { get; set; }

        public string? Description1 { get; set; }
        public string? Description2 { get; set; }
        public string? Description3 { get; set; }
        public string? ImageUrl { get; set; }

        public bool IsChecked { get; set; }
    }
}
