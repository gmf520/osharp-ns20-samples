
using System;
using System.Collections.Generic;
using System.Linq;

using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

using OSharp.Collections;
using OSharp.Core.Builders;
using OSharp.Core.Packs;


namespace OSharp.Samples.DependencyInjection.Controllers
{
    public class HomeController : Controller
    {
        private const string NewLine = "\r\n";
        private readonly IServiceProvider _provider;

        public HomeController(IServiceProvider provider)
        {
            _provider = provider;
        }

        public IActionResult Index()
        {
            List<string> list = new List<string>();
            IOsharpBuilder builder = _provider.GetRequiredService<IOsharpBuilder>();

            list.Add("已加载的Pack模块：");
            var packs = builder.Packs;

            list.AddRange(packs.Select(m => m.GetType().FullName));
            list.Add(NewLine);

            list.Add("自动依赖注入：");
            var singleton1 = _provider.GetRequiredService<ISingletonService1>();
            list.Add($"单例：{nameof(ISingletonService1)} - {singleton1.GetType().Name}，HashCode:{singleton1.GetHashCode()}");
            var scope1 = _provider.GetRequiredService<IScopeService1>();
            list.Add($"区域1：{nameof(IScopeService1)} - {scope1.GetType().Name}，HashCode:{scope1.GetHashCode()}");
            scope1 = _provider.GetRequiredService<IScopeService1>();
            list.Add($"区域2：{nameof(IScopeService1)} - {scope1.GetType().Name}，HashCode:{scope1.GetHashCode()}");
            var transient1 = _provider.GetRequiredService<ITransientService1>();
            list.Add($"即时1：{nameof(ITransientService1)} - {transient1.GetType().Name}，HashCode:{transient1.GetHashCode()}");
            transient1 = _provider.GetRequiredService<ITransientService1>();
            list.Add($"即时2：{nameof(ITransientService1)} - {transient1.GetType().Name}，HashCode:{transient1.GetHashCode()}");
            list.Add(NewLine);

            list.Add("手动依赖注入：");
            var singleton2 = _provider.GetRequiredService<ISingletonService2>();
            list.Add($"单例：{nameof(ISingletonService2)} - {singleton2.GetType().Name}，HashCode:{singleton2.GetHashCode()}");
            var scope2 = _provider.GetRequiredService<IScopeService2>();
            list.Add($"区域1：{nameof(IScopeService2)} - {scope2.GetType().Name}，HashCode:{scope2.GetHashCode()}");
            scope2 = _provider.GetRequiredService<IScopeService2>();
            list.Add($"区域2：{nameof(IScopeService2)} - {scope2.GetType().Name}，HashCode:{scope2.GetHashCode()}");
            var transient2 = _provider.GetRequiredService<ITransientService2>();
            list.Add($"即时1：{nameof(ITransientService2)} - {transient2.GetType().Name}，HashCode:{transient2.GetHashCode()}");
            transient2 = _provider.GetRequiredService<ITransientService2>();
            list.Add($"即时2：{nameof(ITransientService2)} - {transient2.GetType().Name}，HashCode:{transient2.GetHashCode()}");

            return Content(list.ExpandAndToString(NewLine));
        }
    }
}
