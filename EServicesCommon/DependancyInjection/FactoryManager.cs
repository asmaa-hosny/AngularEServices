using Autofac;
using Autofac.Configuration;
using Autofac.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace EServicesCommon.DI
{
    public class FactoryManager
    {
        public static readonly FactoryManager Instance = new FactoryManager();

        public IContainer _container { get; private set; }

        public T Resolve<T>()
        {
            return _container.Resolve<T>();
        }

        public T Resolve<T>(string name)
        {
            return _container.ResolveNamed<T>(name);
        }

        public T Resolve<T>(Dictionary<string, object> parameters)
        {
            if (parameters != null)
            {
                List<Autofac.Core.Parameter> paramList = new List<Autofac.Core.Parameter>();
                foreach (var parm in parameters)
                    paramList.Add(new NamedParameter(parm.Key, parm.Value));
                return this._container.Resolve<T>(paramList);
            }

            return this._container.Resolve<T>();
        }

        public IServiceProvider LoadConfiguaration(IEnumerable<ServiceDescriptor> descriptors)
        {
            var config = new ConfigurationBuilder();
            config.AddJsonFile("autofac.json");

            var module = new ConfigurationModule(config.Build());

            var builder = new ContainerBuilder();
            builder.RegisterModule(module);
            
            if (descriptors != null)
                builder.Populate(descriptors);

            this._container = builder.Build();

            return this._container.Resolve<IServiceProvider>();

        }

  
    }
}
