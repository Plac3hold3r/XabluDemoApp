using System;
using MvvmCross.Core.ViewModels;
using System.Threading.Tasks;
using Acr.UserDialogs;
using OxyPlot;
using XabluAppTest.Core.CoreEngine;
using XabluAppTest.Core.Models;

namespace XabluAppTest.Core.ViewModels
{
    public class FirstViewModel : BaseViewModel
    {
        public FirstViewModel()
        {
        }

        public async Task Init()
        {
            InitializeView();
        }

        private void InitializeView()
        {
            Model = OxyPlotEngine.GetModel();

            var list = new MvxObservableCollection<TestItem>();

            for (int i = 0; i < 25; i++)
            {
                list.Add(new TestItem()
                {
                    Name = $"Item Name - {i}",
                    Value = new Random(500000).Next()
                });
            }

            Items = list;
        }

        private MvxObservableCollection<TestItem> _items;
        public MvxObservableCollection<TestItem> Items
        {
            get { return _items; }
            set
            {
                _items = value;
                RaisePropertyChanged(() => _items);
            }
        }

        private PlotModel _model;
        public PlotModel Model
        {
            get { return _model; }
            set
            {
                _model = value;
                RaisePropertyChanged(() => Model);
            }
        }

        public override void SwipeView(string swipeText)
        {
            if (swipeText.Equals("RIGHT"))
            {
                Close(this);
                UserDialogs.Instance.Toast("RIGHT SWIPE!");
                ShowViewModel<ThirdViewModel>();
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
