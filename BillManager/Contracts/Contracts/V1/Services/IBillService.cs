using Contracts.Domain;
using System;
using System.Collections.Generic;

namespace Contracts.Contracts
{
	public interface IBillService
	{
		IEnumerable<Bill> GetBills(string name = "", string vendor = "");
		Bill GetBill(Guid billId);
		bool UpdateBill(Bill billToUpdate);
		bool DeleteBill(Guid billId);

		byte[] GetBillDocument(Guid billId);
	}
}
