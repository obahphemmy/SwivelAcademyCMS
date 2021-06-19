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
	public class TeacherService : ITeacherService
	{
		private readonly IUnitOfWork _unitOfWork;

		public TeacherService(IUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
		}
		public async Task<int> AddTeacher(TeacherRequest model)
		{
			await _unitOfWork.Teachers.Add(new Teacher { Firstname = model.Firstname, Lastname = model.Lastname });
			return await _unitOfWork.Complete();
		}

		public async Task<TeacherResponse> GetTeacher(int id)
		{
			var teacher = await _unitOfWork.Teachers.GetTeacherWithCourse(id);
			return new TeacherResponse { Id = teacher.Id, Firstname = teacher.Firstname, Lastname = teacher.Lastname, Courses = teacher.Courses.Select(c => new CourseResponse { Id = c.Course.Id, Title = c.Course.Title, CourseUnit = c.Course.CourseUnit }).ToList() };
		}

		public async Task<IEnumerable<TeacherResponse>> GetTeachers()
		{
			var teachers = await _unitOfWork.Teachers.GetAllTeachersWithCourse();
			return teachers.Select(t => new TeacherResponse { Firstname = t.Firstname, Lastname = t.Lastname, Courses = t.Courses.Select(c => new CourseResponse { Id = c.Course.Id, Title = c.Course.Title, CourseUnit = c.Course.CourseUnit }).ToList() });
		}

		public async Task RemoveTeacher(int id)
		{
			var teacher = await _unitOfWork.Teachers.Find(id);
			_unitOfWork.Teachers.Remove(teacher);
			await _unitOfWork.Complete();
		}

		public async Task UpdateTeacher(TeacherResponse model)
		{
			var teacher = await _unitOfWork.Teachers.Find(model.Id);

			teacher.Firstname = model.Firstname;
			teacher.Lastname = model.Lastname;

			_unitOfWork.Teachers.Update(teacher);

			await _unitOfWork.Complete();
		}

		public async Task<int> AssignCourseTeacher(TeacherCourseRequest request)
		{
			var teacherCourse = new TeacherCourse { CourseId = request.CourseId, TeacherId = request.TeacherId };

			await _unitOfWork.TeacherCourses.Add(teacherCourse);

			if (await _unitOfWork.Complete() > 0)
			{
				return teacherCourse.Id;
			}

			return 0;
		}
	}
}
