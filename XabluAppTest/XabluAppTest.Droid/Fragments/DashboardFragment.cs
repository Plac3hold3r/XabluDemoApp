using System;
using System.Threading.Tasks;
using Android.OS;
using Android.Views;
using Android.Widget;
using EggsToGo;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Binding.Droid.BindingContext;
using MvvmCross.Droid.Views.Attributes;
using XabluAppTest.Core.ViewModels;
using OxyPlot.Xamarin.Android;

namespace XabluAppTest.Droid.Fragments
{
    [MvxFragmentPresentation(typeof(MainViewModel), Resource.Id.content_frame, true)]
    public class DashboardFragment : BaseFragment<DashboardViewModel>
    {
        protected override int FragmentId => Resource.Layout.fragment_dashboard;

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            var view = base.OnCreateView(inflater, container, savedInstanceState);

            var plotView = view.FindViewById<PlotView>(Resource.Id.plotView);

            var bindset = this.CreateBindingSet<DashboardFragment, DashboardViewModel>();
            bindset.Bind(plotView).For(q => q.Model).To(vm => vm.Model);
            bindset.Apply();

            return view;
        }
    }
}