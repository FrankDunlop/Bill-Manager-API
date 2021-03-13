using BillManager.Services;
using Contracts.Contracts;
using Contracts.Contracts.Requests;
using Contracts.Contracts.Responses;
using Contracts.Domain;
using Microsoft.AspNetCore.Mvc;
using System;
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

		[HttpGet(ApiRoutes.Bills.GetBillsByName)]
		public IActionResult GetBillsByName([FromRoute] string name)
		{
			var bills = _billService.GetBills(name: name);

			if (bills == null)
				return NotFound();

			return Ok(bills);
		}

		[HttpGet(ApiRoutes.Bills.GetBillsByVendor)]
		public IActionResult GetBillsByVendor([FromRoute] string vendor)
		{
			var bills = _billService.GetBills(vendor: vendor);

			if (bills == null)
				return NotFound();

			return Ok(bills);
		}

		[HttpGet(ApiRoutes.Bills.GetBill)]
		public IActionResult GetBill([FromRoute] Guid billId)
		{
			var bill = _billService.GetBill(billId);

			if (bill == null)
				return NotFound();

			return Ok(bill);
		}

		[HttpPost(ApiRoutes.Bills.AddBill)]
		public IActionResult AddBill([FromBody] AddBillRequest addRequest)
		{
			var bill = new Bill {
				Id = Guid.NewGuid(),
				Name = addRequest.Name,
				Occurance = addRequest.Occurance,
				Category = addRequest.Category,
				BillDate = addRequest.BillDate,
				PeriodFrom = addRequest.PeriodFrom,
				PeriodTo = addRequest.PeriodTo,
				Price = addRequest.Price,
				IsPaid = addRequest.IsPaid,
				PaidDate = addRequest.PaidDate,
				Document = addRequest.Document
			};

			_billService.GetBills().ToList().Add(bill);

			var baseUrl = $"{HttpContext.Request.Scheme}://{HttpContext.Request.Host.ToUriComponent()}";
			var locationUri = baseUrl + "/" + ApiRoutes.Bills.GetBill.Replace("{billId}", bill.Id.ToString());

			var response = new AddBillResponse { Id = bill.Id };
			return Created(locationUri, response);
		}

		[HttpPut(ApiRoutes.Bills.UpdateBill)]
		public IActionResult Update([FromRoute] Guid billId, [FromBody] UpdateBillRequest updateRequest)
		{
			var bill = new Bill
			{
				Id = billId,
				IsPaid = updateRequest.IsPaid,
				PaidDate = updateRequest.PaidDate,
			};

			var updated = _billService.UpdateBill(bill);

			if (updated)
				return Ok(bill);

			return NotFound();
		}

		[HttpDelete(ApiRoutes.Bills.DeleteBill)]
		public IActionResult Delete([FromRoute] Guid billId)
		{
			var deleted = _billService.DeleteBill(billId);

			if (deleted)
				return NoContent();

			return NotFound();
		}

		[HttpGet(ApiRoutes.Bills.GetBillDocument)]
		public IActionResult GetBillDocument([FromRoute] Guid billId)
		{
			var document = _billService.GetBillDocument(billId);

			if (document == null)
				return NotFound();

			return Ok(document);
		}
	}
}
