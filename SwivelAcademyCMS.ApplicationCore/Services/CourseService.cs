using SwivelAcademyCMS.ApplicationCore.DTOs.Request;
using SwivelAcademyCMS.ApplicationCore.DTOs.Response;
using SwivelAcademyCMS.ApplicationCore.Entities;
using SwivelAcademyCMS.ApplicationCore.Interfaces.Repositories;
using SwivelAcademyCMS.ApplicationCore.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwivelAcademyCMS.ApplicationCore.Services
{
	public class CourseService : ICourseService
	{
		private readonly IUnitOfWork _unitOfWork;

		public CourseService(IUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
		}
		public async Task<int> AddCourse(CourseRequest model)
		{
			await _unitOfWork.Courses.Add(new Course { Title = model.Title, CourseUnit = model.CourseUnit });
			return await _unitOfWork.Complete();
		}

		public async Task<CourseResponse> GetCourse(int id)
		{
			var course = await _unitOfWork.Courses.Find(id);
			if (course == null)
				return null;

			return new CourseResponse { Id = course.Id, Title = course.Title, CourseUnit = course.CourseUnit };
		}

		public async Task<IEnumerable<CourseResponse>> GetCourses(int count = 20)
		{
			var courses = await _unitOfWork.Courses.GetAll();

			return courses.Select(c => new CourseResponse { Id = c.Id, Title = c.Title, CourseUnit = c.CourseUnit }).ToList();
		}

		public async Task RemoveCourse(int id)
		{
			var course = await _unitOfWork.Courses.Find(id);
			_unitOfWork.Courses.Remove(course);

			await _unitOfWork.Complete();
		}

		public async Task UpdateCourse(CourseResponse model)
		{
			var course = await _unitOfWork.Courses.Find(model.Id);

			course.Title = model.Title;
			course.CourseUnit = model.CourseUnit;

			_unitOfWork.Courses.Update(course);

			await _unitOfWork.Complete();
		}
	}
}
