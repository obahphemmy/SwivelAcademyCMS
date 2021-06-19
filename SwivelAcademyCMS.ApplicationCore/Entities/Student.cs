using System;
using System.Collections.Generic;
using System.Text;

namespace SwivelAcademyCMS.ApplicationCore.Entities
{
	public class Student : AuditableEntity
	{
		public string Firstname { get; set; }
		public string Lastname { get; set; }
		public ICollection<StudentCourse> Courses { get; set; }
	}
}
