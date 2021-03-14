using BillManager.Services;
using Contracts.Contracts;
using Contracts.Contracts.Requests;
using Contracts.Contracts.Requests.Extensions;
using Contracts.Contracts.Responses;
using Contracts.Domain;
using Contracts.Domain.Extensions;
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
			var bills = _billService.GetBills();

			if (bills == null)
				return NotFound();

			var getBillResponse = bills.Select(bill => bill.ToBillResponse());

			return Ok(getBillResponse);
		}

		[HttpGet(ApiRoutes.Bills.GetBillsByName)]
		public IActionResult GetBillsByName([FromRoute] string name)
		{
			var bills = _billService.GetBills(name: name);

			if (bills == null)
				return NotFound();

			return Ok(bills.Select(bill => bill.ToBillResponse()));
		}

		[HttpGet(ApiRoutes.Bills.GetBillsByVendor)]
		public IActionResult GetBillsByVendor([FromRoute] string vendor)
		{
			var bills = _billService.GetBills(vendor: vendor);

			if (bills == null)
				return NotFound();

			return Ok(bills.Select(bill => bill.ToBillResponse()));
		}

		[HttpGet(ApiRoutes.Bills.GetBill)]
		public IActionResult GetBill([FromRoute] Guid billId)
		{
			var bill = _billService.GetBill(billId);

			if (bill == null)
				return NotFound();

			return Ok(bill.ToBillResponse());
		}

		[HttpPost(ApiRoutes.Bills.AddBill)]
		public IActionResult AddBill([FromBody] AddBillRequest addRequest)
		{
			var bill = _billService.AddBill(addRequest.ToBill());

			var baseUrl = $"{HttpContext.Request.Scheme}://{HttpContext.Request.Host.ToUriComponent()}";
			var locationUri = baseUrl + "/" + ApiRoutes.Bills.GetBill.Replace("{billId}", bill.Id.ToString());

			return Created(locationUri, bill.ToBillResponse());
		}

		[HttpPut(ApiRoutes.Bills.UpdateBill)]
		public IActionResult Update([FromRoute] Guid billId, [FromBody] UpdateBillRequest updateRequest)
		{
			var bill = _billService.UpdateBill(billId, updateRequest.ToBill());

			if (bill != null)
				return Ok(bill.ToBillResponse());

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
