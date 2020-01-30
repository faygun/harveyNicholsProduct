using HarveyNichols.Data.Entity;
using HarveyNichols.Data.Repository;
using HarveyNichols.DTO.Common;
using HarveyNichols.DTO.Product;
using HarveyNichols.Service.Interface;
using System;

namespace HarveyNichols.Service
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _repository;
        public ProductService(IProductRepository productRepository)
        {
            _repository = productRepository;
        }
        public Response<bool> Create(ProductModel request)
        {
            try
            {
                _repository.Add(new Product
                {
                    Colour = request.Colour,
                    CreatedAt = DateTime.Now,
                    IsDeleted = false,
                    ModifiedAt = DateTime.Now,
                    Price = request.Price,
                    Sku = request.Sku,
                    Stock = request.Stock,
                    Style = request.Style,
                    Title = request.Title
                });

                return new Response<bool>
                {
                    Result = true,
                    Success = true
                };
            }
            catch (Exception ex)
            {
                return new Response<bool>
                {
                    Result = false,
                    Success = false,
                    Exception = ex,
                    Message = ex.Message // or custom message
                };
            }
        }

        public Response<bool> Delete(int productId)
        {
            try
            {
                _repository.Remove(productId);
                return new Response<bool>
                {
                    Result = true,
                    Success = true,
                };
            }
            catch (Exception ex)
            {
                return new Response<bool>
                {
                    Result = false,
                    Success = false,
                    Exception = ex,
                    Message = ex.Message // or custom message
                };
            }

        }
        public Response<ProductModel> Update(ProductModel request)
        {
            try
            {
                _repository.Update(new Product
                {
                    ProductId = request.ProductId,
                    Colour = request.Colour,
                    CreatedAt = request.CreatedAt,
                    IsDeleted = false,
                    ModifiedAt = request.ModifiedAt,
                    Price = request.Price,
                    Sku = request.Sku,
                    Stock = request.Stock,
                    Style = request.Style,
                    Title = request.Title
                });

                return new Response<ProductModel>
                {
                    Result = request,
                    Success = true,
                };
            }
            catch (Exception ex)
            {
                return new Response<ProductModel>
                {
                    Result = null,
                    Success = false,
                    Exception = ex,
                    Message = ex.Message // or custom message
                };
            }
        }
    }
}
