using Microsoft.AspNetCore.Mvc;
using Rest.Contracts.Repository;
using Rest.DTO;
using Rest.Entity;

namespace Rest.Controllers
{
    [ApiController]
    [Route("ngo")]
    public class NGOController : ControllerBase
    {
        private readonly INGORepository _ngoRepository;

        public NGOController(INGORepository ngoRepository)
        {
            _ngoRepository = ngoRepository;
        }

        [HttpPost]
        public async Task<IActionResult> Add(NGODTO ngo)
        {
            await _ngoRepository.Add(ngo);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Update(NGOEntity ngo)
        {
            await _ngoRepository.Update(ngo);
            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> Get(){
           return Ok(await _ngoRepository.Get());

        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await _ngoRepository.GetById(id));
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            await _ngoRepository.Delete(id);
            return Ok();
        }
    }
}
