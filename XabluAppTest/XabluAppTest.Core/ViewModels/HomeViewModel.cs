using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Acr.UserDialogs;
using MvvmCross.Core.ViewModels;
using MvvmCross.Platform;
using MvvmCross.Plugins.WebBrowser;
using XabluAppTest.Core.CoreEngine;
using XabluAppTest.Core.Enums;
using XabluAppTest.Core.Interfaces;
using XabluAppTest.Core.Models;
using XabluAppTest.Core.Services;

namespace XabluAppTest.Core.ViewModels
{
    public class HomeViewModel : BaseViewModel
    {
        private readonly ISessionInfo _session;
        private List<Shop> _tempList = new List<Shop>();
        public HomeViewModel()
        {
            _session = Mvx.Resolve<ISessionInfo>();
        }

        public void Init()
        {

        }

        public override async Task Initialize()
        {
            await InitializeShops();
        }

        public override void Appeared()
        {
        }
        
        private async Task InitializeShops()
        {
            await Task.Delay(500);
            UserDialogs.Instance.ShowLoading("Loading...", MaskType.Black);

            if (_session.ApiService == ApiServiceTypes.Demo)
            {
                await Task.Delay(1000);
                //var demo = new DemoDataEngine();
                //var shops = demo.GetShops();
                var shops = new List<Shop>
                {
                    new Shop() {Id = 1, Name = "Shop - 1", Text = "Shop Text 1"},
                    new Shop() {Id = 2, Name = "Shop - 2", Text = "Shop Text 2"},
                    new Shop() {Id = 3, Name = "Shop - 3", Text = "Shop Text 3"}
                };

                var tempList = new MvxObservableCollection<Shop>();
                foreach (var item in shops)
                {
                    tempList.Add(item);
                }
                Shops.ReplaceWith(tempList);
            }
            else
            {
                //var shopService = new ShopService();
                //var shops = await shopService.GetShops();

                var shops = new List<Shop>
                {
                    new Shop() {Id = 1, Name = "Shop - 1", Text = "Shop Text 1"},
                    new Shop() {Id = 2, Name = "Shop - 2", Text = "Shop Text 2"},
                    new Shop() {Id = 3, Name = "Shop - 3", Text = "Shop Text 3"},
                    new Shop() {Id = 4, Name = "Shop - 4", Text = "Shop Text 4"},
                    new Shop() {Id = 5, Name = "Shop - 5", Text = "Shop Text 5"}
                };

                var tempList = new MvxObservableCollection<Shop>();
                foreach (var item in shops)
                {
                    tempList.Add(item);
                }
                Shops.ReplaceWith(tempList);
            }

            // Set First Shop Detail Visibility true
            //if (Shops.Any())
            //{
            //    var first = Shops.FirstOrDefault();
            //    if (first != null)
            //    {
            //        first.IsDetailVisible = true;
            //    }
            //}

            //LastUpdate = DateTime.Now;
            //InitializeTotalSales();

            UserDialogs.Instance.HideLoading();
        }

        private MvxObservableCollection<Shop> _shops = new MvxObservableCollection<Shop>();
        public MvxObservableCollection<Shop> Shops
        {
            get { return _shops; }
            set
            {
                _shops = value;
                RaisePropertyChanged(() => Shops);
            }
        }

        public async Task ExecuteRefreshAsync()
        {
            UserDialogs.Instance.ShowLoading("Loading...", MaskType.Black);
            await InitializeShops();
            UserDialogs.Instance.HideLoading();
        }

        private IMvxCommand _showFirstCommand;
        public IMvxCommand ShowFirstCommand
        {
            get
            {
                _showFirstCommand = _showFirstCommand ?? new MvxCommand(() => ShowViewModel<FirstViewModel>());
                return _showFirstCommand;
            }
        }

        private IMvxCommand _showSecondCommand;
        public IMvxCommand ShowSecondCommand
        {
            get
            {
                _showSecondCommand = _showSecondCommand ?? new MvxCommand(() => ShowViewModel<SecondViewModel>());
                return _showSecondCommand;
            }
        }

        private IMvxCommand _showThirdCommand;
        public IMvxCommand ShowThirdCommand
        {
            get
            {
                _showThirdCommand = _showThirdCommand ?? new MvxCommand(() => ShowViewModel<ThirdViewModel>());
                return _showThirdCommand;
            }
        }


        private IMvxCommand _showAnotherCommand;
        public IMvxCommand ShowAnotherCommand
        {
            get
            {
                _showAnotherCommand = _showAnotherCommand ?? new MvxCommand(() => ShowViewModel<AnotherViewModel>());
                return _showAnotherCommand;
            }
        }

    }
}
