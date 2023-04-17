using AutoMapper;
using Contracts;
using Entities.DataTransferObjects;
using Entities.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.Design;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using Microsoft.EntityFrameworkCore.Query.Internal;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Data.SqlClient;
using System.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authorization.Infrastructure;
using Dapper;
using Services.IServices;
using Entities;
using Microsoft.EntityFrameworkCore;

namespace FridgeProducts.Controllers
{
    [Route("api/fridge/{fridgeId}/products")]
    [ApiController]
    public class FridgeProductsController : ControllerBase
    {
        private readonly IServiceManager _service;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;
        private readonly DbContextOptions _options;

        public FridgeProductsController(IServiceManager service, ILoggerManager logger, IMapper mapper, DbContextOptions options)
        {
            _service = service;
            _logger = logger;
            _mapper = mapper;
            _options = options;
        }

        [HttpGet(Name = "GetFridgeProducts"), Authorize(Roles = "User, Administrator")]
        public IActionResult GetFridgeProducts(Guid fridgeid)
        {
            RepositoryContext RepositoryContext = new RepositoryContext(_options);

            var fridgedescription = RepositoryContext.fridge_products.Include(u => u.fridge).
            Include(u => u.products).Where(u => u.FridgeId.Equals(fridgeid)).ToList();

            return Ok(fridgedescription);
        }

        [HttpPost(Name = "AddProduct"), Authorize(Roles = "User, Administrator")]
        public IActionResult AddProduct(Guid fridgeId, [FromBody]ProductsForAddingDTO Product)
        {
            if (!ModelState.IsValid)
            {
                _logger.LogError("Invalid model state for the ProductsForAddingDTO object");
                return UnprocessableEntity(ModelState);
            }

            if (Product == null)
            {
                _logger.LogError("ProductsForAddingDTO object sent from client is null.");
                return BadRequest("ProductsForAddingDTO object is null");
            }

            var fridge = _service.Fridge.GetFridgeById(fridgeId, trackChanges: false);
            
            var fridgeDTO = _mapper.Map<FridgeDTO>(fridge);
            if (_service.Fridge_Products.FridgeDTOIsEmpty(fridgeDTO) && !fridge.Any())
            {
                _logger.LogInfo($"Fridge with id: {fridgeId} doesn't exist in the database.");
                return NotFound("Such fridge does not exist");
            }
            
            var productEntity = _mapper.Map<products>(Product);
            
            var products = _mapper.Map<fridge_products>(Product);

            var checkproductforrepeat = _service.Products.FindDublicate(Product, trackChanges: false);
            if (checkproductforrepeat == null)
            {
                _service.Products.AddProduct(fridgeId, productEntity);
                _service.Fridge_Products.PutProductinFridge(fridgeId, products, productEntity, Product);
            }
            else
            {
                _service.Fridge_Products.PutProductinFridge(fridgeId, products, productEntity, Product);
                products.ProductId = checkproductforrepeat.Id;
                productEntity.Id = checkproductforrepeat.Id;
            }
            
            _service.Save();

            return CreatedAtRoute("AddProduct", productEntity);
        }

        [HttpDelete("{Id}", Name = "DeleteProductFromFridge"), Authorize(Roles = "User, Administrator")]
        public IActionResult DeleteProductFromFridge(Guid fridgeId, Guid Id)
        {
            var fridge = _service.Fridge.GetFridgeById(fridgeId, trackChanges: false);
            
            var fridgeDTO = _mapper.Map<FridgeDTO>(fridge);
            if (_service.Fridge_Products.FridgeDTOIsEmpty(fridgeDTO) && !fridge.Any())
            {
                _logger.LogInfo($"Fridge with id: {fridgeId} doesn't exist in the database.");
                return NotFound("Such fridge does not exist");
            }

            var ProductInFridge = _service.Fridge_Products.GetProductInFridge(fridgeId, Id, trackChanges: false);
            if (ProductInFridge == null)
            {
                _logger.LogInfo($"Product with id: {Id} doesn't exist in the fridge.");
                return NotFound("Such product does not exist");
            }

            _service.Fridge_Products.RemoveProductFromFridge(ProductInFridge);
            _service.Save();

            var ProductInOtherFridges = _service.Fridge_Products.GetProductInAllFridges(Id, trackChanges: false);
            if (ProductInOtherFridges == null)
            {   
                var ProductToDelete = _service.Products.GetProduct(Id, trackChanges : false);
                
                _service.Products.DeleteProduct(ProductToDelete);
                _service.Save();
            }

            return NoContent();
        }

        [HttpPut("{Id}", Name = "UpdateProduct"), Authorize(Roles = "Administrator")]
        public IActionResult UpdateProduct(Guid fridgeId, Guid Id, [FromBody]ProductsForUpdateDTO product)
        {
            if (!ModelState.IsValid)
            {
                _logger.LogError("Invalid model state for the ProductsForAddingDTO object");
                return UnprocessableEntity(ModelState);
            }

            if (product == null)
            {
                _logger.LogError("ProductsForUpdateDTO object sent from client is null.");
                return BadRequest("ProductsForUpdateDTO object is null");
            }

            var fridge = _service.Fridge.GetFridgeById(fridgeId, trackChanges: false);
            
            var fridgeDTO = _mapper.Map<FridgeDTO>(fridge);
            if (_service.Fridge_Products.FridgeDTOIsEmpty(fridgeDTO) && !fridge.Any())
            {
                _logger.LogInfo($"Fridge with id: {fridgeId} doesn't exist in the database.");
                return NotFound("Such fridge does not exist");
            }

            var ProductInFridge = _service.Fridge_Products.GetProductInFridge(fridgeId, Id, trackChanges: true);
            if (ProductInFridge == null)
            {
                _logger.LogInfo($"Product with id: {Id} doesn't exist in the fridge.");
                return NotFound("Such product does not exist");
            }

            ProductInFridge.Quantity = product.Quantity;

            var ProductToUpdate = _service.Products.GetProduct(Id, trackChanges: true);
            if (ProductToUpdate == null)
            {
                _logger.LogInfo($"Product with id: {Id} doesn't exist in the database.");
                return NotFound("Such product does not exist");
            }

            _mapper.Map(product, ProductToUpdate);
            _service.Save();

            return NoContent();
        }
    }
}
