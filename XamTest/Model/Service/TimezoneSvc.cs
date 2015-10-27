using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json;


namespace XamTest
{
	public class TimezoneSvc : BaseSvc
	{
		//IEnumerable<TimezoneDTO> TimezoneDtos = Enumerable.Empty<TimezoneDTO>();

		public TimezoneSvc ()
		{
		}

		public async Task<TimezoneDTOCollection> GetAll ()
		{
			TimezoneDTOCollection TimezoneDtos =new TimezoneDTOCollection() ;//= Enumerable.Empty<TimezoneDTOCollection>();
			//IEnumerable<Conference> conferences = Enumerable.Empty<Conference> ();
			try{
			//using (var httpClient = CreateClient ()) {
			//	var response = await httpClient.GetAsync("classes/Timezone").ConfigureAwait(false);
				//var response = await httpClient.GetAsync("classes/Timezone").ConfigureAwait(false);
			//	if (response.IsSuccessStatusCode) {
				//	var json = await response.Content.ReadAsStringAsync ().ConfigureAwait(false);
			var json =await ExecGet( "classes/Timezone","");
			if (!string.IsNullOrWhiteSpace (json)) {
				TimezoneDtos = await Task.Run (() => 
					JsonConvert.DeserializeObject<TimezoneDTOCollection>(json)
				).ConfigureAwait(false);

				//conferences = await Task.Run(() => 
				//	Mapper.Map<IEnumerable<Conference>> (conferenceDtos)
				//).ConfigureAwait(false);	
			}

		

					
			//	}
			//}
//			foreach ( TimezoneDTOCollectio tzdto in TimezoneDtos.ToList()){
//				Console.WriteLine (tzdto.objectId);
//				Log.Info ("XamarinTest", tzdto.objectId);
//
//			}
				
			}
			catch(Exception ){
			}
			return TimezoneDtos;
		}

		public async Task<TimezoneDTOCollection> GetbyUserID (String userid) {

			TimezoneDTOCollection TimezoneDtos =new TimezoneDTOCollection() ;

			try{
				var json =await ExecGet( "classes/Timezone","where={\"UserId\":\""+userid+"\"}");
				if (!string.IsNullOrWhiteSpace (json)) {
					TimezoneDtos = await Task.Run (() => 
						JsonConvert.DeserializeObject<TimezoneDTOCollection>(json)
					).ConfigureAwait(false);

				}
			}
			catch(Exception ){
			}
			return TimezoneDtos;
		}


		public async Task Delete (String tzid) {

			TimezoneDTOCollection TimezoneDtos =new TimezoneDTOCollection() ;

			try{
				var response =await ExecDel( "classes/Timezone/"+tzid,"");
//				if (!string.IsNullOrWhiteSpace (json)) {
//					TimezoneDtos = await Task.Run (() => 
//						JsonConvert.DeserializeObject<TimezoneDTOCollection>(json)
//					).ConfigureAwait(false);
//
//				}
			}
			catch(Exception ){
				
			}
			//return TimezoneDtos;
		}

		public async Task<TimezoneDTO> Add (TimezoneDTO tzdto) {

			TimezoneDTO TimezoneDtoAdded =new TimezoneDTO() ;


			try{
				var serializeddata=JsonConvert.SerializeObject(tzdto);
				var json =await ExecPost( "classes/Timezone",serializeddata);//"{\"Name\":\"10\",\"GMT\":\"10\",\"UserId\":\"Z8RygTEnV0\"}");
				if (!string.IsNullOrWhiteSpace (json)) {
					TimezoneDtoAdded = await Task.Run (() => 
						JsonConvert.DeserializeObject<TimezoneDTO>(json)
					).ConfigureAwait(false);

				}
			}
			catch(Exception e){
			}
			return TimezoneDtoAdded;
		}


		protected virtual void ServiceResponseCallback(Object respuesta){
		
					}




	}
}

