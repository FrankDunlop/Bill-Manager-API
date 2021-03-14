using System;

namespace Contracts.Contracts.Requests
{
	public class UpdateBillRequest
	{
		public string Vendor { get; set; }
		public int Occurance { get; set; }
		public int PaymentType { get; set; }
		public bool IsPaid { get; set; }
		public DateTime? PaidDate { get; set; }
		public string Notes { get; set; }
	}
}
