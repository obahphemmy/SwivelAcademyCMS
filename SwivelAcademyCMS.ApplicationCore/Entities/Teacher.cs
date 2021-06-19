using System;
using System.Collections.Generic;
using System.Text;

namespace SwivelAcademyCMS.ApplicationCore.Entities
{
	public class Teacher : AuditableEntity
	{
		public string Firstname { get; set; }
		public string Lastname { get; set; }
		public ICollection<TeacherCourse> Courses { get; set; }
	}
}
