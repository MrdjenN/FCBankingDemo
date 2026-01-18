using Autofac;
using FCBankDemo.Common;
using FCBankDemo.Handlers;
using FCBankDemo.Reposiitories;
using FluentValidation;
using MediatR;

namespace FCBankDemo
{
    public class ApplicationModule : Module
    {
        /// <summary>
        /// 
        /// </summary>
        public ApplicationModule()
        {
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="builder"></param>
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<AccountQuery>()
                .As<IAccountQuery>()
                .InstancePerLifetimeScope();
            builder.RegisterType<AccountRepository>()
                .As<IAccountRepository>()
                .InstancePerLifetimeScope();

            builder.RegisterAssemblyTypes(typeof(DepositAccountCommandValidator).Assembly)
               .Where(t => t.IsClosedTypeOf(typeof(IValidator<>)))
               .AsImplementedInterfaces();
            builder.RegisterGeneric(typeof(ValidationBehavior<,>)).As(typeof(IPipelineBehavior<,>));
        }
    }
}
