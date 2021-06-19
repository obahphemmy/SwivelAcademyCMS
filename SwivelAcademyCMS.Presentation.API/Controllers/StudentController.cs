using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SwivelAcademyCMS.ApplicationCore.DTOs.Request;
using SwivelAcademyCMS.ApplicationCore.DTOs.Response;
using SwivelAcademyCMS.ApplicationCore.Entities;
using SwivelAcademyCMS.ApplicationCore.Interfaces.Repositories;
using SwivelAcademyCMS.ApplicationCore.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SwivelAcademyCMS.Presentation.API.Controllers
{
	[ApiController]
	[Route("api/v1/students/")]
	[Produces("application/json")]
	public class StudentController : ControllerBase
	{
		private readonly ILogger<StudentController> _logger;
		private readonly IStudentService _studentService;

		public StudentController(ILogger<StudentController> logger, IStudentService studentService)
		{
			_logger = logger;
			_studentService = studentService;
		}
		// GET api/v1/students
		[HttpGet]
		public async Task<IActionResult> GetAsync()
		{
			return Ok(await _studentService.GetStudents());
		}


		// GET api/v1/students/2
		[HttpGet("{id:int}", Name = nameof(GetById))]
		public async Task<IActionResult> GetById(int id)
		{
			var student = await _studentService.GetStudent(id);
			if (student == null)
				return NotFound();

			return Ok(student);
		}

		// POST api/v1/students/
		[HttpPost]
		public async Task<IActionResult> CreateAsync([FromBody] StudentRequest model)
		{
			var result = await _studentService.AddStudent(model);

			if (result > 0)
				return CreatedAtAction(nameof(GetById), "Student", new { id = result }, model);

			return NotFound();
		}


		// POST api/v1/students/enrollcourse
		[HttpPost("registercourse")]
		public async Task<IActionResult> CreateAsync([FromBody] StudentCourseRequest model)
		{
			var result = await _studentService.RegisterStudentCourse(model);

			if (result > 0)
				return CreatedAtAction(nameof(GetById), "Student", new { id = result }, model);

			return NotFound();
		}


		// PUT api/v1/students/2
		[HttpPut("{id:int}")]
		public async Task<IActionResult> UpdateAsync(int id, [FromBody] StudentResponse model)
		{
			if (id != model.Id)
			{
				return BadRequest();
			}

			var student = await _studentService.GetStudent(id);

			if(student == null)
			{
				return NotFound();
			}

			await _studentService.UpdateStudent(model);

			return NoContent();
		}

		// DELETE api/v1/students/{id}
		[HttpDelete("{id}")]
		public async Task<IActionResult> DeleteAsync(int id)
		{
			var student = await _studentService.GetStudent(id);

			if (student == null)
			{
				return NotFound();
			}

			await _studentService.RemoveStudent(id);

			return NoContent();
		}
	}
}
