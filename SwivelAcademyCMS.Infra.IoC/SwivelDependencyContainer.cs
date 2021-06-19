using Microsoft.Extensions.DependencyInjection;
using SwivelAcademyCMS.ApplicationCore.Interfaces.Repositories;
using SwivelAcademyCMS.ApplicationCore.Interfaces.Services;
using SwivelAcademyCMS.ApplicationCore.Services;
using SwivelAcademyCMS.Infra.DAL.Repository;
using System;

namespace SwivelAcademyCMS.Infra.IoC
{
	public static class SwivelDependencyContainer
	{
		public static IServiceCollection AddSwivelCMSServices(this IServiceCollection services)
		{
			services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
			services.AddScoped<IStudentRepository, StudentRepository>();
			services.AddScoped<ITeacherRepository, TeacherRepository>();
			services.AddScoped<IUnitOfWork, UnitOfWork>();
			services.AddScoped<IStudentService, StudentService>();
			services.AddScoped<ICourseService, CourseService>();
			services.AddScoped<ITeacherService, TeacherService>();

			return services;
		}
	}
}
