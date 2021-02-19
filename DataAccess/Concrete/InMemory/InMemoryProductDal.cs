using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryProductDal : IProductDal
    {
        List<Product> _products;
        public InMemoryProductDal()
        {
            //Oracle, Sql Server, Postgres, MongoDb
            _products = new List<Product> {
                new Product{ProductId = 1, CategoryId = 1, ProductName = "Cup", UnitPrice=15, UnitInStock = 60},
                new Product{ProductId = 2, CategoryId = 1, ProductName = "Camera", UnitPrice = 500, UnitInStock = 20},
                new Product{ProductId = 3, CategoryId = 2, ProductName = "Book", UnitPrice = 15, UnitInStock = 30},
                new Product{ProductId = 4, CategoryId = 1, ProductName = "Computer", UnitPrice = 500, UnitInStock = 10},
                new Product{ProductId = 5, CategoryId = 2, ProductName = "Lamp", UnitPrice=40, UnitInStock = 20},
                new Product{ProductId = 6, CategoryId = 2, ProductName = "Keyboard", UnitPrice=150, UnitInStock=35}
            };
        }
        public void Add(Product product)
        {
            _products.Add(product);
        }

        public void Delete(Product product)
        {
            //LINQ - Language Integrated Query (Lambda)
            Product productToDelete = _products.SingleOrDefault(p => p.ProductId == product.ProductId);

            _products.Remove(productToDelete);
        }

        public List<Product> GetAll()
        {
            return _products;
        }

        public List<Product> GetAllByCategory(int categoryId)
        {
            return _products.Where(p => p.CategoryId == categoryId).ToList();
        }

        public void Update(Product product)
        {
            //baska bir product gondermedik cunku olan urunu yeni girilen degerlerle degistirdik. id'ler ayni
            Product productToUpdate = _products.SingleOrDefault(p => p.ProductId == product.ProductId);
            productToUpdate.ProductName = product.ProductName;
            productToUpdate.CategoryId = product.CategoryId;
            productToUpdate.UnitPrice = product.UnitPrice;
            productToUpdate.UnitInStock = product.UnitInStock;
        }
    }
}
