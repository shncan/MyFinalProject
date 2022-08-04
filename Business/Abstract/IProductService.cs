using Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    // Burada diğer katmanları using edebilmemiz için yani kullanabilmemiz için Business 
    // üstünden add diyip reference'dan Entities ve DataAccess'i referanslamalıyız.

    //iş kurallarıın ve işlemlerin özelliklerinin belirlendiği katmandır business.
    public interface IProductService
    {
        List<Product> GetAll(); // tüm ürünleri listeyeleceğimiz yer.
    }
}
