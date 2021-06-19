using System;
using System.Collections.Generic;
using System.Text;

namespace SwivelAcademyCMS.ApplicationCore.DTOs.Request
{
	public class TeacherCourseRequest
	{
		public int TeacherId { get; set; }
		public int CourseId { get; set; }
	}
}
