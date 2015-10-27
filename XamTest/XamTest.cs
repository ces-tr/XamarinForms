using System;

using Xamarin.Forms;


namespace XamTest
{
	public class App : Application
	{
		public App ()
		{
			

			MainPage  = new NavigationPage( new LoginPage () );//ContentPage{

			//	Content= relativeLayout//new RelativeLayout{
					
//					Children = {
//						new Label {
//							XAlign = TextAlignmentCenter,
//							Text = "Welcome to Xamarin Forms!"
//						},
//						 new Entry { 
//							Placeholder = "Username" 
//						},
//						new Entry { Placeholder = "Password", IsPassword = true },
//						new Button {
//							Text = "Login",
//							TextColor = Color.White,
//							BackgroundColor = Color.FromHex("77D065"),
//							WidthRequest = 100
//						}
//
//					}
				//}
			//};

		
		}

		protected override void OnStart ()
		{
			// Handle when your app starts
		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
	}
}

