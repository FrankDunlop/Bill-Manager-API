using Contracts.Domain;
using System.Collections.Generic;

namespace BillManager.Services
{
	public interface IBillService
	{
		List<Bill> GetBills();

		Bill GetBill(int billId);

		bool UpdateBill(Bill billToUpdate);

		bool DeleteBill(int billId);
	}
}
