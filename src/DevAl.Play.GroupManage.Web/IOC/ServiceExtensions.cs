using DevAl.Play.GroupManage.BusinessImpl.Services;
using DevAl.Play.GroupManage.Business.Services;
using Microsoft.Extensions.DependencyInjection;

namespace DevAl.Play.GroupManage.Web.IOC
{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddBusiness(this IServiceCollection services)
        {
            services.AddTransient<IGroupServices, GroupService>();
            return services;
        }
    }
}
