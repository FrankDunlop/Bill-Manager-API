using System;

namespace Contracts.Domain
{
	public class Bill
	{
		public Guid Id { get; set; }
		public string Name { get; set; }
		public int Occurance { get; set; }
		public int Category { get; set; }
		public DateTime BillDate { get; set; }
		public DateTime? PeriodFrom { get; set; }
		public DateTime? PeriodTo { get; set; }
		public double? Price { get; set; }
		public bool IsPaid { get; set; }
		public DateTime? PaidDate { get; set; }
		public byte[] Document { get; set; }
	}
}
