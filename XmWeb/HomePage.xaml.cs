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

			this.BindingContext = new ViewModel {
				Url = "https://www.apple.com"
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

