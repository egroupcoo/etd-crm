using System;
using EtdCrm.Etd.Dto.Document.CreateOrUpdate;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace EtdCrm.Document
{
	public interface IDocumentAppService : ICrudAppService<DocumentDto, long,PagedAndSortedResultRequestDto, DocumentDto>
    {
	}
}

