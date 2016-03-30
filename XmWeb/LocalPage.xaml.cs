using System;
using System.Collections.Generic;

using Xamarin.Forms;
using PCLStorage;
using System.Reactive.Linq;
using System.Reactive;
using System.Reactive.Threading.Tasks;

namespace XmWeb
{
	public interface IBaseUrl { string Get(); } 

	public partial class LocalPage : ContentPage
	{
		public LocalPage ()
		{
			InitializeComponent ();

			CreateFolder ();

			System.Diagnostics.Debug.WriteLine (DependencyService.Get<IBaseUrl> ().Get ());
		
		}

		void CreateFolder()
		{
			var rootFolder = FileSystem.Current.LocalStorage;
			rootFolder.CreateFolderAsync(
				"static",CreationCollisionOption.OpenIfExists)
				.ToObservable().Subscribe(ifolder =>{ InitHtml(ifolder.Path);});		
		}

		void InitHtml(string base_dir)
		{
			var html = new HtmlWebViewSource {
				Html = @"
<html><head><link rel='stylesheet' href='css/my.css'>
</head><body><h1>TEST</h1><img src='img/favicon.ico'>TEST</body></html>",
				BaseUrl = base_dir
			};
			MainView.Source = html;
		}
	}
}

