using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Acr.UserDialogs;
using MvvmCross.Core.Navigation;
using MvvmCross.Core.ViewModels;
using MvvmCross.Platform;
using XabluAppTest.Core.Enums;
using XabluAppTest.Core.Helpers;
using XabluAppTest.Core.Interfaces;
using XabluAppTest.Core.Services;

namespace XabluAppTest.Core.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        private readonly ISessionInfo _session;
        public LoginViewModel()
        {
            _session = Mvx.Resolve<ISessionInfo>();

            InitializeApiServiceList();

            //if (!_session.IsLogout)
            //{
            //    InitializeUser();
            //}
        }

        private void InitializeApiServiceList()
        {
            _apiServiceList = new List<string>();

            foreach (ApiServiceTypes type in Enum.GetValues(typeof(ApiServiceTypes)))
            {
                _apiServiceList.Add(type.ToString());
            }

            string first = null;
            foreach (var s in _apiServiceList)
            {
                first = s;
                break;
            }
            _selectedApiService = first != null ? _apiServiceList.FirstOrDefault() : "Error";
        }

        private async void InitializeUser()
        {
            if (Settings.RememberLogin)
            {
                _rememberLogin = Settings.RememberLogin;
                _loginName = Settings.UserLogin;
                _password = Settings.UserPassword;

                if (ApiServiceList.Any(q => q.Equals(Settings.RememberApiService)))
                {
                    _selectedApiService = Settings.RememberApiService;
                }
                else
                {
                    string first = null;
                    foreach (var s in _apiServiceList)
                    {
                        first = s;
                        break;
                    }
                    _selectedApiService = first != null ? _apiServiceList.FirstOrDefault() : "Error";
                }

                if (!string.IsNullOrEmpty(_loginName) || !string.IsNullOrEmpty(_password))
                {
                    await ExecuteLoginAsync(true);
                }
            }
        }

        private MvxCommand _loginCommand;
        public ICommand LoginCommand
        {
            get
            {
                _loginCommand = _loginCommand ?? new MvxCommand(async () => await ExecuteLoginAsync(false));

                return _loginCommand;
            }
        }

        private async Task ExecuteLoginAsync(bool force)
        {
            UserDialogs.Instance.ShowLoading("SigningIn", MaskType.Black);

            bool isOk = false;
            bool isValidate = true;

            //if (string.IsNullOrEmpty(LoginName) || string.IsNullOrEmpty(Password))
            //{
            //    _infoMessageReporter.ShowInfoMessage("LoginAndPasswordRequired");
            //    isValidate = false;
            //}

            if (_rememberLogin && !force)
            {
                Settings.RememberLogin = _rememberLogin;
                Settings.UserLogin = _loginName;
                Settings.UserPassword = _password;
                Settings.RememberApiService = _selectedApiService;
            }

            if (!_rememberLogin && !force)
            {
                Settings.RememberLogin = false;
                Settings.UserLogin = string.Empty;
                Settings.UserPassword = string.Empty;
                Settings.RememberApiService = string.Empty;
            }

            if (isValidate)
            {
                if (_selectedApiService == ApiServiceTypes.Demo.ToString())
                {
                    if (LoginName == Constants.DemoUserLogin && Password == Constants.DemoUserPassword)
                    {
                        await Task.Delay(1000);

                        _session.LoginName = _loginName;
                        _session.Password = _password;
                        _session.ApiService = ApiServiceTypes.Demo;
                        _session.Id = new Guid();
                        isOk = true;
                    }
                    else
                    {
                        isOk = false;
                    }
                }
                else
                {
                    _session.LoginName = _loginName;
                    _session.Password = _password;
                    _session.ApiService = ApiServiceTypes.Test;
                    _session.Id = new Guid();
                    isOk = true;
                }
            }

            if (isOk)
            {
                UserDialogs.Instance.HideLoading();
                await Task.Delay(500);
                await Mvx.Resolve<IMvxNavigationService>().Navigate<HomeViewModel>();
                //ShowViewModel<HomeViewModel>();
            }
            else
            {
                UserDialogs.Instance.HideLoading();
            }
        }

        private MvxCommand _forgotPasswordCommand;
        public ICommand ForgotPasswordCommand
        {
            get
            {
                _forgotPasswordCommand = _forgotPasswordCommand ?? new MvxCommand(ExecuteForgotPassword);
                return _forgotPasswordCommand;
            }
        }

        private void ExecuteForgotPassword()
        {
            //TODO Show ForgotPasswordViewModel
        }

        private string _loginName;
        public string LoginName
        {
            get { return _loginName; }
            set
            {
                _loginName = value;
                RaisePropertyChanged(() => LoginName);
            }
        }

        private string _password;
        public string Password
        {
            get { return _password; }
            set
            {
                _password = value;
                RaisePropertyChanged(() => Password);
            }
        }

        private bool _rememberLogin;
        public bool RememberLogin
        {
            get { return _rememberLogin; }
            set
            {
                _rememberLogin = value;
                RaisePropertyChanged(() => RememberLogin);
            }
        }

        private List<string> _apiServiceList;
        public List<string> ApiServiceList
        {
            get { return _apiServiceList; }
            set
            {
                _apiServiceList = value;
                RaisePropertyChanged(() => ApiServiceList);
            }
        }

        private string _selectedApiService;
        public string SelectedApiService
        {
            get { return _selectedApiService; }
            set
            {
                _selectedApiService = value;
                SetDemoUser();
                RaisePropertyChanged(() => SelectedApiService);
            }
        }

        private void SetDemoUser()
        {
            if (_selectedApiService == ApiServiceTypes.Demo.ToString())
            {
                LoginName = Constants.DemoUserLogin;
                Password = Constants.DemoUserPassword;
            }
            else
            {
                LoginName = string.Empty;
                Password = string.Empty;
            }
        }
    }
}
