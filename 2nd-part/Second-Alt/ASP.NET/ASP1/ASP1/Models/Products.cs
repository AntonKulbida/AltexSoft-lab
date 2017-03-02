using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using Serialization;

namespace ASP1.Models
{
    public class Products
    {
        private List<Product> _allProducts;

        Serializer<List<Product>> _serializer;

        public void Add(Product product)
        {
            product.id = _allProducts.Max(x => x.id) + 1;
            _allProducts.Add(product);
        }
        public List<Product> GetProducts()
        {
            return _allProducts;
        }

        public void Serialize()
        {
            _serializer.Serialize(_allProducts);
        }
        public Products()
        {
            _serializer = new Serializer<List<Product>>(WebConfigurationManager.AppSettings["PathToXML"]);
            _allProducts = new List<Product>();
            _allProducts = _serializer.Deserialize();
        }
    }
}