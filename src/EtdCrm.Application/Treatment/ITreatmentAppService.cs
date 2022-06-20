using EtdCrm.Etd.Dto.Treatment.Crud;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace EtdCrm.Treatment
{
    public interface ITreatmentAppService : ICrudAppService<TreatmentDto, long, PagedAndSortedResultRequestDto, TreatmentDto>
    {
    }
}
