using Contracts.Domain;
using System;

namespace Contracts.Contracts.Requests.Extensions
{
	public static class AddRequestExtensions
	{
        public static Bill ToBill(this AddBillRequest addRequest)
        {
            return new Bill
            {
                Id = Guid.NewGuid(),
                Name = addRequest.Name,
                Occurance = addRequest.Occurance,
                Category = addRequest.Category,
                BillDate = addRequest.BillDate,
                DueDate = addRequest.DueDate,
                PeriodFrom = addRequest.PeriodFrom,
                PeriodTo = addRequest.PeriodTo,
                Price = addRequest.Price,
                IsPaid = addRequest.IsPaid,
                PaidDate = addRequest.PaidDate,
                Document = addRequest.Document
            };
        }
	}
}
