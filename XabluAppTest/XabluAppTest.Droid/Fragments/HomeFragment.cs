using System;
using System.ComponentModel;
using System.Threading.Tasks;
using Android.OS;
using Android.Support.V4.Widget;
using Android.Views;
using XabluAppTest.Core.ViewModels;
using MvvmCross.Droid.Views.Attributes;

namespace XabluAppTest.Droid.Fragments
{
    [MvxFragmentPresentation(typeof(MainViewModel), Resource.Id.content_frame, true)]
    public class HomeFragment : BaseFragment<HomeViewModel>
    {
        protected override int FragmentId => Resource.Layout.fragment_home;
        private SwipeRefreshLayout _shopsSwipeRefreshLayout;

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            var view = base.OnCreateView(inflater, container, savedInstanceState);

            //Button button = view.FindViewById<Button>(Resource.Id.btnClick);
            //button.Click += delegate
            //{
            //    //UserDialogs.Instance.Toast("Test !!");
            //    throw new DivideByZeroException("Divide By Zero Exception");
            //    //var infoMessageReporter = Mvx.Resolve<IInfoMessageReporter>();
            //    //infoMessageReporter.ShowInfoMessage(InfoMessageTypes.Save, "Test Test");
            //};

            _shopsSwipeRefreshLayout = view.FindViewById<SwipeRefreshLayout>(Resource.Id.shopsSwipeRefreshLayout);
            if (_shopsSwipeRefreshLayout != null)
            {
                _shopsSwipeRefreshLayout.Refresh += RefreshLayout;
            }

            return view;
        }

        private void RefreshLayout(object sender, EventArgs e)
        {
            BackgroundWorker worker = new BackgroundWorker();
            worker.DoWork += WorkerDoWork;
            worker.RunWorkerCompleted += WorkerCompleted;
            worker.RunWorkerAsync();
        }

        private void WorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            _shopsSwipeRefreshLayout.Refreshing = false;
        }

        private void WorkerDoWork(object sender, DoWorkEventArgs e)
        {
            Task.Run(ViewModel.ExecuteRefreshAsync);
        }
    }
}