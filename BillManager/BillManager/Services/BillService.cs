using BillManager.Data;
using Contracts.Contracts;
using Contracts.Contracts.Requests;
using Contracts.Domain;
using Contracts.Domain.Extensions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace BillManager.Services
{
	public class BillService : IBillService
	{
		private readonly DataContext _dataContext;

		public BillService(DataContext dataContext)
		{
			_dataContext = dataContext;
		}
		public async Task<IEnumerable<Bill>> GetBillsAsync(string name = "", string vendor = "")
		{
			if (name.Equals(string.Empty) && vendor.Equals(string.Empty))
				return await _dataContext.Bills.ToListAsync();

			if (!name.Equals(string.Empty))
			{
				return await _dataContext.Bills
					.Where(b => b.Name.Equals(name))
					.ToListAsync();
			}
			else
			{
				return await _dataContext.Bills
					.Where(b => b.Vendor.Equals(vendor))
					.ToListAsync();
			}
		}

		public async Task<Bill> GetBillAsync(Guid billId)
		{
			return await _dataContext.Bills.SingleOrDefaultAsync(x => x.Id == billId);
		}

		public async Task<bool> AddBillAsync(Bill bill)
		{
			_dataContext.Bills.AddAsync(bill);
			var created = await _dataContext.SaveChangesAsync();
			return created > 0;
		}

		public async Task<bool> UpdateBillAsync(Bill bill)
		{
			_dataContext.Bills.Update(bill);
			var updated = await _dataContext.SaveChangesAsync();
			return updated > 0;
		}

		public async Task<bool> DeleteBillAsync(Guid billId)
		{
			var bill = await GetBillAsync(billId);

			if (bill == null)
				return false;

			_dataContext.Bills.Remove(bill);
			var deleted = await _dataContext.SaveChangesAsync();
			return deleted > 0;
		}

		public async Task<byte[]> GetBillDocumentAsync(Guid billId)
		{
			var bill = await _dataContext.Bills.SingleOrDefaultAsync(x => x.Id == billId);
			return bill.Document;
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
