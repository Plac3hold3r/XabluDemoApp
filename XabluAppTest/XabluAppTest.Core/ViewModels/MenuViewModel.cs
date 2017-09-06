using MvvmCross.Core.ViewModels;

namespace XabluAppTest.Core.ViewModels
{
    public class MenuViewModel : BaseViewModel
    {
        public void Navigate<TViewModel>() where TViewModel : class, IMvxViewModel
        {
            ShowViewModel<TViewModel>();
        }

        public void Close()
        {
            Close(this);
        }
    }
}
