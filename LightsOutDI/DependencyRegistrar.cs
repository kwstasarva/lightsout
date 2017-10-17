using Autofac;
using LightsOutBL.Helpers;
using LightsOutBL.Helpers.IHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LightsOutDI
{
    public class DependencyRegistrar
    {
        static void Main(string[] args)
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<GameEngine>().As<IGameEngine>();

            var container = builder.Build();
        }
    }
}
