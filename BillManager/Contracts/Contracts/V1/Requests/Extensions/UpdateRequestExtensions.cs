using Contracts.Domain;

namespace Contracts.Contracts.Requests.Extensions
{
    public static class UpdateRequestExtensions
    {
        public static Bill ToBill(this UpdateBillRequest updateRequest)
        {
            return new Bill
            {
                Vendor = updateRequest.Vendor,
                Occurance = updateRequest.Occurance,
                PaymentType = updateRequest.PaymentType,
                IsPaid = updateRequest.IsPaid,
                PaidDate = updateRequest.PaidDate,
                Notes = updateRequest.Notes
            };
        }
    }
}
