using Microsoft.AspNetCore.Mvc;
using RegistracijosPozymiaiWebApi.Dtos;
using RegistracijosPozymiaiWebApi.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RegistracijosPozymiaiWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeaturesController : ControllerBase
    {
        private readonly FeaturesService _featuresService;

        public FeaturesController(FeaturesService featuresService)
        {
            _featuresService = featuresService;
        }

        [HttpGet]
        public async Task<ActionResult<List<FeatureDto>>> GetAll()
        {
            return Ok(await _featuresService.GetAllAsync());
        }
    }
}
