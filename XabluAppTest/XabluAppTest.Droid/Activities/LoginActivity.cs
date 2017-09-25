using System;
using Acr.UserDialogs;
using Android;
using Android.App;
using Android.Content.PM;
using Android.OS;
using Android.Views;
using Android.Widget;
using MvvmCross.Binding.Droid.BindingContext;
using MvvmCross.Droid.Support.V4;
using MvvmCross.Droid.Views;
using MvvmCross.Platform;
using MvvmCross.Platform.Droid.Platform;
using XabluAppTest.Core.ViewModels;
using Resource = XabluAppTest.Droid.Resource;

namespace MyMarkeeta.Droid.Activities
{
    [Activity(
        Label = "Moje Markeeta",
        Icon = "@drawable/icon",
        Theme = "@style/AppTheme",
        LaunchMode = LaunchMode.SingleTop,
        NoHistory = true,
        WindowSoftInputMode = SoftInput.StateAlwaysHidden
    )]
    public class LoginActivity : MvxActivity<LoginViewModel>
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_login);
        }

        public override void OnBackPressed()
        {
            bool isLoggedIn = false;
            // This prevents a user from being able to hit the back button and leave the login page.
            if (!isLoggedIn) return;

            base.OnBackPressed();
        }

    }
}