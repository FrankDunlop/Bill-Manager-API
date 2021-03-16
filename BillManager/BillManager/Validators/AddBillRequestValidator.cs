using Contracts.Contracts.Requests;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BillManager.Validators
{
	public class AddBillRequestValidator : AbstractValidator<AddBillRequest>
	{
		public AddBillRequestValidator()
		{
			RuleFor(b => b.Name)
				.Cascade(CascadeMode.StopOnFirstFailure)
				.NotEmpty().WithMessage("{PropertyName} is empty")
				.Length(1, 50).WithMessage("Length({TotalLength}) of {PropertyName} is invalid")
				.Matches("^[a-zA-Z0-9 ]*$");

			RuleFor(b => b.IsPaid)
				.Cascade(CascadeMode.StopOnFirstFailure)
				.NotEmpty().WithMessage("{PropertyName} is empty");

			RuleFor(b => b.Occurance)
				.Cascade(CascadeMode.StopOnFirstFailure)
				.NotEmpty().WithMessage("{PropertyName} is empty");

			RuleFor(b => b.PaymentType)
				.Cascade(CascadeMode.StopOnFirstFailure)
				.NotEmpty().WithMessage("{PropertyName} is empty");

			RuleFor(b => b.Notes)
				.Cascade(CascadeMode.StopOnFirstFailure)
				.Length(1, 100).WithMessage("Length({TotalLength}) of {PropertyName} is invalid")
				.Matches("^[a-zA-Z0-9 ]*$");

			RuleFor(b => b.Vendor)
				.Cascade(CascadeMode.StopOnFirstFailure)
				.NotEmpty().WithMessage("{PropertyName} is empty")
				.Length(1, 50).WithMessage("Length({TotalLength}) of {PropertyName} is invalid")
				.Matches("^[a-zA-Z0-9 ]*$");
		}
	}
}
