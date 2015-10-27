using System;
using System.Collections.Generic;
using PropertyChanged;
namespace XamTest
{
	//[ImplementPropertyChanged]
	public class TimezoneDTO
	{

		public string objectId { get; set; }
		public string Name { get; set; }
		public string GMT { get; set; }
		public string createdAt { get; set; }
		public string UserId { get; set; }
		public string City { get; set; }

	}

	public class TimezoneDTOCollection {

		public List<TimezoneDTO> results  {get;set;}
	}
}

