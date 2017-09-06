using System;
using MvvmCross.Core.ViewModels;
using System.Threading.Tasks;
using OxyPlot;
using XabluAppTest.Core.CoreEngine;
using XabluAppTest.Core.Models;

namespace XabluAppTest.Core.ViewModels
{
    public class AnotherViewModel : BaseViewModel
    {
        public AnotherViewModel()
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
    }
}
