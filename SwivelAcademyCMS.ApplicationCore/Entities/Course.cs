using System;
using System.Collections.Generic;
using System.Text;

namespace SwivelAcademyCMS.ApplicationCore.Entities
{
	public class Course : AuditableEntity
	{
		public string Title { get; set; }
		public int CourseUnit { get; set; }
	}
}
