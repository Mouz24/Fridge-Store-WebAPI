using AutoMapper;
using Contracts;
using Dapper;
using DocumentFormat.OpenXml.Office2013.Word;
using Entities;
using Entities.DataTransferObjects;
using Entities.Models;
using FakeItEasy;
using FluentAssertions;
using FridgeProducts;
using FridgeProducts.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Moq;
using Repository;
using Services.IServices;
using System.Data;

namespace WebApiTests
{
    public class FridgeControllerTest
    {
        private readonly IServiceManager _service;
        private readonly IMapper _mapper;
        private readonly ILoggerManager _logger;
        private readonly DbContextOptions<RepositoryContext> _options;
        private readonly IConfiguration _configuration;
        
        public FridgeControllerTest()
        {
            _service = A.Fake<IServiceManager>();
            _mapper = A.Fake<IMapper>();
            _logger = A.Fake<ILoggerManager>();
            _options = A.Fake<DbContextOptions<RepositoryContext>>();
            _configuration = A.Fake<IConfiguration>();
        }

        [Fact]
        public void Get_WhenCalled_ReturnsOkResult()
        {
            //Arrange
            var controller = new FridgeController(_service, _logger, _mapper, _options);
            
            // Act
            var result = controller.GetFridges();
            
            // Assert
            result.Should().NotBeNull();
            result.Should().BeOfType(typeof(OkObjectResult));
        }

        [Fact]
        public void Get_WhenCalled_ReturnsCorrectProcedureImplementation()
        {
            //Arrange
            var controller = new FridgeController(_service, _logger, _mapper, _options);
            var fridgeproducts = A.Fake<IEnumerable<fridge_products>>();
            var fridgeproductsDTO = A.Fake<IEnumerable<FridgeProductsDTO>>();
            A.CallTo(() => _mapper.Map<IEnumerable<FridgeProductsDTO>>(fridgeproducts)).Returns(fridgeproductsDTO);

            // Act
            var result = controller.SetQuantity();

            // Assert
            result.Should().NotBeNull();
            result.Should().BeOfType(typeof(Task<IEnumerable<FridgeProductsDTO>>));
        }

        [Fact]
        public void Create_WhenCalled_ReturnsCreatedAtRoute()
        {
            //Arrange
            var fridgeForAddingDTO = A.Fake<FridgeForAddingDTO>();
            var fridge = A.Fake<fridge>();
            var model = A.Fake<fridge_model>();
            var checkfridge = A.Fake<fridge>();
            var checkfridgebyname = A.Fake<fridge_model>();
            var controller = new FridgeController(_service, _logger, _mapper, _options);
            A.CallTo(() => _mapper.Map<fridge>(fridgeForAddingDTO)).Returns(fridge);
            A.CallTo(() => _mapper.Map<fridge_model>(fridgeForAddingDTO)).Returns(model);
            A.CallTo(() => _service.Model.FindDublicateFridge(fridgeForAddingDTO, false)).Returns(checkfridgebyname);
            A.CallTo(() => _service.Fridge.FindDublicateFridgeByName(fridgeForAddingDTO, false)).Returns(checkfridge);

            //Act
            var result = controller.AddFridge(fridgeForAddingDTO);
            A.CallTo(() => _service.Fridge.AddFridge(fridge)).MustHaveHappened();
            A.CallTo(() => _service.Save()).MustHaveHappened();
            
            //Assert
            result.Should().NotBeNull();
            result.Should().BeOfType(typeof(CreatedAtRouteResult));
        }

        [Fact]
        public void RemoveFridge_WhenCalled_ReturnsNoContentResult()
        {
            //Arrange
            var controller = new FridgeController(_service, _logger, _mapper, _options);
            var fridgeId = new Guid("36b5e304-6b86-4097-9af6-3fe7792b02e1");
            var fridge = A.Fake<fridge>();
            var model = A.Fake<fridge_model>();
            A.CallTo(() => _service.Fridge.GetFridge(fridgeId, false)).Returns(fridge);
            A.CallTo(() => _service.Model.GetModel(fridge.ModelId, false)).Returns(model);

            //Act
            var result = controller.DeleteFridge(fridgeId);
            A.CallTo(() => _service.Fridge.DeleteFridge(fridge)).MustHaveHappened();
            A.CallTo(() => _service.Save()).MustHaveHappened();

            //Assert
            result.Should().NotBeNull();
            result.Should().BeOfType(typeof(NoContentResult));
        }

        [Fact]
        public void UpdateFridge_WhenCalles_ReturnsNoContentResult()
        {
            //Arrange
            var fridgeId = new Guid("36b5e304-6b86-4097-9af6-3fe7792b02e1");
            var fridge = A.Fake<fridge>();
            var model = A.Fake<fridge_model>();
            var controller = new FridgeController(_service, _logger, _mapper, _options);
            var fridgeForUpdateDTO = A.Fake<FridgeForUpdateDTO>();
            A.CallTo(() => _service.Fridge.GetFridge(fridgeId, true)).Returns(fridge);
            A.CallTo(() => _service.Model.GetModel(fridge.ModelId, true)).Returns(model);

            //Act
            var result = controller.UpdateFridge(fridgeId, fridgeForUpdateDTO);
            A.CallTo(() => _mapper.Map(fridgeForUpdateDTO, fridge)).MustHaveHappened();
            A.CallTo(() => _service.Save()).MustHaveHappened();

            //Assert
            result.Should().NotBeNull();
            result.Should().BeOfType(typeof(NoContentResult));
        }
    }
}