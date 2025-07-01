using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.Entity.Enums
{
    public enum BasketStatus
    {
        NotFound= 0, //Kulanıcnın aktif sepeti yok
        Empty = 1, //Sepet boş
        HasItems=2, //Sepet ve ürünler var

    }
  
}
