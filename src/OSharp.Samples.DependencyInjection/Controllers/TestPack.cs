
using Microsoft.Extensions.DependencyInjection;

using OSharp.Core.Packs;
using OSharp.Dependency;


namespace OSharp.Samples.DependencyInjection.Controllers
{
    public class TestPack : OsharpPack
    {
        /// <summary>将模块服务添加到依赖注入服务容器中</summary>
        /// <param name="services">依赖注入服务容器</param>
        /// <returns></returns>
        public override IServiceCollection AddServices(IServiceCollection services)
        {
            services.AddSingleton<ISingletonService2, SingletonService2>();
            services.AddScoped<IScopeService2, ScopeService2>();
            services.AddTransient<ITransientService2, TransientService2>();

            return services;
        }
    }


    interface ISingletonService1 { }
    
    class SingletonService1 : ISingletonService1, ISingletonDependency { }

    interface IScopeService1 { }

    class ScopeService1 : IScopeService1, IScopeDependency { }

    interface ITransientService1 { }

    class TransientService1 : ITransientService1, ITransientDependency { }



    interface ISingletonService2 { }

    class SingletonService2 : ISingletonService2 { }

    interface IScopeService2 { }

    class ScopeService2 : IScopeService2 { }

    interface ITransientService2 { }

    class TransientService2 : ITransientService2 { }

}
