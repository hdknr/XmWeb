using System;
using Xamarin.Forms;

[assembly: ExportRenderer (
	typeof (XmWeb.ExWebView), typeof (XmWeb.iOS.NativeExWebView))]
namespace XmWeb.iOS
{
	public class NativeExWebView :
		Xamarin.Forms.Platform.iOS.WebViewRenderer
	{
		public NativeExWebView ()
		{
		}
	}
}

