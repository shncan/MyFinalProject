using Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Abstract
{
    public interface IProductDal
    {
        List<Product> GetAll(); //listenin ürünlerini listememizi sağlayacak. altı kırmızı olmasının sebebi referansı olmaması. ya üstüne ampulden ekleyebiliriz
        // ya da dataaccess'in üstüne sağ tıklayıp add diyip oradan reference'yi seçip entities'i de seçebiliriz.
        void Add(Product product);
        void Update(Product product);
        void Delete(Product product);

        List<Product> GetAllByCategory(int categoryId); // bu bize ürünleri categoryid'sine göre listeyen bir method çağırır.

        //INTERFACE'IN METODLARI DEFAULTTA PUBLIC'TIR. ANCAK INTERFACE'IN KENDISI PUBLIC DEGILDIR.
    }
}
