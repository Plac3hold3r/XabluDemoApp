using System;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using EggsToGo;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Binding.Droid.BindingContext;
using MvvmCross.Binding.Droid.Views;
using MvvmCross.Droid.Support.V4;
using MvvmCross.Droid.Views.Attributes;
using OxyPlot.Xamarin.Android;
using XabluAppTest.Core.ViewModels;
using XabluAppTest.Droid.Activities;
using XabluAppTest.Droid.Custom;
using FragmentTransaction = Android.Support.V4.App.FragmentTransaction;

namespace XabluAppTest.Droid.Fragments
{
    [MvxFragmentPresentation(typeof(MainViewModel), Resource.Id.content_frame, true)]
    public class FirstFragment : BaseFragment<FirstViewModel>, View.IOnTouchListener
    {
        private Easter _easter;
        protected override int FragmentId => Resource.Layout.fragment_first;

        private float _mPosX = 0;
        private float _mCurPosX = 0;
        private float _mPosY = 0;
        private float _mCurPosY = 0;

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            var view = base.OnCreateView(inflater, container, savedInstanceState);

            var plotView = view.FindViewById<PlotView>(Resource.Id.oxyplotModel);
            var bindset = this.CreateBindingSet<FirstFragment, FirstViewModel>();
            bindset.Bind(plotView).For(q => q.Model).To(vm => vm.Model);
            bindset.Apply();

            view.SetOnTouchListener(this);

            var smartListView = view.FindViewById<SmartListView>(Resource.Id.testListView);
            //smartListView.FirstFragment = this;
            smartListView.Test = this;

            //_easter = new Easter(new KonamiCode());

            //var easyEgg = new CustomEgg("Easy")
            //    .WatchForSequence(Command.SwipeLeft(), Command.SwipeRight());
            //_easter = new Easter(easyEgg);
            //_easter.CommandDetected += cmd => DoSwipe(cmd.Value);

            //var coreLayout = view.FindViewById<LinearLayout>(Resource.Id.coreLayout);
            //coreLayout?.SetOnTouchListener(this);

            //var model = view.FindViewById<PlotView>(Resource.Id.oxyplotModel);
            //var listView = view.FindViewById<MvxListView>(Resource.Id.testListView);
            //model?.SetOnTouchListener(this);
            //listView?.SetOnTouchListener(this);



            return view;
        }

        public void DoSwipe(string swipeText)
        {
            if (swipeText.Equals("LEFT"))
            {
                FragmentManager.BeginTransaction()
                    .SetCustomAnimations(Resource.Animator.slide_from_right, Resource.Animator.slide_to_left)
                    .Replace(Resource.Id.content_frame, SecondFragment.NewInstance(null))
                    .Commit();
                
            }

            if (swipeText.Equals("RIGHT"))
            {
                FragmentManager.BeginTransaction()
                    .SetCustomAnimations(Resource.Animator.slide_from_left, Resource.Animator.slide_to_right)
                    .Replace(Resource.Id.content_frame, ThirdFragment.NewInstance(null))
                    .Commit();
            }

            ViewModel.SwipeView(swipeText);
        }
        

        public bool OnTouch(View v, MotionEvent e)
        {
            //_easter.OnTouchEvent(e);

            switch (e.Action)
            {
                case MotionEventActions.Down:
                    _mPosX = e.GetX();
                    _mCurPosX = _mPosX;
                    _mPosY = e.GetY();
                    _mCurPosY = _mPosY;
                    break;
                case MotionEventActions.Move:
                    _mCurPosX = e.GetX();
                    _mCurPosY = e.GetY();

                    float xDistance = Math.Abs(_mCurPosX - _mPosX);
                    float yDistance = Math.Abs(_mCurPosY - _mPosY);
                    if (xDistance > yDistance && _mCurPosX - _mPosX > 0)//Swip Right
                    {
                        DoSwipe("RIGHT");
                    }
                    else if (xDistance > yDistance && _mCurPosX - _mPosX < 0)//Swip Left
                    {
                        DoSwipe("LEFT");
                    }
                    break;
                default:
                    break;
            }
            return true;
        }
    }
}
