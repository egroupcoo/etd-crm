using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EtdCrm.Etd.Dto.RequestForm.Operation;
using Microsoft.AspNetCore.Http;

namespace EtdCrm.RequestForm
{
	public interface IRequestFormService
	{
		Task<bool> SaveForm(RequestFormDto dto);
	}
}

