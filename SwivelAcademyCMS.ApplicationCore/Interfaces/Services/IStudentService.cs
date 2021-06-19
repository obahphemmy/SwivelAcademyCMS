using SwivelAcademyCMS.ApplicationCore.DTOs.Request;
using SwivelAcademyCMS.ApplicationCore.DTOs.Response;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SwivelAcademyCMS.ApplicationCore.Interfaces.Services
{
	public interface IStudentService
	{
		Task<StudentResponse> GetStudent(int id);
		Task<IEnumerable<StudentResponse>> GetStudents(int count = 20);
		Task RemoveStudent(int id);
		Task<int> AddStudent(StudentRequest student);
		Task UpdateStudent(StudentResponse student);
		Task<int> RegisterStudentCourse(StudentCourseRequest courseRequest);
	}
}
