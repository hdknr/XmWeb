using System;
using Xamarin.Forms;


[assembly: Dependency(typeof(XmWeb.Droid.BaseUrl))]
namespace XmWeb.Droid
{
	public class BaseUrl : XmWeb.IBaseUrl
	{
		public string Get(){
			// http://www.buildinsider.net/mobile/xamarintips/0046/
			return "file:///android_asset/Content/"; //;
		}

	}
}
	