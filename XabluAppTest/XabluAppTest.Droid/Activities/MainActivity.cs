using System;
using System.Threading.Tasks;
using Acr.UserDialogs;
using Android.App;
using Android.Content.PM;
using Android.OS;
using Android.Support.V4.View;
using Android.Support.V4.Widget;
using Android.Views;
using Android.Views.InputMethods;
using Android.Widget;
using EggsToGo;
using XabluAppTest.Core.ViewModels;
using MvvmCross.Droid.Support.V7.AppCompat;
using MvvmCross.Platform;
using MvvmCross.Platform.Droid.Platform;

namespace XabluAppTest.Droid.Activities
{
    [Activity(
        Label = "XabluAppTest.Droid",
        Icon = "@drawable/icon",
        Theme = "@style/AppTheme",
        LaunchMode = LaunchMode.SingleTop
    )]
    public class MainActivity : MvxCachingFragmentCompatActivity<MainViewModel>, INavigationActivity
    {
        public DrawerLayout Drawer { get; set; }

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            UserDialogs.Init(() => Mvx.Resolve<IMvxAndroidCurrentTopActivity>().Activity);

            AppDomain.CurrentDomain.UnhandledException += CurrentDomainOnUnhandledException;
            TaskScheduler.UnobservedTaskException += TaskSchedulerOnUnobservedTaskException;
            
            
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);
            
            Drawer = FindViewById<DrawerLayout>(Resource.Id.drawer_layout);

            if (savedInstanceState == null)
                ViewModel.ShowMenu();
        }

        private void Test()
        {
            var test = 5;
        }

        #region Task Schedular Exception

        private static void TaskSchedulerOnUnobservedTaskException(object sender, UnobservedTaskExceptionEventArgs unobservedTaskExceptionEventArgs)
        {
            var e = new Exception("TaskSchedulerOnUnobservedTaskException", unobservedTaskExceptionEventArgs.Exception);
            var test = e.Message;
        }

        #endregion

        #region Current Domain Exception

        private static void CurrentDomainOnUnhandledException(object sender, UnhandledExceptionEventArgs unhandledExceptionEventArgs)
        {
            var e = new Exception("CurrentDomainOnUnhandledException", unhandledExceptionEventArgs.ExceptionObject as Exception);
            var test = e.Message;
        }

        #endregion

        public override void OnBeforeFragmentChanging(MvvmCross.Droid.Shared.Caching.IMvxCachedFragmentInfo fragmentInfo, Android.Support.V4.App.FragmentTransaction transaction)
        {
            //if (fragmentInfo.Tag.Contains("FirstViewModel") || fragmentInfo.Tag.Contains("SecondViewModel") || fragmentInfo.Tag.Contains("ThirdViewModel"))
            //{
            //    transaction.SetCustomAnimations(
            //        Resource.Animation.abc_slide_in_bottom, Resource.Animation.abc_slide_out_bottom,
            //        Resource.Animation.abc_fade_in, Resource.Animation.abc_fade_out);
            //}
            //else
            //{
            //    transaction.SetCustomAnimations(
            //        Resource.Animation.abc_fade_in,
            //        Resource.Animation.abc_fade_out,
            //        Resource.Animation.abc_fade_in,
            //        Resource.Animation.abc_fade_out);
            //}

            transaction.SetCustomAnimations(
                Resource.Animation.abc_fade_in,
                Resource.Animation.abc_fade_out,
                Resource.Animation.abc_fade_in,
                Resource.Animation.abc_fade_out);

            //transaction.SetCustomAnimations(
            //    Resource.Animation.abc_slide_in_bottom, Resource.Animation.abc_slide_out_bottom,
            //    Resource.Animation.abc_fade_in, Resource.Animation.abc_fade_out);

            base.OnBeforeFragmentChanging(fragmentInfo, transaction);
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            switch (item.ItemId)
            {
                case Android.Resource.Id.Home:
                    Drawer.OpenDrawer(GravityCompat.Start);
                    return true;
            }
            return base.OnOptionsItemSelected(item);
        }

        public override void OnBackPressed()
        {
            if (Drawer != null && Drawer.IsDrawerOpen(GravityCompat.Start))
                Drawer.CloseDrawers();
            else
                Finish();
        }

        public void HideSoftKeyboard()
        {
            if (CurrentFocus == null) return;

            InputMethodManager inputMethodManager = (InputMethodManager)GetSystemService(InputMethodService);
            inputMethodManager.HideSoftInputFromWindow(CurrentFocus.WindowToken, 0);

            CurrentFocus.ClearFocus();
        }

        protected override void ShowFragment(string tag, int contentId, Bundle bundle, bool forceAddToBackStack = false, bool forceReplaceFragment = false)
        {
            base.ShowFragment(tag, contentId, bundle, forceAddToBackStack, true);
        }
    }

    public interface INavigationActivity
    {
        DrawerLayout Drawer { get; set; }
        void HideSoftKeyboard();
    }
}
