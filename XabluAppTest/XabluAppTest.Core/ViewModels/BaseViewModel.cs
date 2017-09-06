using System;
using System.Windows.Input;
using MvvmCross.Core.ViewModels;
using MvvmCross.Localization;
using MvvmCross.Platform;

namespace XabluAppTest.Core.ViewModels
{
    public class BaseViewModel : MvxViewModel
    {
        public IMvxTextProvider TextProvider { get; }

        public BaseViewModel()
        {
            TextProvider = Mvx.Resolve<IMvxTextProvider>();
        }

        public virtual string Title => TextProvider.GetText(Constants.LocalizationNamespace, this.GetType().Name, "title");

        private bool _isLoading = false;

        public bool IsLoading
        {
            get { return _isLoading; }
            set
            {
                SetProperty(ref _isLoading, value);
            }
        }

        private bool isRefreshing;

        public virtual bool IsRefreshing
        {
            get { return isRefreshing; }
            set
            {
                SetProperty(ref isRefreshing, value);
            }
        }

        public IMvxLanguageBinder TextSource
        {
            get { return new MvxLanguageBinder(Constants.LocalizationNamespace, GetType().Name); }
        }

        public virtual void SwipeView(string swipeText)
        {

        }

        private ICommand _backCommand;
        public ICommand BackCommand
        {
            get
            {
                _backCommand = _backCommand ?? new MvxCommand(ExecuteBack);
                return _backCommand;
            }
        }

        private void ExecuteBack()
        {
            Close(this);
        }
    }
}
