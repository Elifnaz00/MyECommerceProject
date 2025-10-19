using MyProject.Entity.Entities;

namespace MyProject.WebUI.Models.OrderModel
{
    public class OrderViewModel
    {
        public string? ShippingCountry { get; set; }
        public string? ShippingAddress { get; set; }
        public string? ShippingCity { get; set; }
        public string? ShippingPostalCode { get; set; }
        public string? Phone { get; set; }
        public string? Email {get; set; }

        public decimal TotalAmount { get; set; }
        public string? PaymentMethod { get; set; }
        public Guid BasketId { get; set; }
        public string? NameSurname { get; set; }

      

    }
}
