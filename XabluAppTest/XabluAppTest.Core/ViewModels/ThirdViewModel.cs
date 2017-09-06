using MvvmCross.Core.ViewModels;
using System.Threading.Tasks;
using Acr.UserDialogs;

namespace XabluAppTest.Core.ViewModels
{
    public class ThirdViewModel : BaseViewModel
    {
        public ThirdViewModel()
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
                ShowViewModel<SecondViewModel>();
            }

            if (swipeText.Equals("LEFT"))
            {
                UserDialogs.Instance.Toast("LEFT SWIPE!");
            }
        }
    }
}
