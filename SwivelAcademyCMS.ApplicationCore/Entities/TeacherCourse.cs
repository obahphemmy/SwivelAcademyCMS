using System;
using System.Collections.Generic;
using System.Text;

namespace SwivelAcademyCMS.ApplicationCore.Entities
{
	public class TeacherCourse 
	{
		public int Id { get; set; }
		public Teacher Teacher { get; set; }
		public int TeacherId { get; set; }
		public Course Course { get; set; }
		public int CourseId { get; set; }
	}
}
