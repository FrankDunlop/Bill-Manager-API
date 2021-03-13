using Contracts.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BillManager.Services
{
	public class BillService : IBillService
	{
		public List<Bill> bills;

		public BillService()
		{
			bills = new List<Bill>(){
				new Bill{Id = Guid.NewGuid(), Name = "Electric"},
				new Bill{Id = Guid.NewGuid(), Name = "Phone"}
			};
		}
		public List<Bill> GetBills()
		{
			return bills;
		}

		public Bill GetBill(Guid billId)
		{
			return bills.SingleOrDefault(x => x.Id == billId);
		}

		public bool UpdateBill(Bill billToUpdate)
		{
			var exists = GetBill(billToUpdate.Id) != null;

			if (!exists)
				return false;

			var index = bills.FindIndex(x => x.Id == billToUpdate.Id);
			bills[index] = billToUpdate;
			return true;
		}

		public bool DeleteBill(Guid billId)
		{
			var bill = GetBill(billId);

			if (bill == null)
				return false;

			bills.Remove(bill);
			return true;
		}
	}
}
