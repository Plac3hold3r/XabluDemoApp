using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Acr.UserDialogs;
using MvvmCross.Core.ViewModels;
using MvvmCross.Platform;
using MvvmCross.Plugins.Email;
using OxyPlot;
using OxyPlot.Axes;
using OxyPlot.Series;
using XabluAppTest.Core.CoreEngine;
using XabluAppTest.Core.Models;

namespace XabluAppTest.Core.ViewModels
{
    public class DashboardViewModel : BaseViewModel
    {
        public DashboardViewModel()
        {

        }

        public void Init()
        {
            _model = OxyPlotEngine.GetModel();
        }

        //private async void InitializeTest()
        //{
        //    UserDialogs.Instance.ShowLoading();
        //    await Task.Delay(3000);
        //    Test();
        //    //await Task.Run(() => CreateChart());
        //    UserDialogs.Instance.HideLoading();
        //}


        private async Task Test()
        {
            UserDialogs.Instance.ShowLoading("Loading Data...", MaskType.Black);
            
            await Task.Delay(2000).ContinueWith((task) => { UserDialogs.Instance.HideLoading(); });
            UserDialogs.Instance.Toast("Reload - Data was realoaded!");
            //await CreateModel().ContinueWith((task) => { UserDialogs.Instance.HideLoading(); });

            //Task.Run(() => CreateChart()).ContinueWith((task) => { UserDialogs.Instance.HideLoading(); });
        }
        //CreateChart().ContinueWith((task) => { UserDialogs.Instance.HideLoading(); });


        private void CreateModel()
        {
            
            var plotModel = new PlotModel { Title = "OxyPlot Demo" };

            //plotModel.InvalidatePlot(true);
            //Model.InvalidatePlot(true);

            plotModel.Axes.Add(new LinearAxis { Position = AxisPosition.Bottom });
            plotModel.Axes.Add(new LinearAxis { Position = AxisPosition.Left, Maximum = 10, Minimum = 0 });

            var series1 = new LineSeries
            {
                MarkerType = MarkerType.Circle,
                MarkerSize = 4,
                MarkerStroke = OxyColors.White
            };

            series1.Points.Add(new DataPoint(0.0, 6.0));
            series1.Points.Add(new DataPoint(1.4, 2.1));
            series1.Points.Add(new DataPoint(2.0, 4.2));
            series1.Points.Add(new DataPoint(3.3, 2.3));
            series1.Points.Add(new DataPoint(4.7, 7.4));
            series1.Points.Add(new DataPoint(6.0, 6.2));
            series1.Points.Add(new DataPoint(8.9, 8.9));

            plotModel.Series.Add(series1);

            _model = plotModel;
        }
    
        private void InitializeItems()
        {
            var items = new List<DashboardItem>();

            var item1 = new DashboardItem()
            {
                Name = "Test 1",
                Image = "image",
                Type = "Type1"
            };

            var item2 = new DashboardItem()
            {
                Name = "Test 2",
                Image = "image",
                Type = "Type2"
            };

            var item3 = new DashboardItem()
            {
                Name = "Test 3",
                Image = "image",
                Type = "Type3"
            };

            items.Add(item1); 
            items.Add(item2);
            items.Add(item3);

            _items = items;
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

        private List<DashboardItem> _items;

        public List<DashboardItem> Items
        {
            get { return _items; }
            set
            {
                _items = value;
                RaisePropertyChanged(() => Items);
            }
        }

        private DashboardItem _selectedItem;
        public DashboardItem SelectedItem
        {
            get { return _selectedItem; }
            set
            {
                _selectedItem = value;
            }
        }

        private ICommand _showItem;
        public ICommand ShowItem
        {
            get
            {
                _showItem = _showItem ?? new MvxCommand<DashboardItem>(DoShowItemCommand);
                return _showItem;
            }
        }

        private void DoShowItemCommand(DashboardItem item)
        {
            ShowViewModel<DashboardViewModel>();
        }
    }
}
