using Autofac;
using FCBankDemo.Reposiitories;

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
        }
    }
}
