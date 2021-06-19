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
	public class StudentService : IStudentService
	{
		private readonly IUnitOfWork _unitOfWork;

		public StudentService(IUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
		}
		public async Task<int> AddStudent(StudentRequest model)
		{
			var student = new Student { Firstname = model.Firstname, Lastname = model.Lastname };

			await _unitOfWork.Students.Add(student);

			if (await _unitOfWork.Complete() > 0)
				return student.Id;

			return 0;
		}

		public async Task<StudentResponse> GetStudent(int id)
		{
			var student = await _unitOfWork.Students.GetStudentWithCourse(id);
			if (student == null)
				return null;

			return new StudentResponse {Id = student.Id, Firstname = student.Firstname, Lastname = student.Lastname, Courses = student.Courses.Select(c => new CourseResponse { Id = c.Id, Title = c.Course.Title, CourseUnit = c.Course.CourseUnit }).ToList() };
		}

		public async Task<IEnumerable<StudentResponse>> GetStudents(int count = 20)
		{
			var students = await _unitOfWork.Students.GetAllStudentsWithCourse();

			return students.Select(s => new StudentResponse { Id = s.Id, Firstname = s.Firstname, Lastname = s.Lastname, Courses = s.Courses.Select(c => new CourseResponse { Id = c.Course.Id, Title = c.Course.Title, CourseUnit = c.Course.CourseUnit }).ToList() }).ToList();
		}

		public async Task UpdateStudent(StudentResponse model)
		{
			var student = await _unitOfWork.Students.Find(model.Id);

			student.Firstname = model.Firstname;
			student.Lastname = model.Lastname;

			_unitOfWork.Students.Update(student);

			await _unitOfWork.Complete();
		}

		public async Task RemoveStudent(int id)
		{
			var student = await _unitOfWork.Students.Find(id);
			_unitOfWork.Students.Remove(student);

			await _unitOfWork.Complete();

		}

		public async Task<int> RegisterStudentCourse(StudentCourseRequest courseRequest)
		{
			var studentCourse = new StudentCourse { CourseId = courseRequest.CourseId, StudentId = courseRequest.StudentId };

			await _unitOfWork.StudentCourses.Add(studentCourse);

			if (await _unitOfWork.Complete() > 0)
			{
				return studentCourse.Id;
			}

			return 0;
		}
	}
}
