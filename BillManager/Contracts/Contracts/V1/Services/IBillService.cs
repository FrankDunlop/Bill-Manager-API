using Contracts.Domain;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Contracts.Contracts
{
	public interface IBillService
	{
		Task<IEnumerable<Bill>> GetBillsAsync(string name = "", string vendor = "");
		Task<Bill> GetBillAsync(Guid billId);
		Task<bool> AddBillAsync(Bill bill);
		Task<bool> UpdateBillAsync(Bill bill);
		Task<bool> DeleteBillAsync(Guid billId);
		Task<byte[]> GetBillDocumentAsync(Guid billId);
		void ConvertDoc();
		
	}
}
