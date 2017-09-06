using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using EggsToGo;
using MvvmCross.Binding.Droid.BindingContext;
using MvvmCross.Droid.Shared.Attributes;
using MvvmCross.Droid.Support.V4;
using XabluAppTest.Core.ViewModels;

namespace XabluAppTest.Droid.Fragments
{
    [MvxFragment(typeof(MainViewModel), Resource.Id.content_frame, true)]
    public class ThirdFragment : BaseFragment<ThirdViewModel>, View.IOnTouchListener
    {
        private Easter _easter;
        protected override int FragmentId => Resource.Layout.fragment_third;

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            var view = base.OnCreateView(inflater, container, savedInstanceState);

            _easter = new Easter(new KonamiCode());

            var easyEgg = new CustomEgg("Easy")
                .WatchForSequence(Command.SwipeLeft(), Command.SwipeRight());

            _easter = new Easter(easyEgg);
            //Event for when a egg/code has been detected (eg: Konami Code)
            //Easter.EggDetected += egg => DoSwipe(egg.Name);

            //You can see each individual command as it happens too
            _easter.CommandDetected += cmd => DoSwipe(cmd.Value);

            var coreLayout = view.FindViewById<LinearLayout>(Resource.Id.coreLayout);
            coreLayout?.SetOnTouchListener(this);

            return view;
        }

        private void DoSwipe(string swipeText)
        {

            if (swipeText.Equals("RIGHT"))
            {
                FragmentManager.BeginTransaction()
                    .SetCustomAnimations(Resource.Animator.slide_from_left, Resource.Animator.slide_to_right)
                    .Replace(Resource.Id.content_frame, SecondFragment.NewInstance(null))
                    .Commit();
            }

            ViewModel.SwipeView(swipeText);
        }

        public bool OnTouch(View v, MotionEvent e)
        {
            _easter.OnTouchEvent(e);
            return true;
        }
    }
}
