using Contracts.Contracts.Responses;
using System;

namespace Contracts.Domain.Extensions
{
    //Service domain object to response
	public static class BillExtensions
	{
        public static BillResponse ToBillResponse(this Bill bill)
        {
            return new BillResponse
            {
                Id = bill.Id,
                Name = bill.Name,
                Occurance = bill.Occurance,
                Category = bill.Category,
                BillDate = bill.BillDate,
                DueDate = bill.DueDate,
                PeriodFrom = bill.PeriodFrom,
                PeriodTo = bill.PeriodTo,
                Price = bill.Price,
                IsPaid = bill.IsPaid,
                PaidDate = bill.PaidDate,
                Document = bill.Document
            };
        }

        public static BillDto ToBillDto(this Bill bill)
        {
            return new BillDto
            {
                Id = bill.Id,
                Name = bill.Name,
                Occurance = bill.Occurance,
                Category = bill.Category,
                BillDate = bill.BillDate,
                DueDate = bill.DueDate,
                PeriodFrom = bill.PeriodFrom,
                PeriodTo = bill.PeriodTo,
                Price = bill.Price,
                IsPaid = bill.IsPaid,
                PaidDate = bill.PaidDate,
                Document = bill.Document
            };
        }
    }
}
