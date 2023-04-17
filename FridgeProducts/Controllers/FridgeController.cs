using AutoMapper;
using Contracts;
using Dapper;
using Entities;
using Entities.DataTransferObjects;
using Entities.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Services.IServices;
using System;
using System.Data;
using System.Linq;

namespace FridgeProducts.Controllers
{
    [Route("api/fridge")]
    [ApiController]
    public class FridgeController : ControllerBase
    {
        private readonly IServiceManager _service;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;
        private readonly DbContextOptions _options;

        public FridgeController(IServiceManager service, ILoggerManager logger, IMapper mapper, DbContextOptions options)
        {
            _service = service;
            _logger = logger;
            _mapper = mapper;
            _options = options;
        }

        [HttpGet(Name = "GetFridges"), Authorize(Roles = "User, Administrator")]
        public IActionResult GetFridges()
        {
            RepositoryContext RepositoryContext = new RepositoryContext(_options);

            var fridgeswithmodels = RepositoryContext.fridge.Include(u => u.FridgeModel).ToList();
                
            return Ok(fridgeswithmodels);
        }

        [HttpGet("productswithzeroquantity"), Authorize(Roles = "Administrator")]
        public async Task<IEnumerable<FridgeProductsDTO>> SetQuantity()
        {
            var products = await _service.Fridge.ImplementStoredProcedureAsync();

            var productsDTO = _mapper.Map<IEnumerable<FridgeProductsDTO>>(products);
                
            return productsDTO;
        }

        [HttpPost(Name = "AddFridge"), Authorize(Roles = "Administrator")]
        public IActionResult AddFridge([FromBody] FridgeForAddingDTO Fridge)
        {
            if (!ModelState.IsValid)
            {
                _logger.LogError("Invalid model state for the FridgeForAddingDTO object");
                
                return UnprocessableEntity(ModelState);
            }

            if (Fridge == null)
            {
                _logger.LogError("FridgeDTO object sent from client is null.");

                return BadRequest("FridgeDTO object is null");
            }

            var FridgeEntity = _mapper.Map<fridge>(Fridge);

            var modelEntity = _mapper.Map<fridge_model>(Fridge);

            var CheckFridgeforRepeatByName = _service.Fridge.FindDublicateFridgeByName(Fridge, trackChanges: false);

            var CheckFridgeForRepeat = _service.Model.FindDublicateFridge(Fridge, trackChanges: false);
            if (CheckFridgeForRepeat != null && CheckFridgeforRepeatByName != null)
            {
                _service.Fridge.AddFridge(FridgeEntity);

                FridgeEntity.ModelId = CheckFridgeForRepeat.Id;
            }
            else
            {
                _service.Fridge.AddFridge(FridgeEntity);
                _service.Model.AddModel(modelEntity);

                FridgeEntity.ModelId = modelEntity.Id;
            }
            
            _service.Save();

            return CreatedAtRoute("AddFridge", modelEntity);
        }

        [HttpDelete("{fridgeId}", Name = "DeleteFridge"), Authorize(Roles = "Administrator")]
        public IActionResult DeleteFridge(Guid fridgeId)
        {
            var fridge = _service.Fridge.GetFridge(fridgeId, trackChanges: false);
            if (fridge == null)
            {
                _logger.LogInfo($"Fridge with id: {fridgeId} doesn't exist in the database.");
                
                return NotFound();
            }

            var model = _service.Model.GetModel(fridge.ModelId, trackChanges : false);

            _service.Fridge.DeleteFridge(fridge);
            _service.Save();

            var modelCheck = _service.Fridge.OtherFridgesOfThisModel(model.Id, trackChanges : false);
            if (modelCheck == null)
            {
                _service.Model.DeleteModel(model);
                _service.Save();
            }

            return NoContent();
        }

        [HttpPut("{fridgeId}", Name = "UpdateFridge"), Authorize(Roles = "Administrator")]
        public IActionResult UpdateFridge(Guid fridgeId, [FromBody]FridgeForUpdateDTO fridgeForUpdate)
        {
            if (!ModelState.IsValid)
            {
                _logger.LogError("Invalid model state for the FridgeForUpdateDTO object");
                return UnprocessableEntity(ModelState);
            }

            if (fridgeForUpdate== null)
            {
                _logger.LogError("FridgeForUpdateDTO object sent from client is null.");
                return BadRequest("FridgeForUpdateDTO object is null");
            }

            var fridge = _service.Fridge.GetFridge(fridgeId, trackChanges: true);
            if (fridge == null)
            {
                _logger.LogInfo($"Fridge with id: {fridgeId} doesn't exist in the database.");
                return NotFound("Such fridge does not exist");
            }

            var model = _service.Model.GetModel(fridge.ModelId, trackChanges: true);
            
            model.NameOfModel = fridgeForUpdate.NameOfModel;
            model.Year = fridgeForUpdate.Year;

            _mapper.Map(fridgeForUpdate, fridge);
            _service.Save();

            return NoContent();
        }
    }
}
