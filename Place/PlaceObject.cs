using System;
using Newtonsoft.Json;

namespace Place
{
  public class PlaceObject<T>: System.Object
  {

		[JsonIgnore]
		public virtual string resource { get { return ""; } }

		[JsonIgnore]
		public virtual string object_type { get { return ""; } }
		
		public string id { get; set; }

		public static T get( string id, string parameters="" ) {
			PlaceObject<T> obj = (PlaceObject<T>)Activator.CreateInstance(typeof(T));
			PlaceClient client = new PlaceClient();

			string response = client.MakeRequest( "GET", obj.resource + "/" + id, parameters );

			return (T) JsonConvert.DeserializeObject(response,typeof(T));
		}
		
		public static T create( object data, string parameters="" ) {
			PlaceObject<T> obj = (PlaceObject<T>)Activator.CreateInstance(typeof(T));
			PlaceClient client = new PlaceClient();

			JsonSerializerSettings jsonsettings = new JsonSerializerSettings{
				NullValueHandling = NullValueHandling.Ignore
			};
			
			string post_data = JsonConvert.SerializeObject(data, Formatting.None, jsonsettings );
			string response = client.MakeRequest( "POST", obj.resource, parameters, post_data: post_data );

			return (T) JsonConvert.DeserializeObject(response,typeof(T));
		}
		
		public void update( object data, string parameters="" ) {
			PlaceClient client = new PlaceClient();

			JsonSerializerSettings jsonsettings = new JsonSerializerSettings{
				NullValueHandling = NullValueHandling.Ignore
			};

			string post_data = JsonConvert.SerializeObject(data, Formatting.None, jsonsettings );
			string response = client.MakeRequest( "PUT", this.resource + "/" + this.id, parameters, post_data: post_data );

			JsonConvert.PopulateObject(response,this);

			//return this;
		}
	}
}
