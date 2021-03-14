using Contracts.Contracts;
using Contracts.Contracts.Requests;
using Contracts.Domain;
using Contracts.Domain.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
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
				new Bill { Id = Guid.NewGuid(), Name = "Electric", Vendor = "Eirtricity" },
				new Bill { Id = Guid.NewGuid(), Name = "Phone", Vendor = "Vodafone" }
			};
		}
		public IEnumerable<Bill> GetBills(string name = "", string vendor = "")
		{
			if (name.Equals(string.Empty) && vendor.Equals(string.Empty))
				return bills;

			if (!name.Equals(string.Empty))
			{
				return bills.Where(b => b.Name.Equals(name));
			}
			else
			{
				return bills.Where(b => b.Vendor.Equals(vendor));
			}
		}

		public Bill GetBill(Guid billId)
		{
			var bill = bills.SingleOrDefault(x => x.Id == billId);
			return bill;
		}

		public Bill AddBill(Bill bill)
		{
			bills.Add(bill);

			//will change bill domain object to billDto to save

			return bill;
		}

		public Bill UpdateBill(Guid billId, Bill bill)
		{
			var exists = GetBill(billId) != null;

			if (!exists)
				return null;

			//will change bill domain object to billDto to save

			var index = bills.FindIndex(x => x.Id == billId);
			bills[index].IsPaid = bill.IsPaid;
			bills[index].PaidDate = bill.PaidDate;

			return bills[index];
		}

		public bool DeleteBill(Guid billId)
		{
			var bill = GetBill(billId);

			if (bill == null)
				return false;

			bills.Remove(bills.SingleOrDefault(x => x.Id == billId));
			return true;
		}

		public byte[] GetBillDocument(Guid billId)
		{
			return bills.SingleOrDefault(x => x.Id == billId).Document;
		}

		public void ConvertDoc()
		{
			string filename = "INSTRUCTIONS.txt";
			List<byte[]> document = new List<byte[]>();
			using (FileStream fileStream = File.Open(@"C:\Dev\" + filename, FileMode.Open))
			{
				var memoryStream = new MemoryStream();
				memoryStream.SetLength(fileStream.Length);
				fileStream.Read(memoryStream.GetBuffer(), 0, (int)fileStream.Length);
				document.Add(memoryStream.ToArray());
			}

			File.WriteAllBytes(@"C:\Dev\" + filename + "1", document[0]);
		}
	}
}
