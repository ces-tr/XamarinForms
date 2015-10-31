using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

using Newtonsoft.Json;

namespace XamTest
{
	public class BaseSvc
	{
		/*TESTING CHANGES*/
		private const string ApiBaseAddress = "https://api.parse.com/1/";
		public BaseSvc ()
		{
		}

		protected HttpClient CreateClient ()
		{
			var httpClient = new HttpClient 
			{ 
				BaseAddress = new Uri(ApiBaseAddress),
				Timeout = TimeSpan.FromSeconds(10) 
					
			};

			httpClient.DefaultRequestHeaders.Accept.Clear();
			httpClient.DefaultRequestHeaders.Add("X-Parse-REST-API-Key", "HvEkgzxORi7S6zg1bMSLMlXs8Tmh0QKWsU6rXbqN");
			httpClient.DefaultRequestHeaders.Add("X-Parse-Application-Id", "YXwNVkcOSe83lB7EUaTERsDaqJgyLZ3YQNUuE60S");
			httpClient.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", "application/json");
			//httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

			return httpClient;
		}

//		public async Task<List<Timezone>> GetTimezone ()
//		{
//			IEnumerable<TimezoneDTO> TimezoneDtos = Enumerable.Empty<TimezoneDTO>();
//			//IEnumerable<Conference> conferences = Enumerable.Empty<Conference> ();
//
//			using (var httpClient = CreateClient ()) {
//				var response = await httpClient.GetAsync("classes/Timezone").ConfigureAwait(false);
//				//var response = await httpClient.GetAsync("classes/Timezone").ConfigureAwait(false);
//				if (response.IsSuccessStatusCode) {
//					var json = await response.Content.ReadAsStringAsync ().ConfigureAwait(false);
//
//					if (!string.IsNullOrWhiteSpace (json)) {
//						TimezoneDtos = await Task.Run (() => 
//							JsonConvert.DeserializeObject<IEnumerable<TimezoneDTO>>(json)
//						).ConfigureAwait(false);
//
//						//conferences = await Task.Run(() => 
//						//	Mapper.Map<IEnumerable<Conference>> (conferenceDtos)
//						//).ConfigureAwait(false);	
//					}
//				}
//			}
//
//			return TimezoneDtos.ToList();
//		}

		public async Task<String> ExecGet(string controller, String dataparams) {
			var responsedata = "";

			try{

			using (var httpClient = CreateClient ()) {
				//var response = await httpClient.GetAsync("classes/Timezone").ConfigureAwait(false);
					var response = await httpClient.GetAsync(controller + "?" + dataparams).ConfigureAwait(false);
				if (response.IsSuccessStatusCode) {
					responsedata = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

					//callbackRespuesta(json);
					//if (!string.IsNullOrWhiteSpace (responsedata)) {
						//TimezoneDtos = await Task.Run (() => 
						//	JsonConvert.DeserializeObject<IEnumerable<TimezoneDTO>>(json)
						//).ConfigureAwait(false);

						//conferences = await Task.Run(() => 
						//	Mapper.Map<IEnumerable<Conference>> (conferenceDtos)
						//).ConfigureAwait(false);	
					//}
				}
			}
			}
			catch(Exception e){
			}

			return responsedata;
		}

		public async Task<String> ExecDel(string controller, String dataparams) {
			var responsedata = "";

			try{

				using (var httpClient = CreateClient ()) {
					var response = await httpClient.DeleteAsync(controller ).ConfigureAwait(false);
					if (response.IsSuccessStatusCode) {
						responsedata = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
					}
				}
			}
			catch(Exception e){
			}

			return responsedata;
		}

		public async Task<String> ExecPost(string controller, String postData) {
			var responsedata = "";

			try{

				//HttpContent content = new FormUrlEncodedContent(postData); 
				using (var httpClient = CreateClient ()) {
					//var response = await httpClient.GetAsync("classes/Timezone").ConfigureAwait(false);
					var response = await httpClient.PostAsync(controller,
						new StringContent(postData, System.Text.Encoding.UTF8, "text/json")).ConfigureAwait(false);
					if (response.IsSuccessStatusCode) {
						responsedata = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

					}
				}
			}
			catch(Exception e){
			}

			return responsedata;
		}

	}
}

