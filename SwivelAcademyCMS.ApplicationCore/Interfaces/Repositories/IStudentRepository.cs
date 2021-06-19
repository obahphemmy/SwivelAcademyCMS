using SwivelAcademyCMS.ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SwivelAcademyCMS.ApplicationCore.Interfaces.Repositories
{
	public interface IStudentRepository : IRepository<Student> 
	{
		Task<Student> GetStudentWithCourse(int id);
		Task<IEnumerable<Student>> GetAllStudentsWithCourse();
	}
}
