using System;
using System.Collections.Generic;
using Xamarin.Forms;

using System.Linq;
using Reactive.Bindings;
using System.Runtime;

namespace XmWeb
{
	public partial class HomePage : ContentPage
	{
		public HomePage ()
		{
			InitializeComponent ();

			var vm = new ViewModel {
				Url = "https://www.apple.com/"
			};
			this.BindingContext = vm;
			MainView.Navigating += (object sender, WebNavigatingEventArgs e) => {
				System.Diagnostics.Debug.WriteLine($"{e.Url} / {vm.Url}");
				e.Cancel = (e.Url != vm.Url );			// prohibit navigation
			};
		}


		public class ViewModel
		{
			public string Url { get; set; }

			public ReactiveProperty<string> Comment {get; private set; } 
			= new ReactiveProperty<string>("");

			public ViewModel()
			{
				this.Comment.Value ="....";
				this.Comment.Subscribe( s =>{
					System.Diagnostics.Debug.WriteLine($"{Url}: Command: {s}");
				});
			}
		}
	}
}

