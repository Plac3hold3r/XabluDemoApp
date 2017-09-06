using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Acr.UserDialogs;
using MvvmCross.Platform;
using MvvmCross.Platform.Platform;
using MvvmCross.Plugins.File;
using XabluAppTest.Core.Models;

namespace XabluAppTest.Core.CoreEngine
{
    public static class FileEngine
    {
        public static void Read()
        {
            UserDialogs.Instance.ShowLoading("Loading", MaskType.Black);

            var fileStore = Mvx.Resolve<IMvxFileStore>();
            var jsonConverter = Mvx.Resolve<IMvxJsonConverter>();

            //var shopList = new List<Shop>();
            //shopList.Add(new Shop()
            //{
            //    Id = 1,
            //    Name = "KV",
            //    Text = "aaaa"
            //});

            //shopList.Add(new Shop()
            //{
            //    Id = 2,
            //    Name = "PH",
            //    Text = "bbbb"
            //});

            //shopList.Add(new Shop()
            //{
            //    Id = 3,
            //    Name = "OS",
            //    Text = "cccc"
            //});

            //var json = jsonConverter.SerializeObject(shopList);
            var path = "DemoData/shops.json";

            var loader = Mvx.Resolve<IMvxResourceLoader>();
            if (loader.ResourceExists(path))
            {
                var contents = loader.GetTextResource(path);

                if (!string.IsNullOrEmpty(contents))
                {
                    var shops = jsonConverter.DeserializeObject<List<Shop>>(contents);
                }
                else
                {
                    UserDialogs.Instance.Toast("Data not found!");
                }
            }
            else
            {
                UserDialogs.Instance.Toast("Data not found!");
            }

            UserDialogs.Instance.HideLoading();
        }
    }
}
