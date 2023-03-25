using Amazon.Dto;
using Amazon.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amazon.Service
{
    public class ProductService : IProductService
    {
        public void DeleteProduct(string id)
        {
            throw new NotImplementedException();
        }

        public ProductDto GetProduct(string id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ProductDto> GetProducts()
        {
            throw new NotImplementedException();
        }

        public ProductDto SaveProduct(ProductDto productDto)
        {
            throw new NotImplementedException();
        }
    }
}
