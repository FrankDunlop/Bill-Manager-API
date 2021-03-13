using Contracts.Domain;
using System;
using System.Collections.Generic;

namespace Contracts.Contracts
{
	public interface IBillService
	{
		List<Bill> GetBills();

		Bill GetBill(Guid billId);

		bool UpdateBill(Bill billToUpdate);

		bool DeleteBill(Guid billId);
	}
}
