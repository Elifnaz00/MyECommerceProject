using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.Entity.Entities
{
    public class PaymentStatus: BaseEntity
    {
        public string? Name { get; set; }
        public virtual ICollection<Order> Orders { get; set; } = new List<Order>(); //koleksiyonun asla null olmamasını garanti eder.paymentStatus.
                                                                                    //Orders.Count dediğinde 0 döner, hata alınmaz.

    }


}

