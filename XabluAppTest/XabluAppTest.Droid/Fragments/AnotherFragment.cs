using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Binding.Droid.BindingContext;
using MvvmCross.Droid.Shared.Attributes;
using OxyPlot.Xamarin.Android;
using XabluAppTest.Core.ViewModels;

namespace XabluAppTest.Droid.Fragments
{
    [MvxFragment(typeof(MainViewModel), Resource.Id.content_frame, true)]
    public class AnotherFragment : BaseFragment<AnotherViewModel>
    {
        private View _view;
        protected override int FragmentId => Resource.Layout.fragment_another;

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            var ignore = base.OnCreateView(inflater, container, savedInstanceState);
            _view = this.BindingInflate(FragmentId, null);

            var plotView = _view.FindViewById<PlotView>(Resource.Id.oxyplotModel);

            var bindset = this.CreateBindingSet<AnotherFragment, AnotherViewModel>();
            bindset.Bind(plotView).For(q => q.Model).To(vm => vm.Model);
            bindset.Apply();

            return _view;
        }
    }
}