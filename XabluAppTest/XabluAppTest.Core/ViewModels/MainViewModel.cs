using MvvmCross.Core.ViewModels;

namespace XabluAppTest.Core.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        public void ShowMenu()
        {
            ShowViewModel<MenuViewModel>();
        }
    }
}
