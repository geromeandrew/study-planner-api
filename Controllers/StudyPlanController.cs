using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudyPlannerAPI.Models;
using StudyPlannerAPI.Services;

namespace StudyPlannerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudyPlanController : ControllerBase
    {

        private readonly IStudyPlanService _studyPlanService;
        public StudyPlanController(IStudyPlanService studyPlanService)
        {
            _studyPlanService = studyPlanService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<StudyPlan>>> GetAllStudyPlans()
        {
            try
            {
                var studyPlans = await _studyPlanService.GetAllStudyPlansAsync();
                return Ok(studyPlans);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<StudyPlan>> GetStudyPlanById(int id)
        {
            try
            {
                var studyPlan = await _studyPlanService.GetStudyPlanByIdAsync(id);
                return Ok(studyPlan);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult<StudyPlan>> CreateStudyPlan(StudyPlan studyPlan)
        {
            try
            {
                var result = await _studyPlanService.CreateStudyPlanAsync(studyPlan);
                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut]
        public async Task<ActionResult<StudyPlan>> UpdateStudyPlan(StudyPlan studyPlan)
        {
            try
            {
                var result = await _studyPlanService.UpdateStudyPlanAsync(studyPlan);
                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<String>> DeleteStudyPlan(int id)
        {
            try
            {
                var result = await _studyPlanService.DeleteStudyPlanAsync(id);
                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
