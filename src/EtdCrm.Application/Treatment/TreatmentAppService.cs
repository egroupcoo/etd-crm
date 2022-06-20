using EtdCrm.Etd.Dto.Treatment.Crud;
using EtdCrm.Permissions;
using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace EtdCrm.Treatment
{

    [Authorize(EtdCrmPermissions.Treatment)]
    public class TreatmentAppService : CrudAppService<Domain.Etd.Treatment, TreatmentDto, long, PagedAndSortedResultRequestDto, TreatmentDto>, ITreatmentAppService

    {
        public TreatmentAppService(IRepository<Domain.Etd.Treatment, long> repository) : base(repository)
        {
        }


        [Authorize(EtdCrmPermissions.TreatmentCreate)]
        public override async Task<TreatmentDto> CreateAsync(TreatmentDto input)
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


        [Authorize(EtdCrmPermissions.TreatmentUpdate)]
        public override async Task<TreatmentDto> UpdateAsync(long id, TreatmentDto input)
        {
            return await base.UpdateAsync(id, input);
        }


        [Authorize(EtdCrmPermissions.TreatmentDelete)]
        public override async Task DeleteAsync(long id)
        {
            await base.DeleteAsync(id);
        }

        [Authorize(EtdCrmPermissions.TreatmentGet)]
        public override async Task<TreatmentDto> GetAsync(long id)
        {
            return await base.GetAsync(id);
        }


        [Authorize(EtdCrmPermissions.TreatmentList)]
        public override async Task<PagedResultDto<TreatmentDto>> GetListAsync(PagedAndSortedResultRequestDto input)
        {
            return await base.GetListAsync(input);
        }
    }
}
