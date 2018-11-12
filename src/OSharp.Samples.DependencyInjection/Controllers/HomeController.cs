
using System;
using System.Collections.Generic;
using System.Linq;

using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

using OSharp.Collections;
using OSharp.Core.Packs;


namespace OSharp.Samples.DependencyInjection.Controllers
{
    public class HomeController : Controller
    {
        private const string NewLine = "\r\n";
        private readonly IOsharpPackManager _packManager;
        private readonly IServiceProvider _provider;

        public HomeController(IOsharpPackManager packManager, IServiceProvider provider)
        {
            _packManager = packManager;
            _provider = provider;
        }

        public IActionResult Index()
        {
            List<string> list = new List<string>();

            list.Add("已加载的Pack模块：");
            var packs = _packManager.LoadedPacks;
            list.AddRange(packs.Select(m => m.GetType().FullName));
            list.Add(NewLine);

            list.Add("自动依赖注入：");
            var singleton1 = _provider.GetService<ISingletonService1>();
            list.Add($"单例：{typeof(ISingletonService1).Name} - {singleton1.GetType().Name}，HashCode:{singleton1.GetHashCode()}");
            var scope1 = _provider.GetService<IScopeService1>();
            list.Add($"区域1：{typeof(IScopeService1).Name} - {scope1.GetType().Name}，HashCode:{scope1.GetHashCode()}");
            scope1 = _provider.GetService<IScopeService1>();
            list.Add($"区域2：{typeof(IScopeService1).Name} - {scope1.GetType().Name}，HashCode:{scope1.GetHashCode()}");
            var transient1 = _provider.GetService<ITransientService1>();
            list.Add($"即时1：{typeof(ITransientService1).Name} - {transient1.GetType().Name}，HashCode:{transient1.GetHashCode()}");
            transient1 = _provider.GetService<ITransientService1>();
            list.Add($"即时2：{typeof(ITransientService1).Name} - {transient1.GetType().Name}，HashCode:{transient1.GetHashCode()}");
            list.Add(NewLine);

            list.Add("手动依赖注入：");
            var singleton2 = _provider.GetService<ISingletonService2>();
            list.Add($"单例：{typeof(ISingletonService2).Name} - {singleton2.GetType().Name}，HashCode:{singleton2.GetHashCode()}");
            var scope2 = _provider.GetService<IScopeService2>();
            list.Add($"区域1：{typeof(IScopeService2).Name} - {scope2.GetType().Name}，HashCode:{scope2.GetHashCode()}");
            scope2 = _provider.GetService<IScopeService2>();
            list.Add($"区域2：{typeof(IScopeService2).Name} - {scope2.GetType().Name}，HashCode:{scope2.GetHashCode()}");
            var transient2 = _provider.GetService<ITransientService2>();
            list.Add($"即时1：{typeof(ITransientService2).Name} - {transient2.GetType().Name}，HashCode:{transient2.GetHashCode()}");
            transient2 = _provider.GetService<ITransientService2>();
            list.Add($"即时2：{typeof(ITransientService2).Name} - {transient2.GetType().Name}，HashCode:{transient2.GetHashCode()}");

            return Content(list.ExpandAndToString(NewLine));
        }
    }
}
