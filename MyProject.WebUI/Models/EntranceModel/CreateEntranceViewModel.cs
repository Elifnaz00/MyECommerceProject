using System.ComponentModel.DataAnnotations;

namespace MyProject.WebUI.Models.EntranceModel
{
    public class CreateEntranceViewModel
    {
        public Guid Id { get; set; }    
        [Required]
        public string? Title1 { get; set; }
        [Required]
        public string? Description1 { get; set; }
        public string? Description2 { get; set; }
        public string? Description3 { get; set; }
        public bool IsChecked { get; set; }
    }

}
