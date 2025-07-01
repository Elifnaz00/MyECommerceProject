using System.ComponentModel.DataAnnotations;

namespace MyProject.WebUI.Models.OrderModel
{
    public class AddToShoppingCardViewModel
    {
        [Display(Name = "Piece")]
        public int Piece { get; set; }


        [Display(Name = "ProductId")]
        public Guid ProductId { get; set; }


        [Display(Name ="Price")]
        public long Price { get; set; }

        [Display(Name = "ImageUrl")]
        public string? ImageUrl {  get; set; }


        [Display(Name = "Title")]
        public string? Title { get; set; }

    }
}
