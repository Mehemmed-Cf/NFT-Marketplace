using Application.Services;
using Autofac;
using Infrastructure.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation.AspNetCore;

namespace Application
{
    public class ApplicationModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);

            builder.RegisterType<IJwtService>()
                .As<IJwtService>()
                .InstancePerLifetimeScope();

            builder.RegisterType<CryptoService>()
                .As<ICryptoService>()
                .InstancePerLifetimeScope();

            builder.RegisterType<FileService>()
            .As<IFileService>()
            .InstancePerLifetimeScope();

            //builder.RegisterType<ValidatorInterceptor>()
            //    .As<IValidatorInterceptor>()
            //    .SingleInstance();
        }
    }
}
