using ColorGame.Services;
using System;
using ColorGame.Droid;

[assembly: Xamarin.Forms.Dependency(typeof(DeviceInfoService))]
namespace ColorGame.Droid
{
    public class DeviceInfoService : IDeviceInfoService
    {
        public string GetDeviceModel()
        {
            return Android.OS.Build.Model;
        }
    }
}