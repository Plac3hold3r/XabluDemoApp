using MvvmCross.Core.ViewModels;
using MvvmCross.Plugins.JsonLocalization;
using System.Globalization;
using XabluAppTest.Core.ViewModels;

namespace XabluAppTest.Core
{
    public class AppStart : MvxNavigatingObject, IMvxAppStart
    {
        private IMvxTextProviderBuilder _textProviderBuilder;

        public AppStart(IMvxTextProviderBuilder textProviderBuilder)
        {
            _textProviderBuilder = textProviderBuilder;
        }

        public void Start(object hint = null)
        {
            var languageName = CultureInfo.CurrentCulture.TwoLetterISOLanguageName;
            _textProviderBuilder.LoadResources(languageName);

            //ShowViewModel<LoginViewModel>();
            ShowViewModel<HomeViewModel>();
        }
    }
}
