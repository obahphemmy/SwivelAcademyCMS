using SwivelAcademyCMS.ApplicationCore.DTOs.Request;
using SwivelAcademyCMS.ApplicationCore.DTOs.Response;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SwivelAcademyCMS.ApplicationCore.Interfaces.Services
{
	public interface ITeacherService
	{
		Task<TeacherResponse> GetTeacher(int id);
		Task<IEnumerable<TeacherResponse>> GetTeachers();
		Task RemoveTeacher(int id);
		Task<int> AddTeacher(TeacherRequest teacher);
		Task UpdateTeacher(TeacherResponse teacher);
		Task<int> AssignCourseTeacher(TeacherCourseRequest teacher);
	}
}
