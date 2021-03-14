using Contracts.Contracts.Requests;
using Contracts.Domain;
using System;
using System.Collections.Generic;

namespace Contracts.Contracts
{
	public interface IBillService
	{
		IEnumerable<Bill> GetBills(string name = "", string vendor = "");
		Bill GetBill(Guid billId);
		Bill AddBill(Bill bill);
		Bill UpdateBill(Guid billId, Bill bill);
		bool DeleteBill(Guid billId);
		byte[] GetBillDocument(Guid billId);
		void ConvertDoc();
		
	}
}
