using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SwivelAcademyCMS.ApplicationCore.DTOs.Request;
using SwivelAcademyCMS.ApplicationCore.DTOs.Response;
using SwivelAcademyCMS.ApplicationCore.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SwivelAcademyCMS.Presentation.API.Controllers
{
	[ApiController]
	[Route("api/v1/courses")]
	[Produces("application/json")]
	public class CourseController : ControllerBase
	{
		private readonly ILogger<CourseController> _logger;
		private readonly ICourseService _courseService;

		public CourseController(ILogger<CourseController> logger, ICourseService courseService)
		{
			_logger = logger;
			_courseService = courseService;
		}

		// GET: api/v1/courses
		[HttpGet]
		public async Task<IActionResult> Get()
		{
			return Ok(await _courseService.GetCourses());
		}

		// GET api/v1/courses/5
		[HttpGet("{id:int}")]
		public async Task<IActionResult> Get(int id)
		{
			var course = await _courseService.GetCourse(id);
			if (course == null)
				return NotFound();

			return Ok(course);
		}

		// POST api/v1/courses
		[HttpPost]
		public async Task<IActionResult> Post([FromBody] CourseRequest model)
		{
			var result = await _courseService.AddCourse(model);

			if (result > 0)
				return CreatedAtAction(nameof(Get), "Course", new { id = result }, model);

			return NotFound();
		}

		// PUT api/v1/courses/5
		[HttpPut("{id:int}")]
		public async Task<IActionResult> Put(int id, [FromBody] CourseResponse model)
		{
			if (id != model.Id)
			{
				return BadRequest();
			}

			var course = await _courseService.GetCourse(id);

			if (course == null)
			{
				return NotFound();
			}

			await _courseService.UpdateCourse(model);

			return NoContent();
		}

		// DELETE api/v1/courses/5
		[HttpDelete("{id:int}")]
		public async Task<IActionResult> Delete(int id)
		{
			var course = await _courseService.GetCourse(id);

			if (course == null)
			{
				return NotFound();
			}

			await _courseService.RemoveCourse(id);

			return NoContent();
		}
	}
}
