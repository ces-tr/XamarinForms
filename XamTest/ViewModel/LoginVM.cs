using System;
using System.Threading.Tasks;

namespace XamTest
{
	
	public class LoginVM
	{
		public UserDTO AuthenticatedUser = new UserDTO();

		UserDTO userdata = null;
		public LoginVM ()
		{
		}

		public async Task<Boolean> ValidateUser(String struser , String strpass) {
			var user = new UserSvc();
			UserDTO userdata = new UserDTO();
			try {

			userdata = await user.Get (struser,strpass);
			//this.userdata = conferences.OrderBy(x => x.Name).ToList();
			}
			catch(Exception) {
				return false;
			}

			if (userdata.username == struser) {
				AuthenticatedUser = userdata;
				return true;
			}
			else
				return false;

			//return Boolean;
		}

	}
}

