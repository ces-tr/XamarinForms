using System;
using System.Threading.Tasks;
using Xamarin.Forms;
using NodaTime;

namespace XamTest
{
	public class TimezoneListPage : ContentPage
	{
		ListView _timezonesListView;
		UserDTO user;
		Button btnDelete,btnAdd;
		TimeZoneVM tzviewModel;

		public TimezoneListPage (UserDTO userdto)
		{
			user = userdto;
			this.Content = new Label { 
				HorizontalOptions = LayoutOptions.CenterAndExpand,
				VerticalOptions = LayoutOptions.CenterAndExpand

			};

			//Task.Run( async () => await Init ());
			Init ();

		}


		private async Task Init ()
		{
			_timezonesListView = new ListView { 
				HorizontalOptions = LayoutOptions.FillAndExpand,
				VerticalOptions = LayoutOptions.FillAndExpand,
			};

			var cell = new DataTemplate (typeof(TextCell));
			cell.SetBinding (TextCell.TextProperty, "Name");
			cell.SetBinding (TextCell.DetailProperty, new Binding (path: "GMT", stringFormat: "GMT {0}"));
			//cell.SetBinding (TextCell.TextProperty, "GMT");

			_timezonesListView.ItemTemplate = cell;

			tzviewModel = new TimeZoneVM ();
			//await tzviewModel.getTz (this.user.objectId);
			_timezonesListView.ItemsSource = tzviewModel.Timezones;

			_timezonesListView.ItemSelected += (sender, e) => {
				//((ListView)sender).SelectedItem = null;
				var tzdto=	(TimezoneDTO)((ListView)sender).SelectedItem;
				DisplayAlert ("Alert", "Su id es"+tzdto.objectId,"OK");
			};

			btnDelete = new Button {
				Text = "Delete",
				Font = Font.SystemFontOfSize(NamedSize.Large),
				BorderWidth = 1,
				HorizontalOptions = LayoutOptions.Center,
				VerticalOptions = LayoutOptions.CenterAndExpand,
			};
			btnDelete.Clicked += async (sender, e) => {
				try {
					var item =_timezonesListView.SelectedItem;
					var tzdto=	(TimezoneDTO)item;
					var tzvm= new TimeZoneVM();
					 await Task.Run( async () => await tzviewModel.deleteTz(tzdto.objectId.ToString()));
					await tzviewModel.getTz (this.user.objectId);
					_timezonesListView.ItemsSource = tzviewModel.Timezones;


					//DisplayAlert ("Alert", "Su id es "+tzdto.objectId.ToString(),"OK");
				}
				catch (Exception){}
			};
			btnAdd = new Button {
				Text = "Add",
				Font = Font.SystemFontOfSize(NamedSize.Large),
				BorderWidth = 1,
				HorizontalOptions = LayoutOptions.Center,
				VerticalOptions = LayoutOptions.CenterAndExpand,
			};

			btnAdd.Clicked += async (sender, e) => {
				//await Navigation.PushAsync (new TimezonePage ());
				await Navigation.PushAsync (new TimezonePage (this.user));
			};
//			var toppanel = new StackLayout{
//				Orientation="Horizontal" ,
//				VerticalOptions="Start",
//				Children = { 
//					btnDelete 
//				}
//			};

			this.Content = new StackLayout {
				VerticalOptions = LayoutOptions.FillAndExpand,
				Padding = new Thickness (
					left: 0, 
					right: 0, 
					bottom: 0, 
					top: Device.OnPlatform (iOS: 20, Android: 0, WinPhone: 0)),
				Children = { 
					new StackLayout{
						Orientation= StackOrientation.Horizontal ,
						VerticalOptions=LayoutOptions.Start,
						HeightRequest=50,
						Children = { 
							btnDelete ,btnAdd
						}
					},
					_timezonesListView 
				}
			};
		}

		protected override async void OnAppearing()
		{
			//DisplayAlert ("Alert", "Resuming ","OK");
			await tzviewModel.getTz (this.user.objectId);
			_timezonesListView.ItemsSource = tzviewModel.Timezones;

		}

	}
}

