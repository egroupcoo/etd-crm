using System;
using System.Threading.Tasks;
using EtdCrm.Etd.Dto.Document.CreateOrUpdate;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;


namespace EtdCrm.Document
{
	public class DocumentAppService : CrudAppService<Domain.Etd.Document, DocumentDto, long, PagedAndSortedResultRequestDto, DocumentDto>, IDocumentAppService
	{
		public DocumentAppService(IRepository<Domain.Etd.Document, long> repository) : base(repository)
		{

		}


        public override async Task<DocumentDto> CreateAsync(DocumentDto input)
        {
            return await base.CreateAsync(input);
        }


        public override async Task<DocumentDto> UpdateAsync(long id, DocumentDto input)
        {
            return await base.UpdateAsync(id, input);
        }


        public override async Task DeleteAsync(long id)
        {
            await base.DeleteAsync(id);
        }

        public override async Task<DocumentDto> GetAsync(long id)
        {

           //using (CurrentTenant.Change(Guid.Parse("6AAAA84A-B748-64F8-FAC4-3A035F7CB16A")))
            
           return await base.GetAsync(id);
            
        }
    }
}

