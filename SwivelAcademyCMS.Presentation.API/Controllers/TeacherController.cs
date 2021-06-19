using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SwivelAcademyCMS.ApplicationCore.DTOs.Request;
using SwivelAcademyCMS.ApplicationCore.DTOs.Response;
using SwivelAcademyCMS.ApplicationCore.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SwivelAcademyCMS.Presentation.API.Controllers
{
	[ApiController]
	[Route("api/v1/teachers/")]
	[Produces("application/json")]
	public class TeacherController : ControllerBase
	{
		private readonly ILogger<TeacherController> _logger;
		private readonly ITeacherService _teacherService;

		public TeacherController(ILogger<TeacherController> logger, ITeacherService teacherService)
		{
			_logger = logger;
			_teacherService = teacherService;
		}
		// GET api/v1/teachers
		[HttpGet]
		public async Task<IActionResult> GetAsync()
		{
			return Ok(await _teacherService.GetTeachers());
		}


		// GET api/v1/teachers/2
		[HttpGet("{id:int}", Name = nameof(GetByIdAsync))]
		public async Task<IActionResult> GetByIdAsync(int id)
		{
			var teacher = await _teacherService.GetTeacher(id);
			if (teacher == null)
				return NotFound();

			return Ok(teacher);
		}

		// POST api/v1/teachers/
		[HttpPost]
		public async Task<IActionResult> CreateAsync([FromBody] TeacherRequest model)
		{
			var result = await _teacherService.AddTeacher(model);

			if (result > 0)
				return CreatedAtAction(nameof(GetByIdAsync), "Teacher", new { id = result }, model);

			return NotFound();
		}


		// POST api/v1/teachers/assigncourse
		[HttpPost("assigncourse")]
		public async Task<IActionResult> CreateAsync([FromBody] TeacherCourseRequest model)
		{
			var result = await _teacherService.AssignCourseTeacher(model);

			if (result > 0)
				return CreatedAtAction(nameof(GetByIdAsync), "Teacher", new { id = result }, model);

			return NotFound();
		}


		// PUT api/v1/teachers/2
		[HttpPut("{id:int}")]
		public async Task<IActionResult> UpdateAsync(int id, [FromBody] TeacherResponse model)
		{
			if (id != model.Id)
			{
				return BadRequest();
			}

			var teacher = await _teacherService.GetTeacher(id);

			if (teacher == null)
			{
				return NotFound();
			}

			await _teacherService.UpdateTeacher(model);

			return NoContent();
		}

		// DELETE api/v1/teachers/{id}
		[HttpDelete("{id}")]
		public async Task<IActionResult> DeleteAsync(int id)
		{
			var teacher = await _teacherService.GetTeacher(id);

			if (teacher == null)
			{
				return NotFound();
			}

			await _teacherService.RemoveTeacher(id);

			return NoContent();
		}
	}
}
