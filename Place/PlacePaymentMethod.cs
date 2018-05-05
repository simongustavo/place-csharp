using System;

namespace Place
{
	public class PlacePaymentMethod: PlaceObject<PlacePaymentMethod>
	{

		public class PlacePaymentMethodBankAccount: System.Object {
			public string account_class { get; set; }
			public string account_number { get; set; }
			public string account_type { get; set; }
			public string routing_number { get; set; }
		}

		public class PlacePaymentMethodCreditCard: System.Object {
			public string card_brand { get; set; }
			public string card_code { get; set; }
			public string card_number { get; set; }
			public string card_type { get; set; }
			public string expiration_date { get; set; }
		}

		public override string resource { get { return "/payment_methods"; } }
		public override string object_type { get { return "payment_method"; } }

		public string account_id { get; set; }
		public string description { get; set; }
		public string first_name { get; set; }
		public string last_name { get; set; }
		public string phone_number { get; set; }
		public string type { get; set; }
		public PlacePaymentMethodBankAccount bank_account { get; set; }
		public PlacePaymentMethodCreditCard card { get; set; }
	}
}
