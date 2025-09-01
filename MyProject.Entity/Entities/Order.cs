using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.Entity.Entities
{
    //Order-Dependent Entity(bağımlı varlık), Basket-Principal Entity(asıl varlık)
    public class Order : BaseEntity
    {
        public string? ShippingCountry { get; set; }
        public string? ShippingAddress { get; set; }
        public string? ShippingCity { get; set; }
        public string? ShippingPostalCode { get; set; }
        public string? Phone { get; set; }
        public string? Email { get; set; }
       
        public decimal TotalAmount { get; set; }
        public string? PaymentMethod { get; set; }
        public Guid BasketId { get; set; }
        public Basket? Basket { get; set; }

        public string? AppUserId { get; set; }
        public AppUser? AppUser { get; set; }

        public Guid OrderStatusId { get; set; }
        public OrderStatus? OrderStatus { get; set; }

        public Guid PaymentStatusId { get; set; }
        public PaymentStatus? PaymentStatus { get; set; }

    }
}
