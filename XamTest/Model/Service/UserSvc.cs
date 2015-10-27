using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace XamTest
{
	public class UserSvc :BaseSvc
	{
		public UserSvc ()
		{
		}


		public async Task<UserDTO> Get(string userid,string pass)
		{
			UserDTO Userdto = new UserDTO() ;//= Enumerable.Empty<TimezoneDTOCollection>();
			//IEnumerable<Conference> conferences = Enumerable.Empty<Conference> ();
			try{
				
				var json =await ExecGet( "login","username="+userid+"&password="+pass);
				if (!string.IsNullOrWhiteSpace (json)) {
					Userdto = await Task.Run (() => 
						JsonConvert.DeserializeObject<UserDTO>(json)
					).ConfigureAwait(false);
				}
			}
			catch(Exception){
			}
			return Userdto;
		}
	}
}

