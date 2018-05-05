using System;

namespace Place
{
	public class PlaceTransaction: PlaceObject<PlaceTransaction>
	{
		public override string resource { get { return "/transactions"; } }
		public override string object_type { get { return "transaction"; } }

		public string description { get; set; }
		public string payment_method_id { get; set; }
		public string deposit_account_id { get; set; }
		public string status { get; set; }
		public float  fee { get; set; }
		public float  amount { get; set; }
		public string initiated_timestamp { get; set; }
		public string failed_timestamp { get; set; }
		public string status_details { get; set; }
		public string type { get; set; }
		public string account_id { get; set; }
		public PlacePaymentMethod payment_method { get; set; }

	}
}
