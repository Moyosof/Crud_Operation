using CRUD_Operation.Inferfaces;
using CRUD_Operation.Services;

namespace CRUD_Operation
{
    public static class Extension
    {
        public static void ConfigureRepoService(this IServiceCollection services)
        {
            services.AddScoped<IJobService, JobService>();
            
        }
    }
}
