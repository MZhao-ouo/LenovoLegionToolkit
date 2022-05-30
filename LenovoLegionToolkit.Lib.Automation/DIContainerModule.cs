﻿using Autofac;
using LenovoLegionToolkit.Lib.Extensions;

namespace LenovoLegionToolkit.Lib.Automation
{
    public class DIContainerModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.Register<AutomationProcessor>();
        }
    }
}
