using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using PropertyChanged;
 
namespace XamTest
{
	//[ImplementPropertyChanged]
	public class TimeZoneVM
	{
		//public ObservableCollection<TimezoneDTO> Timezones {get;set;}
		public List<TimezoneDTO> Timezones {get;set;}

		public TimeZoneVM ()
		{
		}

		public async Task getTz(String userid) {

			//TimezoneSvc tz = new TimezoneSvc ();

			try {
				var	timezbyUser= await new TimezoneSvc().GetbyUserID(userid);
				this.Timezones=timezbyUser.results;
				//this.Timezones = new ObservableCollection<TimezoneDTO>( timezbyUser.results);
			}
			catch(Exception) {
			}
		}

		public async Task deleteTz(String objid) {

			//TimezoneSvc tzsvc = new TimezoneSvc ();

			try {
				await new TimezoneSvc ().Delete(objid);
				//this.Timezones=timezbyUser.results;
			}
			catch(Exception) {
			}
		}

		public async Task AddTz(TimezoneDTO tzdto) {

			//TimezoneSvc tzsvc = new TimezoneSvc ();
			//TimezoneDTO tzadded = new TimezoneDTO ();
			try {
				var tzadded= await new TimezoneSvc().Add(tzdto);
				Timezones=new List<TimezoneDTO>();
				Timezones.Add(tzadded);
				//this.Timezones=addedtz;
				//this.Timezones = new ObservableCollection<TimezoneDTO>( timezbyUser.results);
			}
			catch(Exception) {
			}
		}
	}
}

