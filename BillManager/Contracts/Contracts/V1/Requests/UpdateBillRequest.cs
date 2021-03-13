using System;

namespace Contracts.Contracts.Requests
{
	public class UpdateBillRequest
	{
		public bool IsPaid { get; set; }
		public DateTime? PaidDate { get; set; }
	}
}
