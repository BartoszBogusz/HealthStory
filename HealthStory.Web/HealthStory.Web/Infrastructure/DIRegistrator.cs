using Autofac;
using System.Reflection;

namespace HealthStory.Web
{
    public static class DIRegistrator
    {
        public static void RegisterImplementedInterfaces(this ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(Assembly.GetCallingAssembly())
                .AsImplementedInterfaces();
        }
    }
}
