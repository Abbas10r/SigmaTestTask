using Microsoft.AspNetCore.Mvc;
using SigmaTestTask.Helpers;
using SigmaTestTask.Models;
using SigmaTestTask.Services.Interfaces;

namespace SigmaTestTask.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CandidateController : ControllerBase
    {
        private readonly ICandidateService _candidateService;

        public CandidateController(ICandidateService candidateService)
        {
            _candidateService = candidateService;
        }

        [HttpPost("CreateOrUpdate")]
        public async Task<IActionResult> CreateOrUpdate(CandidateDTO candidateDto, CancellationToken cancellationToken)
        {
            var candidate = Mapper.Map(candidateDto);
            var result = await _candidateService.CreateOrUpdateCandidateAsync(candidate, cancellationToken);
            return Ok(result);
        }
    }
}
