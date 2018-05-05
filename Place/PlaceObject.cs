using System;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Place {

	public class PlaceObject<T>: System.Object {

		[JsonIgnore]
		public virtual string resource { get { return ""; } }

		[JsonIgnore]
		public virtual string object_type { get { return ""; } }

		private static JsonSerializerSettings jsonsettings = new JsonSerializerSettings{
			NullValueHandling = NullValueHandling.Ignore
		};

		public string id { get; set; }

		public static T get( string id, object update=null, object parameters=null ) {
			if ( string.IsNullOrEmpty(id) )
				throw new ArgumentException("id cannot be empty");

			if ( update != null )
				return request( "PUT", id, parameters, json: update );
			else
				return request( "GET", id, parameters );
		}

		public static List<T> select(object filter_by=null, object update_all=null, bool delete_all=false ) {
			if ( update_all != null )
				return request( "PUT", parameters: filter_by, json: update_all );

			if ( delete_all == true )
				return request( "DELETE", parameters: filter_by );

			return request( "GET", parameters: filter_by );
		}

		public static T create( object data, object parameters=null ) {
			return request( "POST", parameters: parameters, json: data );
		}

		public void update( object data, object parameters=null ) {
			request( "PUT", this.id, parameters, json: data, obj: this );
		}

		public static dynamic request(string method, string id=null,
			object parameters=null, object json=null, PlaceObject<T> obj=null) {

			if ( obj == null )
				obj = (PlaceObject<T>)Activator.CreateInstance(typeof(T));

			string responseValue = string.Empty;
			try
			{
				string req_url = PlaceClient.api_url + obj.resource;

				if (!string.IsNullOrEmpty(id))
					req_url += "/" + id;

				if (parameters != null)
					req_url += "?" + ObjectHelper.GetQueryString(parameters);

				HttpWebRequest request = (HttpWebRequest)WebRequest.Create(req_url);
				request.Method = method;

				string _auth = string.Format("{0}:{1}", PlaceClient.api_key, "");
				string _enc = Convert.ToBase64String(Encoding.ASCII.GetBytes(_auth));
				string _cred = string.Format("{0} {1}", "Basic", _enc);
				request.Headers.Add("Authorization", _cred);

				request.ContentLength = 0;
				request.Accept = "application/json";

				if (json != null)
				{
					request.ContentType = "application/json";
					string post_data = JsonConvert.SerializeObject(json, Formatting.None, jsonsettings );
					var bytes = Encoding.GetEncoding("iso-8859-1").GetBytes(post_data);
					request.ContentLength = bytes.Length;

					using (var writeStream = request.GetRequestStream())
					{
						writeStream.Write(bytes, 0, bytes.Length);
					}
				}

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

					if (!string.IsNullOrEmpty(id)) {
						if ( method == "PUT" ) {
							JsonConvert.PopulateObject(responseValue,obj);
							return obj;
						} else
							return (T) JsonConvert.DeserializeObject(responseValue,typeof(T));
					} else {
						var objs = (PlaceObjectList<T>) JsonConvert.DeserializeObject(responseValue,typeof(PlaceObjectList<T>));
						return (List<T>) objs.values;
					}
				}
			}
			catch (System.Net.WebException ex)
			{
				var WebResponse = ex.Response;
				if (ex.Status == WebExceptionStatus.ProtocolError)
				{
					if (WebResponse.ContentLength != 0)
					{
						using (var response_stream = WebResponse.GetResponseStream())
						{
							using (var response_reader = new StreamReader(response_stream))
							{
								responseValue = response_reader.ReadToEnd();
								//return responseValue;
								throw new Exception("test");
							}
						}
					}
				}

				throw;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
	}

	public class PlaceObjectList<T>: System.Object {
		public List<T> values;
	}
}
