using System;
using Foundation;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Core.ViewModels;
using MvvmCross.iOS.Support.Views;
using MvvmCross.iOS.Views;
using UIKit;

namespace XabluAppTest.iOS.Views
{
    public class BaseViewController<TViewModel> : MvxBaseViewController<TViewModel> where TViewModel : MvxViewModel
    {
        public BaseViewController() : base()
        {

        }

        protected BaseViewController(string nibName, NSBundle bundle) : base(nibName, bundle)
        {
        }

        public BaseViewController(IntPtr handle) : base(handle)
        {
        }

        public override bool HandlesKeyboardNotifications() => true;

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            this.BindLanguage(NavigationItem, "Title", "title");

            NavigationController.NavigationBar.Translucent = true;
            NavigationController.NavigationBar.BarTintColor = UIColor.FromRGB(0, 32, 73);

            NavigationController.NavigationBar.TintColor = UIColor.FromRGB(255, 255, 255);

            // setup the keyboard handling
            InitKeyboardHandling();
        }
    }
}