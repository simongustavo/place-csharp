using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Place
{

	public class PlaceClient
	{
		public static string api_url { get; set; }
		public static string api_key { get; set; }

		public string MakeRequest(string method, string endpoint, string parameters, string post_data="")
		{
			try
			{
				if (!string.IsNullOrEmpty(parameters))
					parameters = "?" + parameters;

				string req_url = api_url + endpoint + parameters;
				HttpWebRequest request = (HttpWebRequest)WebRequest.Create(req_url);
				request.Method = method;

				string _auth = string.Format("{0}:{1}", api_key, "");
				string _enc = Convert.ToBase64String(Encoding.ASCII.GetBytes(_auth));
				string _cred = string.Format("{0} {1}", "Basic", _enc);
				request.Headers.Add("Authorization", _cred);

				request.ContentLength = 0;
				request.Accept = "application/json";

				if (!string.IsNullOrEmpty(post_data))
				{
					request.ContentType = "application/json";
					var encoding = new UTF8Encoding();
					var bytes = Encoding.GetEncoding("iso-8859-1").GetBytes(post_data);
					request.ContentLength = bytes.Length;

					using (var writeStream = request.GetRequestStream())
					{
						writeStream.Write(bytes, 0, bytes.Length);
					}
				}

				var responseValue = string.Empty;

				using (var response = (HttpWebResponse)request.GetResponse())
				{
					if (response.StatusCode != HttpStatusCode.OK)
					{
						var message = String.Format("Request failed. Received HTTP {0}", response.StatusCode);
						throw new ApplicationException(message);
					}

					// grab the response
					using (var responseStream = response.GetResponseStream())
					{
						if (responseStream != null)
							using (var reader = new StreamReader(responseStream))
							{
								responseValue = reader.ReadToEnd();
							}
					}

					return responseValue;
				}
			}
			catch (System.Net.WebException ex)
			{
				string sResult = string.Empty;
				var WebResponse = ex.Response;
				if (ex.Status == WebExceptionStatus.ProtocolError)
				{
					if (WebResponse.ContentLength != 0)
					{
						using (var response_stream = WebResponse.GetResponseStream())
						{
							using (var response_reader = new StreamReader(response_stream))
							{
								sResult = response_reader.ReadToEnd();
								return sResult;
							}
						}
					}
				}

				throw;
			}
			catch (Exception ex)
			{
				throw;
			}
		}
	}
}
