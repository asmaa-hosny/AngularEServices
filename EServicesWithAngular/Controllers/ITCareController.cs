

using EServicesApplication.Interfaces.Infrastructure;
using EServicesApplication.Service.ITCare;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Linq;
using EServicesCommon.Common;
using System.Collections.Generic;

namespace EServicesWithAngular.Controllers
{
    public class ITCareController : BaseController
    {
        private readonly IITCareService _careService;


        public ITCareController(IITCareService careService)
        {
            _careService = careService;
        }

        [HttpGet("GetCategories")]
        public async Task<IActionResult> GetCategories()
        {
            var categories = await _careService.GetCategoriesAsync();
            return Ok(categories);
        }

        [HttpGet("{categoryId}/GetSubCategories")]
        public async Task<IActionResult> GetSubCategories(int categoryId)
        {
            var subCategories = await _careService.GetSubCategoriesAsync(categoryId);
            return Ok(subCategories);
        }

        [HttpGet("{subCategoryId}/GetCategorySubItems")]
        public async Task<IActionResult> GetCategorySubItems(int subCategoryId)
        {
            var items = await _careService.GetSubItemsAsync(subCategoryId);
            return Ok(items);
        }

        [HttpPost("PostRequest")]
        public async Task<ActionResult> PostRequest(ITCareRequestViewModel ViewModel)
        {
          
            var resObject = await _careService.AddNewRequestAsync(ViewModel.DomainModel,CurrentUserEmail);

            ViewModel.DomainModel.Id = resObject.Request.Id;

            if (ViewModel.Attachement != null && ViewModel.Attachement.Count() > 0 && ViewModel.Attachement.First() != null)
            {
                var responseAttachemnt = await _careService.PostFilesAsync(resObject.Request.Id, ViewModel.Attachement);
            }
            
            return Ok(resObject.Request.Id);
        }

        [HttpGet("{nodeId}/GetJsonFields")]
        public IActionResult GetJsonFields(short nodeId)
        {
            List<JsonFieldsDTO> fields = getObjectPropertiesWithMetadata(typeof(ITCareRequestViewModel), nodeId);
            return Ok(fields);
        }


    }
}
