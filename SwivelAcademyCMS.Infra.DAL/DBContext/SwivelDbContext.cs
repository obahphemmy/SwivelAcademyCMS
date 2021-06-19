using Microsoft.EntityFrameworkCore;
using SwivelAcademyCMS.ApplicationCore.Entities;

namespace SwivelAcademyCMS.Infra.DAL.DBContext
{
	public class SwivelDbContext : DbContext
	{
		public SwivelDbContext(DbContextOptions<SwivelDbContext> options) : base(options)
		{}

		public DbSet<Course> Courses { get; set; }
		public DbSet<Teacher> Teachers { get; set; }
		public DbSet<Student> Students { get; set; }
	}
}
