using System;
using Xamarin.Forms;


[assembly: Dependency(typeof(XmWeb.iOS.BaseUrl))]
namespace XmWeb.iOS
{
	public class BaseUrl : XmWeb.IBaseUrl
	{
		public string Get(){
			return Foundation.NSBundle.MainBundle.BundlePath;
		}

	}
}

