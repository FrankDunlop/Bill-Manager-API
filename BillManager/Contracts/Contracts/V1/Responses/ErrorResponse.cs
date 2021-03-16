using Contracts.Contracts.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.Contracts.Responses
{
	public class ErrorResponse
	{
		public List<ErrorModel> Errors { get; set; } = new List<ErrorModel>(); 
	}
}
