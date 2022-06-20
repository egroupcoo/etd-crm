using EtdCrm.Etd.Dto.DocumentFile.Crud;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace EtdCrm.DocumentFile
{
    public interface IDocumentFileAppService : ICrudAppService<DocumentFileDto, long, PagedAndSortedResultRequestDto, DocumentFileDto>
    {
    }
}
