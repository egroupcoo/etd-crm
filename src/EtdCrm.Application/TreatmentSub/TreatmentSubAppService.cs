using EtdCrm.Etd.Dto.Treatment.Crud;
using EtdCrm.Etd.Dto.TreatmentSub.Crud;
using EtdCrm.Treatment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace EtdCrm.TreatmentSub
{
    public class TreatmentSubAppService : CrudAppService<Domain.Etd.TreatmentSub, TreatmentSubDto, long, PagedAndSortedResultRequestDto, TreatmentSubDto>, ITreatmentSubAppService


    {
        public TreatmentSubAppService(IRepository<Domain.Etd.TreatmentSub, long> repository) : base(repository)
        {

        }
        public override async Task<TreatmentSubDto> CreateAsync(TreatmentSubDto input)
        {
            var countOrderId = await Repository.CountAsync();

            if (countOrderId == 0)
                input.OrderId = 1;
            else
            {
                var maxOrderId = await Repository.MaxAsync(x => x.OrderId);
                input.OrderId = maxOrderId + 1;
            }
            return await base.CreateAsync(input);
        }
        public override Task<TreatmentSubDto> UpdateAsync(long id, TreatmentSubDto input)
        {
            return base.UpdateAsync(id, input);
        }
        public override Task DeleteAsync(long id)
        {
            return base.DeleteAsync(id);
        }
        public override Task<TreatmentSubDto> GetAsync(long id)
        {
            return base.GetAsync(id);
        }
        public override Task<PagedResultDto<TreatmentSubDto>> GetListAsync(PagedAndSortedResultRequestDto input)
        {
            return base.GetListAsync(input);
        }
    }
}
