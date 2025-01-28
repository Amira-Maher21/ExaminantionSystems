using Autofac;
using ExaminantionSystem.Data;
using ExaminantionSystem.Services.user;
using ExaminantionSystem.Services.user;
using ExaminationSystem.Repositories;
using System.Reflection;

namespace ExaminantionSystem
{
    public class AutoFacModule : Autofac.Module
    {

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterGeneric(typeof(Repository<>)).As(typeof(IRepository<>)).InstancePerLifetimeScope();
            builder.RegisterType<Context>().InstancePerLifetimeScope();
            builder.RegisterAssemblyTypes(typeof(ILoginUserServices).Assembly).AsImplementedInterfaces().InstancePerLifetimeScope();
        }
    }
}
