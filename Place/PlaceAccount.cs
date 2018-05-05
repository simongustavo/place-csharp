using System;
using System.Collections.Generic;

namespace Place
{
    public class PlaceAccount: PlaceObject<PlaceAccount>
    {
			public override string resource { get { return "/accounts"; } }
			public override string object_type { get { return "account"; } }
	
	    public List<PlaceAccessToken> access_tokens { get; set; }
	    public string username { get; set; }
	    public string user_type { get; set; }
	    public string full_name { get; set; }
	    public string email { get; set; }
	    public string access_key { get; set; }
	    public string phone { get; set; }
	    public string company { get; set; }
    }
}
