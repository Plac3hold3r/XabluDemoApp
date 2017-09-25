using System;
using System.Threading.Tasks;
using Android.App;
using Android.Content.PM;
using Android.Graphics;
using Android.OS;
using Android.Views.Animations;
using Android.Widget;
using MvvmCross.Droid.Views;

namespace XabluAppTest.Droid
{
    [Activity(
        Label = "XabluAppTest.Droid"
        ,MainLauncher = true
        , Icon = "@mipmap/ic_launcher"
        //, RoundIcon = "@mipmap/ic_launcher_round"
        , Theme = "@style/AppTheme.Splash"
        , NoHistory = true)]
    public class SplashScreen : MvxSplashScreenActivity
    {
        public SplashScreen()
            : base(Resource.Layout.SplashScreen)
        {
        }

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            AppDomain.CurrentDomain.UnhandledException += CurrentDomainOnUnhandledException;
            TaskScheduler.UnobservedTaskException += TaskSchedulerOnUnobservedTaskException;
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
    }
}
