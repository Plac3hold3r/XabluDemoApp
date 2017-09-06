using MvvmCross.Core.ViewModels;
using System.Threading.Tasks;
using Acr.UserDialogs;

namespace XabluAppTest.Core.ViewModels
{
    public class SecondViewModel : BaseViewModel
    {
        public SecondViewModel()
        {
        }

        public async Task Init()
        {
        }

        public override void SwipeView(string swipeText)
        {
            if (swipeText.Equals("RIGHT"))
            {
                Close(this);
                UserDialogs.Instance.Toast("RIGHT SWIPE!");
                ShowViewModel<FirstViewModel>();
            }

            if (swipeText.Equals("LEFT"))
            {
                Close(this);
                UserDialogs.Instance.Toast("LEFT SWIPE!");
                ShowViewModel<ThirdViewModel>();
            }
        }
    }
}
