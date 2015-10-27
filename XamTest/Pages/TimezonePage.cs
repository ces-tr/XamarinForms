using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Xamarin.Forms;

namespace XamTest
{
	public class TimezonePage : ContentPage
	{
		Entry txtname,txtcity;
		TimeZoneVM tzviewModel;
		ActivityIndicator indicator;
		Picker picker;
		UserDTO user;
		Dictionary<string, string> gmtvalues = new Dictionary<string, string>
		{
			{ "GMT-10", "-10" }, { "GMT-9", "-9" },
			{ "GMT-8", "-8" }, { "GMT-7", "-7" },
			{ "GMT-6", "-6" }, { "GMT-5", "-5"},
			{ "GMT-4", "-4" }, { "GMT-3", "-3"},
			{ "GMT-2", "-2" }, { "GMT-1", "-1" },
			{ "GMT0", "0"}, { "GMT+1", "1" },
			{ "GMT+2", "2"}, { "GMT+3", "3"},
			{ "GMT+4", "4"}, { "GMT+5", "5"},
			{ "GMT+6", "6"}, { "GMT+7", "7"},
			{ "GMT+8", "8"}, { "GMT+9", "9"},
			{ "GMT+10", "10"}

		};


		public TimezonePage (UserDTO userdto)
		{
			this.user = userdto;

			this.tzviewModel= new TimeZoneVM();
			var layout = new StackLayout
			{
				Orientation = StackOrientation.Vertical,
				Padding = 20
			};
			picker = new Picker
			{
				Title = "Gmt",
				VerticalOptions = LayoutOptions.CenterAndExpand
			};

			foreach (string gmtkey in gmtvalues.Keys)
			{
				picker.Items.Add(gmtkey);
			}
			picker.SelectedIndex = 10;

			Grid grid = new Grid
			{
				VerticalOptions = LayoutOptions.FillAndExpand,
				RowDefinitions = 
				{
					//new RowDefinition { Height = GridLength.Auto },
					//new RowDefinition { Height = new GridLength(1, GridUnitType.Star) },
					new RowDefinition { Height = new GridLength(40, GridUnitType.Absolute) },
					new RowDefinition { Height = new GridLength(40, GridUnitType.Absolute) },
					new RowDefinition { Height = new GridLength(40, GridUnitType.Absolute) },
					new RowDefinition { Height = new GridLength(40, GridUnitType.Absolute) }
				},
				ColumnDefinitions = 
				{
					new ColumnDefinition { Width = new GridLength(100, GridUnitType.Absolute) },
					new ColumnDefinition { Width = new GridLength(200, GridUnitType.Absolute) }
					//new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) },
					//new ColumnDefinition { Width = new GridLength(100, GridUnitType.Absolute) }
				}
				};
			
			grid.Children.Add(new Label { Text = "TZ Name" }, 0, 0); // Left, First element
			grid.Children.Add(txtname= new Entry { Placeholder = "tz name" }, 1, 0); // Right, First element
			grid.Children.Add(new Label { Text = "GMT" }, 0, 1); // Left, Second element
			grid.Children.Add(picker, 1, 1); // Right, Second element
			grid.Children.Add(new Label { Text = "City" }, 0, 2); // Right, Second element
			grid.Children.Add(txtcity= new Entry { Placeholder = "tz name" }, 1, 2);
			//grid.Children.Add(new Label { Text = "Btn",XAlign = TextAlignment.Center }, 0, 2, 3, 4);

			var gridButton = new Button { Text = "Add Timezone." };

			gridButton.Clicked += async (sender, e) => {
				
				indicator.IsRunning = true;
				indicator.IsVisible=true;

				var timezonedto= new  TimezoneDTO {
					UserId=user.objectId,
					Name= this.txtname.Text.ToString().Trim(),
					City= this.txtcity.Text.ToString().Trim(),
					GMT= gmtvalues[picker.Items[picker.SelectedIndex]]
				};
				await Task.Run( async () => await tzviewModel.AddTz( timezonedto));

				indicator.IsRunning = false;
				indicator.IsVisible=false;
				if (tzviewModel.Timezones.Count>0)
					DisplayAlert ("Alert", "Se agrego el TimeZone con el Id, "+tzviewModel.Timezones[0].objectId,"OK");//App.Current.MainPage = new NavigationPage(new TimezoneListPage(loginvm.AuthenticatedUser)); 
				else
					DisplayAlert ("Alert", "No fue agregado, intenta nuevamente","OK");

			};

			grid.Children.Add(gridButton, 0, 2, 3, 4);

			indicator = new ActivityIndicator
			{
				IsRunning = false,
				IsEnabled=true,
				IsVisible=false
			};

			layout.Children.Add(grid);
			layout.Children.Add (indicator);
			Content = layout;


		}
	};
}

