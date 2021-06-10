using iMedical.Models.JobTypeModels;
using iMedicalApi.Models;
using iMedicalApi.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace iMedicalApi.Controllers
{
    [Route("api/jobType")]
    [Authorize(Roles = "Administracja,Admin")]
    public class JobTypeController : ControllerBase
    {
        private readonly IJobTypeService _jobTypeService;
        public JobTypeController(IJobTypeService jobTypeService)
        {
            _jobTypeService = jobTypeService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<JobTypeDto>> GetAll()
        {

            var jobTypesDtos = _jobTypeService.GetAll();


            return Ok(jobTypesDtos);
        }

        [HttpGet("{id}")]
        public ActionResult<JobTypeDto> Get([FromRoute] int id)
        {
            var jobType = _jobTypeService.GetById(id);

            if (jobType is null)
            {
                return NotFound();
            }

            return Ok(jobType);
        }

        [HttpPost]
        public ActionResult CreateJobType([FromBody] CreateJobTypeDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var id = _jobTypeService.Create(dto);


            return Created($"/api/jobType/{id}", null);
        }


        [HttpDelete("{id}")]
        public ActionResult Delete([FromRoute] int id)
        {
            var isDeleted = _jobTypeService.Delete(id);

            if (isDeleted)
            {
                return NoContent();
            }

            return NotFound();
        }

        [HttpPut("{id}")]
        public ActionResult Update([FromBody] UpdateJobTypeDto dto, [FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var isUpdated = _jobTypeService.Update(id, dto);

            if (!isUpdated)
            {
                return NotFound();
            }

            return Ok();
        }


    }
}
