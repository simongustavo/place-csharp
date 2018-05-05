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

		public const string PROD_URL = "https://api.placepay.com";
		public const string TEST_URL = "https://test-api.placepay.com";

		private static string _api_url = PROD_URL;

		public static string api_url {
			get {
				if ( !string.IsNullOrEmpty(api_key)
				&& _api_url.Equals( PROD_URL )
				&& api_key.StartsWith("test_") )
					return TEST_URL;
				return _api_url;
			}
			set { _api_url = value; }
		}
		public static string api_key { get; set; }
	}
}
