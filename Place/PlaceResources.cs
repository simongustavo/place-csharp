using System;
using System.Collections.Generic;

namespace Place
{
	public class PlaceTransaction: PlaceObject<PlaceTransaction> {
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

	public class PlaceAccessToken: PlaceObject<PlaceAccessToken> {
		public override string resource { get { return "/access_tokens"; } }
		public override string object_type { get { return "access_token"; } }

    public string account_id { get; set; }
    public string access_token { get; set; }
    public string type { get; set; }
    public string expiration { get; set; }
  }

	public class PlaceAutopayEnrollment: PlaceObject<PlaceAutopayEnrollment> {
		public override string resource { get { return "/autopay_enrollments"; } }
		public override string object_type { get { return "autopay_enrollment"; } }
		
		public string account_id { get; set; }
		public string deposit_account_id { get; set; }
		public string enrolled_timestamp { get; set; }
		public string last_payment_status { get; set; }
		public string last_payment_timestamp { get; set; }
		public float  lower_limit { get; set; }
		public string payment_method_id { get; set; }
		public string recurring_invoice_id { get; set; }
		public float  upper_limit { get; set; }
	}
	
	public class PlaceEvent: PlaceObject<PlaceEvent> {
		public override string resource { get { return "/events"; } }
		public override string object_type { get { return "event"; } }
		
		public string callback_url { get; set; }
		public string event_name { get; set; }
	}
	
	public class PlaceAccount: PlaceObject<PlaceAccount> {
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
  
  public class PlaceDepositAccount: PlaceObject<PlaceDepositAccount> {
		public override string resource { get { return "/deposit_accounts"; } }
		public override string object_type { get { return "deposit_account"; } }
		
		public bool accepted_terms { get; set; }
		public PlaceAddress address { get; set; }
		public string address_id { get; set; }
		public string company { get; set; }
		public bool default_flag { get; set; }
		public PlacePaymentMethod deposit_method { get; set; }
		public string deposit_method_id { get; set; }
		public string phone { get; set; }
		public int required_payer_auth_level { get; set; }
		public FeeSettings fee_settings { get; set; }
	}
	
  public class PlaceTransactionAllocation: PlaceObject<PlaceTransactionAllocation> {
		public override string resource { get { return "/transaction_allocations"; } }
		public override string object_type { get { return "transaction_allocation"; } }
		
		public float amount { get; set; }
		public string invoice_id { get; set; }
		public string invoice_payer_id { get; set; }
		public string transaction_id { get; set; }
		public string type { get; set; }
	}
	
  public class PlacePaymentMethod: PlaceObject<PlacePaymentMethod> {

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
	
  public class PlaceAddress: PlaceObject<PlaceAddress> {
		public override string resource { get { return "/addresses"; } }
		public override string object_type { get { return "address"; } }
		
		public string address { get; set; }
		public string city_state_zip { get; set; }
		public string street_address { get; set; }
		public string street_name { get; set; }
		public string street_number { get; set; }
		public string unit_number { get; set; }
	}
	
  public class PlaceRecurringInvoice: PlaceObject<PlaceRecurringInvoice> {
		public override string resource { get { return "/recurring_invoices"; } }
		public override string object_type { get { return "recurring_invoice"; } }
		
		public bool autogenerate_invoices { get; set; }
		public int cycle_offset { get; set; }
		public string deposit_account_id { get; set; }
		public string end_date { get; set; }
		public PlaceInvoice invoice_template { get; set; }
		public string invoice_template_id { get; set; }
		public List<PlaceInvoice> invoices { get; set; }
		public bool prorated { get; set; }
		public string recurring_frequency { get; set; }
		public string start_date { get; set; }
	}
	
  public class PlaceInvoice: PlaceObject<PlaceInvoice> {
		public override string resource { get { return "/invoices"; } }
		public override string object_type { get { return "invoice"; } }
		
		public string accepted_payment_state { get; set; }
		public float amount { get; set; }
		public float amount_paid { get; set; }
		public float amount_unallocated { get; set; }
		public string completed_date { get; set; }
		public string deposit_account_id { get; set; }
		public string description { get; set; }
		public string due_date { get; set; }
		public List<PlaceInvoiceItem> items { get; set; }
		public string last_payment_date { get; set; }
		public bool paid { get; set; }
		public List<PlaceInvoicePayer> payers { get; set; }
		public bool payments_blocked { get; set; }
		public string recurring_invoice_id { get; set; }
		public string reference_id { get; set; }
		public int required_payer_auth_level { get; set; }
		public string type { get; set; }
  	public FeeSettings fee_settings { get; set; }
	}
	
  public class PlaceInvoiceItem: PlaceObject<PlaceInvoiceItem> {
		public override string resource { get { return "/invoice_items"; } }
		public override string object_type { get { return "invoice_item"; } }
		
		public List<PlaceInvoiceItemAllocation> allocations { get; set; }
		public float amount { get; set; }
		public float amount_allocated { get; set; }
		public string date_incurred { get; set; }
		public string description { get; set; }
		public string invoice_id { get; set; }
		public bool prorated { get; set; }
		public bool recurring { get; set; }
		public string type { get; set; }
	}
	
  public class PlaceInvoicePayer: PlaceObject<PlaceInvoicePayer> {
		public override string resource { get { return "/invoice_payers"; } }
		public override string object_type { get { return "invoice_payer"; } }
		
		public bool access { get; set; }
		public string account_id { get; set; }
		public bool active { get; set; }
		public float amount_allocated { get; set; }
		public float amount_paid { get; set; }
		public string email { get; set; }
		public string first_name { get; set; }
		public string invoice_id { get; set; }
		public string last_name { get; set; }
		public string last_payment_date { get; set; }
		public bool paid { get; set; }
		public string payments_transfer_date { get; set; }
		public bool payments_transfered { get; set; }
	}
	
  public class PlaceInvoiceItemAllocation: PlaceObject<PlaceInvoiceItemAllocation> {
		public override string resource { get { return "/invoice_item_allocations"; } }
		public override string object_type { get { return "invoice_item_allocation"; } }
		
		public float amount { get; set; }
		public string item_id { get; set; }
		public string payer_id { get; set; }
		public string type { get; set; }
	}
	
	public class FeeSetting: System.Object {
		public float distribution { get; set; }
		public float flat { get; set; }
		public float pct { get; set; }
	}
	
	public class FeeSettings: System.Object {
		public FeeSetting bank_account { get; set; }
		public FeeSetting credit { get; set; }
		public FeeSetting debit { get; set; }
	}
	
}
