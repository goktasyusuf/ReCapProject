using Autofac;
using Autofac.Extras.DynamicProxy;
using Castle.DynamicProxy;
using Core.Async.RabbitMQ.Publisher.Abstract;
using Core.Async.RabbitMQ.Publisher;
using Core.Utilities.FileHelper;
using Core.Utilities.Interceptors;
using Core.Utilities.Security.JWT;

namespace Core.DependencyResolvers.Autofac
{
    public class AutofacCoreModule : Module
    {

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<FileHelper>().As<IFileHelper>().SingleInstance();
            builder.RegisterType<JwtHelper>().As<ITokenHelper>().SingleInstance();
            builder.RegisterType<MailPublisher>().As<IMailPublisher>().SingleInstance();

            var assembly = System.Reflection.Assembly.GetExecutingAssembly();
            builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces()
                .EnableInterfaceInterceptors(new ProxyGenerationOptions()
                {
                    Selector = new AspectInterceptorSelector()
                }).SingleInstance();
        }
    }
}
