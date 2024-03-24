using Emlak.BusinessLayer.Abstract;
using Emlak.EntityLayer.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Emlak.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = "Bearer")]
    public class SituationsController : ControllerBase
    {
        private readonly SituationService _situationService;

        public SituationsController(SituationService situationService)
        {
            _situationService = situationService;
        }

        [HttpGet]
        public IActionResult GetSituation()
        {
            var list = _situationService.TGetList();
            if (list != null)
            {
                return Ok(list);
            }
            return BadRequest();
        }

        [HttpGet("{id}")]
        public IActionResult GetSituation(int id)
        {
            var getSituation = _situationService.TGetByID(id);
            if (getSituation == null)
            {
                return BadRequest();
            }
            return Ok(getSituation);
        }

        [HttpPost]
        public IActionResult CreateSituation(Situation situation)
        {
            if (situation == null)
            {
                return BadRequest();
            }
            _situationService.TAdd(situation);
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteSituation(int id)
        {
            if (id == null)
            {
                return NotFound();
            }
            else
            {
                var delete = _situationService.TGetByID(id);
                _situationService.TDelete(delete);
                return Ok("Silme işlemi başarılı");
            }
        }

        [HttpPut]
        public IActionResult UpdateSituation(Situation situation)
        {
            _situationService.TUpdate(situation);
            return Ok("Güncelleme işlemi başarılı");

        }
    }
}
