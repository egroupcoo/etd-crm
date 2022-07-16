using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using EtdCrm.Document;
using EtdCrm.DocumentFile;
using EtdCrm.DocumentFile.YandexDisk;
using EtdCrm.Etd.Dto.DocumentFile.Crud;
using Microsoft.Extensions.Hosting;
using EtdCrm.Etd.Dto.Doctor.Crud;
using EtdCrm.Etd.Dto.Document.CreateOrUpdate;
using EtdCrm.Etd.Enum;
using Microsoft.AspNetCore.Authorization;
using EtdCrm.Permissions;
using System.Threading;
using Volo.Abp.EntityFrameworkCore;
using EtdCrm.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;

namespace EtdCrm.Doctor
{

    //[Authorize(EtdCrmPermissions.Doctor)]
    public class DoctorAppService : CrudAppService<Domain.Etd.Doctor, DoctorDto, long, PagedAndSortedResultRequestDto, DoctorDto>, IDoctorAppService
    {

        public DoctorAppService(IRepository<Domain.Etd.Doctor, long> repository) : base(repository)
        {
        }


        //[Authorize(EtdCrmPermissions.DoctorCreate)]
        public override async Task<DoctorDto> CreateAsync(DoctorDto input)
        {
            var doctorEntity = await base.MapToEntityAsync(input);
            base.TryToSetTenantId(doctorEntity);
            await Repository.InsertAsync(doctorEntity, autoSave: true, CancellationToken.None);

            return input;
        }


        //[Authorize(EtdCrmPermissions.DoctorUpdate)]
        public override Task<DoctorDto> UpdateAsync(long id, DoctorDto input)
        {
            return base.UpdateAsync(id, input);
        }

        //[Authorize(EtdCrmPermissions.DoctorDelete)]
        public override Task DeleteAsync(long id)
        {
            return base.DeleteAsync(id);
        }

        protected override Task<IQueryable<Domain.Etd.Doctor>> CreateFilteredQueryAsync(PagedAndSortedResultRequestDto input)
        {
            return base.CreateFilteredQueryAsync(input);
        }


        //[Authorize(EtdCrmPermissions.DoctorGet)]
        public async Task<GetDoctorDto> GetFullGetAsync(long id)
        {
            var iQueryable = await Repository.GetQueryableAsync();
            var doctorEntity = await iQueryable.Include(x => x.Documents)
                                               .ThenInclude(y => y.DocumentFiles).FirstOrDefaultAsync(x => x.Id == id);

            var doctor = ObjectMapper.Map<Domain.Etd.Doctor, GetDoctorDto>(doctorEntity);

            return doctor;
        }



        public async Task<List<ListDoctorDto>> GetFullListAsync(int skipCount, int maxResultCount, string searchKeyword)
        {
            var iQueryable = await Repository.GetQueryableAsync();

            if (!string.IsNullOrEmpty(searchKeyword))
                iQueryable = iQueryable.Where(x => x.Name.Contains(searchKeyword) || x.Surname.Contains(searchKeyword));


            var doctorEntity = await iQueryable.Include(x => x.Documents).ThenInclude(y => y.DocumentFiles).Skip(skipCount).Take(maxResultCount).ToListAsync();

            var doctor = ObjectMapper.Map<List<Domain.Etd.Doctor>, List<ListDoctorDto>>(doctorEntity);

            return doctor;
        }

    }



}
