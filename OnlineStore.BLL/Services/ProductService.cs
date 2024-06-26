﻿using AutoMapper;
using Microsoft.Extensions.Logging;
using OnlineStore.BLL.DTO;
using OnlineStore.BLL.MappConfigs.Interfaces;
using OnlineStore.BLL.Services.Interfaces;
using OnlineStore.DAL.Repositories.UnitOfWork;
using static OnlineStore.BLL.Exceptions.ValidationException;

namespace OnlineStore.BLL.Services
{
    public class ProductService : IProductService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IProductMapper _productMapper;
        private readonly IPaginationSettingsMapper _pagerMapper;
        private readonly ILogger<ProductService> _logger;
        public ProductService(
            IUnitOfWork unitOfWork,
            IMapper mapper,
            IProductMapper productMapper,
            IPaginationSettingsMapper pageMapper,
            ILogger<ProductService> logger)
        {
            _unitOfWork =unitOfWork;
            _mapper = mapper;
            _productMapper = productMapper;
            _pagerMapper = pageMapper;
            _logger = logger;
        }

        public async Task<CreateProductDTO> CreateProductAsync(CreateProductDTO newProduct, CancellationToken cancellationToken)
        {
            _logger.LogInformation("--> Product started added process!");
            
            var product = _productMapper.MapToEntity(newProduct);
            await _unitOfWork.Products.AddAsync(product, cancellationToken);
            _logger.LogInformation("--> Product added!");

            return newProduct;
            
        }

        public async Task<IEnumerable<ProductDTO>> GetProductsAsync(PaginationSettingsDTO paginationSettings, CancellationToken cancellationToken)
        {
            var paginationSettingsEntity = _pagerMapper.MapToEntity(paginationSettings);

            var products = await _unitOfWork.Products.GetAllAsync(paginationSettingsEntity, cancellationToken);

            return products.Select(product => _productMapper.MapToDTO(product));
        }

        public async Task<ProductDTO> GetProductByIdAsync(int? id, CancellationToken cancellationToken)
        {
            var product = await _unitOfWork.Products.GetByIdAsync(id.Value, cancellationToken);
            if (product == null)
            {
                throw new NotFoundException("No products with this id in database");
            }

            return _productMapper.MapToDTO(product);
        }

        public async Task<ProductDTO> GetProductByCategoryAsync(string categoryName, CancellationToken cancellationToken)
        {
            var product = await _unitOfWork.Products.FindProductByCategory(categoryName, cancellationToken);
            if (product == null)
            {
                throw new NotFoundException("No products in this category in database");
            }

            return _productMapper.MapToDTO(product);
        }

        public async Task<ProductDTO> UpdateProductAsync(ProductDTO productDTO, int id, CancellationToken cancellationToken)
        {
            _logger.LogInformation("--> Product started updated process!");

            var existingProduct = await _unitOfWork.Products.GetByIdAsync(id, cancellationToken);
            if (existingProduct == null)
            {
                throw new NotFoundException("No products with this id in database");
            }

            _productMapper.MapToEntity(productDTO, existingProduct);
            await _unitOfWork.Products.UpdateAsync(id, existingProduct, cancellationToken);
            _logger.LogInformation("--> Product updateed!");

            return productDTO;
        }

        public async Task<(bool, string)> DeleteProductAsync(int? id, CancellationToken cancellationToken)
        {
            _logger.LogInformation("--> Product started deleted process!");

            var product = await _unitOfWork.Products.GetByIdAsync(id.Value, cancellationToken);
            if (product == null)
            {
                throw new NotFoundException("No products with this id in database");
            }

            await _unitOfWork.Products.DeleteAsync(id.Value, cancellationToken);
            _logger.LogInformation("--> Product deleted!");

            return (true, "Product got deleted.");
        }
    }
}
