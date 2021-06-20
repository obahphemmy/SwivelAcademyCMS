using Microsoft.EntityFrameworkCore;
using SwivelAcademyCMS.ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SwivelAcademyCMS.Infra.DAL.DBContext
{
	public static class Initializer
	{
		public static void RunMigration(SwivelDbContext dbContext)
		{
			dbContext.Database.Migrate();
		}
	}
}


