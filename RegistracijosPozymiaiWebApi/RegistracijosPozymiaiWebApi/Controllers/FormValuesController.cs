using Microsoft.AspNetCore.Mvc;
using RegistracijosPozymiaiWebApi.Dtos;
using RegistracijosPozymiaiWebApi.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RegistracijosPozymiaiWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FormValuesController : ControllerBase
    {
        private readonly FormValuesService _formValuesService;

        public FormValuesController(FormValuesService formValuesService)
        {
            _formValuesService = formValuesService;
        }

        [HttpGet]
        public async Task<ActionResult<List<FormValuesDto>>> GetAll()
        {
            return Ok(await _formValuesService.GetAllDataAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<FormValuesDto>> Get(int id)
        {
            return Ok(await _formValuesService.GetByFormIdAsync(id));
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, FormValuesDto formDto)
        {
            await _formValuesService.UpdateAsync(id, formDto);
            return NoContent();
        }
    }
}
