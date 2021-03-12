using BillManager.Services;
using Contracts.Contracts;
using Contracts.Contracts.Requests;
using Contracts.Contracts.Responses;
using Contracts.Domain;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace BillManager.Controllers
{
	public class BillsController : Controller
	{
		private IBillService _billService;

		public BillsController(IBillService billService)
		{
			_billService = billService;
		}

		[HttpGet(ApiRoutes.Bills.GetBills)]
		public IActionResult GetBills()
		{
			return Ok(_billService.GetBills());
		}

		[HttpGet(ApiRoutes.Bills.GetBill)]
		public IActionResult GetBill([FromRoute] int billId)
		{
			var bill = _billService.GetBill(billId);

			if (bill == null)
				return NotFound();

			return Ok(bill);
		}

		[HttpPost(ApiRoutes.Bills.AddBill)]
		public IActionResult AddBill([FromBody] AddBillRequest billRequest)
		{
			var bill = new Bill { 
				Id = billRequest.Id,  
				Name = billRequest.Name
			};

			_billService.GetBills().Add(bill);

			var baseUrl = $"{HttpContext.Request.Scheme}://{HttpContext.Request.Host.ToUriComponent()}";
			var locationUri = baseUrl + "/" + ApiRoutes.Bills.GetBill.Replace("{billId}", bill.Id.ToString());

			var response = new AddBillResponse { Id = bill.Id };
			return Created(locationUri, response);
		}

		[HttpPut(ApiRoutes.Bills.UpdateBill)]
		public IActionResult Update([FromRoute] int billId, [FromBody] UpdateBillRequest request)
		{
			var bill = new Bill
			{
				Id = billId,
				Name = request.Name
			};

			var updated = _billService.UpdateBill(bill);

			if (updated)
				return Ok(bill);

			return NotFound();
		}

		[HttpDelete(ApiRoutes.Bills.DeleteBill)]
		public IActionResult Delete([FromRoute] int billId)
		{
			var deleted = _billService.DeleteBill(billId);

			if (deleted)
				return NoContent();

			return NotFound();
		}
	}
}
