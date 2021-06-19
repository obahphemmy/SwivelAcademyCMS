using System;
using System.Collections.Generic;
using System.Text;

namespace SwivelAcademyCMS.ApplicationCore.Entities
{
	public class StudentCourse
	{
		public int Id { get; set; }
		public Student Student { get; set; }
		public int StudentId { get; set; }
		public Course Course { get; set; }
		public int CourseId { get; set; }
	}
}
