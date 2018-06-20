using Abp.Web.Mvc.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TaawonMVC.Buildings;
using TaawonMVC.Buildings.DTO;
using TaawonMVC.BuildingType;
using TaawonMVC.BuildingType.DTO;
using TaawonMVC.Web.Models.Building;
using TaawonMVC.Models;
using TaawonMVC.Neighborhood;
using TaawonMVC.Neighborhood.DTO;

namespace TaawonMVC.Web.Controllers
{
    public class BuildingController : AbpController
    {
        private readonly IBuildingsAppService _buildingsAppService;
        private readonly IBuildingTypeAppService _buildingTypeAppService;
        private readonly INeighborhoodAppService _neighborhoodAppService;
        public BuildingController(IBuildingsAppService buildingsAppService, IBuildingTypeAppService buildingTypeAppService, INeighborhoodAppService neighborhoodAppService)
        {
            _buildingsAppService = buildingsAppService;
            _buildingTypeAppService = buildingTypeAppService;
            _neighborhoodAppService = neighborhoodAppService;

        }
        // GET: Building
        public ActionResult Index()
        {
            var getBuildingOutput = _buildingsAppService.getAllBuildings();
            // if neighborhood or buildingtype is deleted 
            // initiate the object with default values .
            foreach(var Building  in getBuildingOutput)
            {
                if(Building.BuildingType==null)
                {
                    Building.BuildingType = new TaawonMVC.Models.BuildingType();
                }
                if(Building.NeighboorHood==null)
                {
                    Building.NeighboorHood = new TaawonMVC.Models.Neighborhood();
                }

            }
            //get the list of buildingTypes
            var buildingTypes = _buildingTypeAppService.getAllBuildingtype().ToList();
            // get the list of neighborhoods

            var neighborhoods = _neighborhoodAppService.GetAllNeighborhood().ToList();

            //var BuildingTypeInput = new GetBuidlingTypeInput
            //{
            //    Id = id
            //};
            //var buildingType = _buildingTypeAppService.getBuildingTypeById(BuildingTypeInput);
            var BuildingsViewModel = new BuildingViewModel
            {
                Buildings = getBuildingOutput,
                BuildingTypes = buildingTypes,
                Neighborhoods=neighborhoods,
                Building = new GetBuildingsOutput(),
               
                
                  


            };
            return View("Index",BuildingsViewModel);
        }


        public ActionResult EditBuildingModal(int userId)
        {
            //get the list of buildingTypes
            var buildingTypes = _buildingTypeAppService.getAllBuildingtype().ToList();
            // get the list of neighborhoods
            var neighborhoods = _neighborhoodAppService.GetAllNeighborhood().ToList();

            var getBuidlingsInput = new GetBuidlingsInput
            {
                Id = userId
            };

            var getBuildingOutput = _buildingsAppService.getBuildingsById(getBuidlingsInput);

            var BuildingViewModel = new BuildingViewModel
            {
               Building = getBuildingOutput,
               BuildingTypes=buildingTypes,
               Neighborhoods=neighborhoods
               
            };

            return View("_EditUserModal", BuildingViewModel);

        }
    }
}