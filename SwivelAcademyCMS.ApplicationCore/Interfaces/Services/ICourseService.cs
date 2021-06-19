using SwivelAcademyCMS.ApplicationCore.DTOs;
using SwivelAcademyCMS.ApplicationCore.DTOs.Request;
using SwivelAcademyCMS.ApplicationCore.DTOs.Response;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SwivelAcademyCMS.ApplicationCore.Interfaces.Services
{
	public interface ICourseService
	{
		Task<CourseResponse> GetCourse(int id);
		Task<IEnumerable<CourseResponse>> GetCourses(int count = 20);
		Task RemoveCourse(int id);
		Task<int> AddCourse(CourseRequest course);
		Task UpdateCourse(CourseResponse course);
	}
}
