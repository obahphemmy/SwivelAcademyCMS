using System;
using System.Collections.Generic;
using System.Text;

namespace SwivelAcademyCMS.ApplicationCore.Entities
{
	public class AuditableEntity
	{
		public int Id { get; set; }
		public string CreatedBy { get; set; }
		public string ModifiedBy { get; set; }
		public DateTimeOffset? DateCreated { get; set; } = DateTimeOffset.Now;
		public DateTimeOffset? DateModified { get; set; } = DateTimeOffset.Now;
	}
}
