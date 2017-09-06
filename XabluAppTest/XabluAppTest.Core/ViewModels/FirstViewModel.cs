using MvvmCross.Core.ViewModels;
using System.Threading.Tasks;
using Acr.UserDialogs;

namespace XabluAppTest.Core.ViewModels
{
    public class FirstViewModel : BaseViewModel
    {
        public FirstViewModel()
        {
        }

        public async Task Init()
        {
        }

        public override void SwipeView(string swipeText)
        {
            if (swipeText.Equals("RIGHT"))
            {
                UserDialogs.Instance.Toast("RIGHT SWIPE!");
            }

            if (swipeText.Equals("LEFT"))
            {
                Close(this);
                UserDialogs.Instance.Toast("LEFT SWIPE!");
                ShowViewModel<SecondViewModel>();
            }
        }
    }
}
