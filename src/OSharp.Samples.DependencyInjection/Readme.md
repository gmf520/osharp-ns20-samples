# OSharpNS 依赖注入示例

## 自动注册依赖注入方式

在服务接口类或服务实现类实现如下接口，系统初始化时将自动将相应类型注册到依赖注入容器中。

* 单例生命周期类型：`ISingletonDependency`
```
    interface ISingletonService1 { }

    class SingletonService1 : ISingletonService1, ISingletonDependency { }
```
* 区域生命周期类型：`IScopeDependency`
```
    interface IScopeService1 { }

    class ScopeService1 : IScopeService1, IScopeDependency { }
```
* 即时生命周期类型：`ITransientDependency`
```
    interface ITransientService1 { }

    class TransientService1 : ITransientService1, ITransientDependency { }
```

## 手动注册依赖注入方式

在每个Pack模块的`AddService`方法中进行服务接口与服务实现的注册

接口与实现
```
    interface ISingletonService2 { }

    class SingletonService2 : ISingletonService2 { }

    interface IScopeService2 { }

    class ScopeService2 : IScopeService2 { }

    interface ITransientService2 { }

    class TransientService2 : ITransientService2 { }
```
在模块Pack注册到容器中
```
    public class TestPack : OsharpPack
    {
        public override IServiceCollection AddServices(IServiceCollection services)
        {
            services.AddSingleton<ISingletonService2, SingletonService2>();
            services.AddScoped<IScopeService2, ScopeService2>();
            services.AddTransient<ITransientService2, TransientService2>();

            return services;
        }
    }
```
