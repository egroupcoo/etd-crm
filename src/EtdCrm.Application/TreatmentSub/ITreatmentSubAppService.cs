using EtdCrm.Etd.Dto.TreatmentSub.Crud;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace EtdCrm.TreatmentSub
{
    public interface ITreatmentSubAppService : ICrudAppService<TreatmentSubDto, long, PagedAndSortedResultRequestDto, TreatmentSubDto>
    {
    }
}
