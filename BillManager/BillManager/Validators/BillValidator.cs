using Contracts.Domain;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BillManager.Validators
{
	public class BillValidator: AbstractValidator<Bill>
	{
		public BillValidator()
		{
			RuleFor(b => b.Name)
				.Cascade(CascadeMode.StopOnFirstFailure)
				.NotEmpty().WithMessage("{PropertyName} is empty")
				.Length(1,50).WithMessage("Length({TotalLength}) of {PropertyName} is invalid")
				.Matches("^[a-zA-Z0-9 ]*$");

			RuleFor(b => b.BillDate)
				.Must(BeValidDate).WithMessage("{PropertyName} invalid date");
		}
			
		private bool BeValidDate(DateTime date)
		{
			if (date.Year < DateTime.Now.Year)
				return false;

			return true;
		}
	}
}
