using Acr.UserDialogs;
using MvvmCross.Core.ViewModels;
using MvvmCross.Localization;
using MvvmCross.Platform;
using MvvmCross.Platform.IoC;
using MvvmCross.Plugins.JsonLocalization;
using XabluAppTest.Core.Helpers;
using XabluAppTest.Core.Holders;
using XabluAppTest.Core.Interfaces;

namespace XabluAppTest.Core
{
    public class App : MvvmCross.Core.ViewModels.MvxApplication
    {
        public override void Initialize()
        {
            CreatableTypes()
                .EndingWith("Service")
                .AsInterfaces()
                .RegisterAsLazySingleton();

            Mvx.RegisterSingleton<IUserDialogs>(() => UserDialogs.Instance);

            // Register localization services
            var builder = new TextProviderBuilder();
            Mvx.RegisterSingleton<IMvxTextProviderBuilder>(builder);
            Mvx.RegisterSingleton<IMvxTextProvider>(builder.TextProvider);

            // Holder of session info
            Mvx.RegisterSingleton(CreateSession());

            // Construct custom application start object
            Mvx.ConstructAndRegisterSingleton<IMvxAppStart, AppStart>();
            var appStart = Mvx.Resolve<IMvxAppStart>();

            // register the appstart object
            RegisterAppStart(appStart);
        }

        private ISessionInfo CreateSession()
        {
            var session = new SessionInfo { IsLogout = false };
            return session;
        }
    }
}
