using AutoMapper;
using Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FakeItEasy;
using FridgeProducts;
using Microsoft.EntityFrameworkCore;
using Entities.Models;
using Entities.DataTransferObjects;
using FridgeProducts.Controllers;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;
using Services.IServices;
using Entities;

namespace WebApiTests
{
    public class FridgeProdcutsControllerTests
    {
        private readonly IServiceManager _service;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;
        private readonly DbContextOptions<RepositoryContext> _options;

        public FridgeProdcutsControllerTests()
        {
            _service = A.Fake<IServiceManager>();
            _mapper = A.Fake<IMapper>();
            _logger = A.Fake<ILoggerManager>();
            _options = A.Fake<DbContextOptions<RepositoryContext>>();
        }

        [Fact]
        public void GetProducts_WhenCalled_ReturnsOkResult()
        {
            //Arrange
            var controller = new FridgeProductsController(_service, _logger, _mapper, _options);
            var fridgeId = new Guid("36b5e304-6b86-4097-9af6-3fe7792b02e1");

            //Act
            var result = controller.GetFridgeProducts(fridgeId);
           
            //Assert
            result.Should().NotBeNull();
            result.Should().BeOfType(typeof(OkObjectResult));
        }

        [Fact]
        public void AddProduct_WhenCalled_ReturnsCreatedAtRouteResult()
        {
            //Arrange
            var fridgeId = new Guid("36b5e304-6b86-4097-9af6-3fe7792b02e1");
            var product = A.Fake<ProductsForAddingDTO>();
            var fridge = A.Fake<IEnumerable<fridge>>();
            var fridgeDTO = A.Fake<FridgeDTO>();
            var products = A.Fake<fridge_products>();
            var productEntity = A.Fake<products>();
            var checkproduct = A.Fake<products>();
            var controller = new FridgeProductsController(_service, _logger, _mapper, _options);
            A.CallTo(() => _mapper.Map<FridgeDTO>(fridge)).Returns(fridgeDTO);
            A.CallTo(() => _mapper.Map<products>(product)).Returns(productEntity);
            A.CallTo(() => _mapper.Map<fridge_products>(product)).Returns(products);
            A.CallTo(() => _service.Products.FindDublicate(product, false)).Returns(checkproduct);
            
            //Act
            var result = controller.AddProduct(fridgeId, product);
            A.CallTo(() => _service.Fridge_Products.PutProductinFridge(fridgeId, products, productEntity, product)).MustHaveHappened();

            //Assert
            result.Should().NotBeNull();
            result.Should().BeOfType(typeof(CreatedAtRouteResult));
        }

        [Fact]
        public void RemoveProduct_WnenCalled_ReturnsNoContentResult()
        {
            //Arrange
            var fridgeId = new Guid("36b5e304-6b86-4097-9af6-3fe7792b02e1");
            var productId = new Guid("d5605993-f8e9-4a04-bd17-00405cc9c9c0");
            var fridge = A.Fake<IEnumerable<fridge>>();
            var fridgeDTO = A.Fake<FridgeDTO>();
            var ProductsInFridge = A.Fake<fridge_products>();
            var ProductInOtherFridges = A.Fake<fridge_products>();
            var ProductToDelete = A.Fake<products>();
            var controller = new FridgeProductsController(_service, _logger, _mapper, _options);
            A.CallTo(() => _service.Fridge.GetFridgeById(fridgeId, false)).Returns(fridge);
            A.CallTo(() => _mapper.Map<FridgeDTO>(fridge)).Returns(fridgeDTO);
            A.CallTo(() => _service.Fridge_Products.GetProductInFridge(fridgeId, productId, false)).Returns(ProductsInFridge);
            
            //Act
            var result = controller.DeleteProductFromFridge(fridgeId, productId);
            A.CallTo(() => _service.Fridge_Products.RemoveProductFromFridge(ProductsInFridge)).MustHaveHappened();
            A.CallTo(() => _service.Save()).MustHaveHappened();

            //Assert
            result.Should().NotBeNull();
            result.Should().BeOfType(typeof(NoContentResult));
        }

        [Fact]
        public void UpdateProduct_WhenCalled_ReturnsNoContentResult()
        {
            //Arrange
            var fridgeId = new Guid("36b5e304-6b86-4097-9af6-3fe7792b02e1");
            var productId = new Guid("d5605993-f8e9-4a04-bd17-00405cc9c9c0");
            var fridge = A.Fake<IEnumerable<fridge>>();
            var fridgeDTO = A.Fake<FridgeDTO>();
            var ProductInFridge = A.Fake<fridge_products>();
            var ProductToUpdate = A.Fake<products>();
            var product = A.Fake<ProductsForUpdateDTO>();
            var controller = new FridgeProductsController(_service, _logger, _mapper, _options);
            A.CallTo(() => _mapper.Map<FridgeDTO>(fridge)).Returns(fridgeDTO);
            A.CallTo(() => _service.Fridge_Products.GetProductInFridge(fridgeId, productId, true)).Returns(ProductInFridge);
            A.CallTo(() => _service.Products.GetProduct(productId, true)).Returns(ProductToUpdate);

            //Act
            var result = controller.UpdateProduct(fridgeId, productId, product);
            A.CallTo(() => _mapper.Map(product, ProductToUpdate)).MustHaveHappened();
            A.CallTo(() => _service.Save()).MustHaveHappened();

            //Assert
            result.Should().NotBeNull();
            result.Should().BeOfType(typeof(NoContentResult));
        }
    }
}
