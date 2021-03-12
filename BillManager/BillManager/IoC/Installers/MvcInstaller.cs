using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BillManager.Installers
{
	public class MvcInstaller : IInstaller
	{
		public void InstallServices(IServiceCollection services, IConfiguration configuration)
		{
			//services.AddControllersWithViews();
			//services.AddRazorPages();

			services.AddSwaggerGen(x =>
			{
				x.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo { Title = "Bill Manager API", Version = "v1" });
			});
		}
	}
}
