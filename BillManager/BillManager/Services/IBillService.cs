using Contracts.Domain;
using System;
using System.Collections.Generic;

namespace BillManager.Services
{
	public interface IBillService
	{
		List<Bill> GetBills();

		Bill GetBill(Guid billId);

		bool UpdateBill(Bill billToUpdate);

		bool DeleteBill(Guid billId);
	}
}
