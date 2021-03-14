using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.Contracts
{
	public static class ApiRoutes
	{
		public const string Root = "api";
		public const string Version = "v1";
		public const string Base = Root + "/" + Version;

		public static class Bills
		{
			public const string GetBills = Base + "/bills";
			public const string GetBillsByName = Base + "/bills/Name/{name}";
			public const string GetBillsByVendor = Base + "/bills/Vendor/{vendor}";
			public const string GetBill = Base + "/bills/{billId}";
			public const string AddBill = Base + "/bills";
			public const string UpdateBill = Base + "/bills/{billId}";
			public const string DeleteBill = Base + "/bills/{billId}";
			public const string GetBillDocument = Base + "/bills/{billId}/Document";

		}
	}
}
