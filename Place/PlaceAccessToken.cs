using System;

namespace Place
{
    public class PlaceAccessToken: PlaceObject<PlaceAccessToken>
    {
		public override string resource { get { return "/access_tokens"; } }
		public override string object_type { get { return "access_token"; } }

        public string account_id { get; set; }
        public string access_token { get; set; }
        public string type { get; set; }
        public string expiration { get; set; }
    }
}
