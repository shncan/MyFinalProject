using DataAccess.Abstract;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    //Inmemory'de yazılacak, bu kısım bir yöntemdir. Burada bellekte çalışacağız. Daha Sonra EntityFramework'te de çalışacağız.
    //Burada veri varmış gibi bir ortamı simule ediyoruz.
    public class InMemoryProductDal : IProductDal
    {
        List<Product> _products; //(naming convention)Bu class için global değilen//Burası bu class için globaldir.metodların dışında class'ın içinde. isimlendirmesi ise evrensel olarak _ ile başlayarak isimlendiriyoruz.

        public InMemoryProductDal() //burası bize bellekte veri oluşturdu, sanki bir veritabanıymış gibi simule ettik.
        {
            _products = new List<Product> {
                new Product{ProductId=1, CategoryId=1, ProductName="Bardak",UnitPrice=15,UnitInStock=15},
                new Product{ProductId=2, CategoryId=1, ProductName="Kamera",UnitPrice=500,UnitInStock=3},
                new Product{ProductId=3, CategoryId=2, ProductName="Telefon",UnitPrice=1500,UnitInStock=2},
                new Product{ProductId=4, CategoryId=2, ProductName="Klavye",UnitPrice=150,UnitInStock=65},
                new Product{ProductId=5, CategoryId=2, ProductName="Fare",UnitPrice=85,UnitInStock=1}

            };
            
        }

        public void Add(Product product)
        {
            _products.Add(product); //biz burada 
        }

        public void Delete(Product product)
        {
            // _products.Remove(product); bu kod çalışmaz çünkü bizim geçici oluşturduğumuz veriler süslü parantez içinde tanımladık. normal bir veritabanında çalışırdı.
            // buradaki referans mantığıyla çalışmasından dolayı silemeyiz.

            //Product productToDelete = null;
            //foreach (var p in _products)
            //{
            //    if (product.ProductId==p.ProductId)
            //    {
            //        productToDelete = p;
            //    }
            //}
                Product productToDelete = _products.SingleOrDefault(p=>p.ProductId==product.ProductId); //sinordef tek bir eleman bulmaya yarar, linq çağırmak gerekir.
                //biz yukarda foreach'te yaptığımızı tek satırda linq sorgusu ile yaptık. Daha kullanışlı ve daha performanslı.
                //linq'i using yapmazsak bu yapıyı kullanamayız, onu da singordef'in üstünden ampulle çağırabiliriz.
                _products.Remove(productToDelete);
            

        }

        public List<Product> GetAll()
        {
            return _products;
        }

        public List<Product> GetAllByCategory(int categoryId)
        {
           return _products.Where(p => p.CategoryId == categoryId).ToList(); //where koşulu içinde gerçekleşen ve koşula uyan bütün durumları yeni bir liste halinde döndürür.
        }

        public void Update(Product product)
        {
            //gönderdiğimiz ürün id'sine sahip olan liste ürünü bul demek.
            Product productToUpdate = _products.SingleOrDefault(p => p.ProductId == product.ProductId);
            //mantık olarak delete ile aynı, 
            productToUpdate.ProductName = product.ProductName;
            productToUpdate.CategoryId = product.CategoryId;
            productToUpdate.UnitPrice = product.UnitPrice;
            productToUpdate.UnitInStock = product.UnitInStock;
        }
    }
}
