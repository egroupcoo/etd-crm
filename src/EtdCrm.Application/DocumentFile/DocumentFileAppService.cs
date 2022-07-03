using EtdCrm.Etd.Dto.DocumentFile.Crud;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace EtdCrm.DocumentFile
{
    public class DocumentFileAppService : CrudAppService<Domain.Etd.DocumentFile, DocumentFileDto, long, PagedAndSortedResultRequestDto, DocumentFileDto>, IDocumentFileAppService
    {
        public DocumentFileAppService(IRepository<Domain.Etd.DocumentFile, long> repository) : base(repository)
        {
        }


        public override async Task<DocumentFileDto> CreateAsync(DocumentFileDto input)
        {
            var countOrderId = await Repository.CountAsync();

            if (countOrderId == 0)
            {
                input.OrderId = 1;

            }
            else
            {
                var MaxOrderId = await Repository.MaxAsync(x => x.OrderId);
                input.OrderId = MaxOrderId + 1;
            }

            try
            {

                var entity = base.MapToEntity(input);
                base.TryToSetTenantId(entity);
                await Repository.InsertAsync(entity, true);

                return input;
            }
            catch (Exception ex)
            {
                return null;
            }




        }

        public override Task<DocumentFileDto> UpdateAsync(long id, DocumentFileDto input)
        {
            return base.UpdateAsync(id, input);
        }

        public override Task DeleteAsync(long id)
        {
            return base.DeleteAsync(id);
        }

        public override Task<DocumentFileDto> GetAsync(long id)
        {
            return base.GetAsync(id);
        }

        public override Task<PagedResultDto<DocumentFileDto>> GetListAsync(PagedAndSortedResultRequestDto input)
        {
            return base.GetListAsync(input);
        }
    }
}
