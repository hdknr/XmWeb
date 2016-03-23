using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace XmWeb
{
	public interface IBaseUrl { string Get(); } 

	public partial class LocalPage : ContentPage
	{
		public LocalPage ()
		{
			InitializeComponent ();

			System.Diagnostics.Debug.WriteLine (DependencyService.Get<IBaseUrl> ().Get ());
			var html = new HtmlWebViewSource {
				Html = @"
<html><head><link rel='stylesheet' href='css/my.css'>
</head><body><h1>TEST</h1><img src='img/favicon.ico'>TEST</body></html>",
				BaseUrl = DependencyService.Get<IBaseUrl> ().Get ()
			};
			MainView.Source = html;
		}
	}
}

