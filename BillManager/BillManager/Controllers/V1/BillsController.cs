using Contracts.Contracts;
using Contracts.Domain;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace BillManager.Controllers
{
	public class BillsController : Controller
	{
		private List<Bill> bills;

		public BillsController()
		{
			bills = new List<Bill>(){
				new Bill{Id = 1},
				new Bill{Id = 2}
			};
		}

		[HttpGet(ApiRoutes.Bills.GetBills)]
		public IActionResult GetBills()
		{
			return Ok(bills);
		}
		

	}
}
