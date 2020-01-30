using HarveyNichols.DTO.Common;
using HarveyNichols.DTO.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HarveyNichols.Service.Interface
{
    public interface IProductService
    {
        Response<bool> Create(ProductModel request);
        Response<ProductModel> Update(ProductModel request);
        Response<bool> Delete(int productId);
    }
}
