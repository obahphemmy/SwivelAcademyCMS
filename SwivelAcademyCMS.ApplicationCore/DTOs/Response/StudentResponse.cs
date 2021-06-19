using SwivelAcademyCMS.ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SwivelAcademyCMS.ApplicationCore.DTOs.Response
{
	public class StudentResponse
	{
		public int Id { get; set; }
		public string Firstname { get; set; }
		public string Lastname { get; set; }
		public IEnumerable<CourseResponse> Courses { get; set; }
	}
}
