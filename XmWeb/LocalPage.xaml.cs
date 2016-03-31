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

			MainView.Source =  CurrentPage(new HomePageData(), base_dir) ;
			var class_name = MainView.GetType ().FullName;
			System.Diagnostics.Debug.Assert (class_name == "XmWeb.ExWebView");


			MainView.Navigating  += (object sender, WebNavigatingEventArgs e) => {
				var u = new System.Uri(e.Url);
				System.Diagnostics.Debug.WriteLine(
					$"{e.NavigationEvent} : {u.Query}");
				if( e.NavigationEvent == WebNavigationEvent.NewPage ){	
					
					e.Cancel = false;
					return;
				}		
				MainView.Source = CurrentPage(new HomePageData(), base_dir);
			};
		}

		public HtmlWebViewSource CurrentPage(HomePageData data, string base_dir){
			return new HtmlWebViewSource {
				Html = (new HoemPage{Model = data}).GenerateString(),
				BaseUrl = base_dir,
			};

		}
	}

	public class HomePageData
	{
		public System.DateTime  Now  {get { return System.DateTime.Now ; }}
		public string Title { get; set; } = "Hello";
	}
}

