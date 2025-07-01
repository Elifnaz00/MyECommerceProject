using MyProject.Entity.Entities;
using System.Diagnostics.CodeAnalysis;

namespace MyProject.WebUI.Models.ProductModel
{
    public class ProductDetailViewModel
    {
        public Guid Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public long? Price { get; set; }
        public string? ImageUrl { get; set; }
        public string? ProductCode { get; set; }

        [NotNull]
        public Guid CategoryId { get; set; }

        [NotNull]
        public virtual Category? Category { get; set; }


    }
}
