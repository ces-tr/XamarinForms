using System;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace XamTest
{
	public class LoginPage : ContentPage
	{
		Entry txtuser,txtpass;
		Button btnlogin,btnSignup ;
		RelativeLayout relativeLayout ;
		ActivityIndicator indicator;

		public LoginPage() 
		{
			txtuser =new Entry { 
				Placeholder = "Username"
			};

			txtpass=new Entry { 
				Placeholder = "Password", IsPassword = true
			};

			btnlogin = new Button {
				Text = "Login",
				Font = Font.SystemFontOfSize(NamedSize.Large),
				BorderWidth = 1,
				HorizontalOptions = LayoutOptions.Center,
				VerticalOptions = LayoutOptions.CenterAndExpand,
			};

			btnlogin.Clicked += async (sender, e) => {
				//await Loginuser(this.txtuser,txtpass); 
				indicator.IsRunning = true;
				//indicator.IsEnabled=true;
				indicator.IsVisible=true;
				var loginvm = new LoginVM ();

				//var User =await loginvm.GetUser (this.txtuser.Text.ToString().Trim(), this.txtpass.Text.ToString().Trim());
				var validated= await Task.Run( async () => await loginvm.ValidateUser(this.txtuser.Text.ToString().Trim(), this.txtpass.Text.ToString().Trim())/*.ContinueWith((taskgetuser) => { onvalidateuser(taskgetuser.Result);})*/);
				indicator.IsRunning = false;
				indicator.IsVisible=false;
				if (validated)
					App.Current.MainPage = new NavigationPage(new TimezoneListPage(loginvm.AuthenticatedUser)); 
				else
					DisplayAlert ("Alert", "No has iniciado sesión, intenta nuevamente","OK");
							
			};
			btnSignup = new Button {
				Text = "Sign up",
				Font = Font.SystemFontOfSize(NamedSize.Large),
				BorderWidth = 1,
				HorizontalOptions = LayoutOptions.Center,
				VerticalOptions = LayoutOptions.CenterAndExpand,
			};

			btnSignup.Clicked += async (sender, e) => {
			};

			indicator = new ActivityIndicator
			{
				IsRunning = false,
				IsEnabled=true,
				IsVisible=false
			};

			relativeLayout = new RelativeLayout ();

			relativeLayout.Children.Add (txtuser, 
				Constraint.RelativeToParent ((parent) => {
					return parent.Width / 3;
				}),
				Constraint.RelativeToParent ((parent) => {
					return parent.Height / 3  ;
				}),
				Constraint.RelativeToParent ((parent) => {
					return 150;
				})
			);

			relativeLayout.Children.Add (txtpass,
				Constraint.RelativeToParent ((parent) => {
					return parent.Width / 3;
				}),
				Constraint.RelativeToParent ((parent) => {
					return parent.Height / 3  + 40;
				}),
				Constraint.RelativeToParent ((parent) => {
					return 150;
				})
			);

			relativeLayout.Children.Add (btnlogin,
				Constraint.RelativeToParent ((parent) => {
					return parent.Width / 2;
				}),
				Constraint.RelativeToParent ((parent) => {
					return parent.Height / 3  + 100;
				}),
				Constraint.RelativeToParent ((parent) => {
					return 100;
				})
			);
			relativeLayout.Children.Add (btnSignup,
				Constraint.RelativeToParent ((parent) => {
					return parent.Width / 4;
				}),
				Constraint.RelativeToParent ((parent) => {
					return parent.Height / 3  + 100;
				}),
				Constraint.RelativeToParent ((parent) => {
					return 100;
				})
			);
			relativeLayout.Children.Add (indicator,
				Constraint.RelativeToParent ((parent) => {
					return parent.Width / 3;
				}),
				Constraint.RelativeToParent ((parent) => {
					return parent.Height / 3  + 150;
				}),
				Constraint.RelativeToParent ((parent) => {
					return 100;
				}),
				Constraint.RelativeToParent ((parent) => {
					return 100;
				})
			);

			this.Content = relativeLayout;
		}

//		private async Task Init ()
//		{
//		}

		private void onvalidateuser(Object response){
			

			//				Log.Info ("XamarinTest", tzdto.objectId);
		
		}
	}
}

