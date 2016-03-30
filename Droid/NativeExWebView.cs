using System;
using Xamarin.Forms;

[assembly: ExportRenderer (
	typeof (XmWeb.ExWebView), typeof (XmWeb.Droid.NativeExWebView))]
namespace XmWeb.Droid
{
	public class NativeExWebView :
		Xamarin.Forms.Platform.Android.WebViewRenderer
	{
		public NativeExWebView ()
		{
		}

	}
}
