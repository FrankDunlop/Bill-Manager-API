using BillManager.Services;
using BillManager.Validators;
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
using System.Threading.Tasks;

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
		public async Task<IActionResult> GetBills()
		{
			var bills = await _billService.GetBillsAsync();

			if (bills == null)
				return NotFound();

			return Ok(bills.Select(bill => bill.ToBillResponse()));
		}

		[HttpGet(ApiRoutes.Bills.GetBillsByName)]
		public async Task<IActionResult> GetBillsByName([FromRoute] string name)
		{
			var bills = await _billService.GetBillsAsync(name: name);

			if (bills == null)
				return NotFound();

			return Ok(bills.Select(bill => bill.ToBillResponse()));
		}

		[HttpGet(ApiRoutes.Bills.GetBillsByVendor)]
		public async Task<IActionResult> GetBillsByVendor([FromRoute] string vendor)
		{
			var bills = await _billService.GetBillsAsync(vendor: vendor);

			if (bills == null)
				return NotFound();

			return Ok(bills.Select(bill => bill.ToBillResponse()));
		}

		[HttpGet(ApiRoutes.Bills.GetBill)]
		public async Task<IActionResult> GetBill([FromRoute] Guid billId)
		{
			var bill = await _billService.GetBillAsync(billId);

			if (bill == null)
				return NotFound();

			return Ok(bill.ToBillResponse());
		}

		[HttpPost(ApiRoutes.Bills.AddBill)]
		public async Task<IActionResult> AddBill([FromBody] AddBillRequest addRequest)
		{
			var bill = addRequest.ToBill();
			var added = await _billService.AddBillAsync(addRequest.ToBill());

			if (!added)
				NotFound();

			var baseUrl = $"{HttpContext.Request.Scheme}://{HttpContext.Request.Host.ToUriComponent()}";
			var locationUri = baseUrl + "/" + ApiRoutes.Bills.GetBill.Replace("{billId}", bill.Id.ToString());

			return Created(locationUri, bill.ToBillResponse());
		}

		[HttpPut(ApiRoutes.Bills.UpdateBill)]
		public async Task<IActionResult> Update([FromRoute] Guid billId, [FromBody] UpdateBillRequest updateRequest)
		{
			var bill = updateRequest.ToBill();
			var updated = await _billService.UpdateBillAsync(bill);

			if (!updated)
				return NotFound();

			return Ok(bill.ToBillResponse());
		}

		[HttpDelete(ApiRoutes.Bills.DeleteBill)]
		public async Task<IActionResult> Delete([FromRoute] Guid billId)
		{
			var deleted = await _billService.DeleteBillAsync(billId);

			if (!deleted)
				return NotFound();

			return NoContent();
		}

		[HttpGet(ApiRoutes.Bills.GetBillDocument)]
		public async Task<IActionResult> GetBillDocument([FromRoute] Guid billId)
		{
			var document = await _billService.GetBillDocumentAsync(billId);

			if (document == null)
				return NotFound();

			return Ok(document);
		}
	}
}
