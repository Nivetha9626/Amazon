
using Amazon.Dto;
using System.Collections.Generic;

namespace Amazon.Interface
{
    public interface IProductService
    {
        //dont use any accessmodifier public,private etc

        IEnumerable<ProductDto> GetProducts();
        ProductDto GetProduct(string id);
        ProductDto SaveProduct(ProductDto productDto);
        void DeleteProduct(string id);
    }
}