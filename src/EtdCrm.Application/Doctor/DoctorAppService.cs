using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;
using EtdCrm.Etd.Dto.Doctor.Crud;

namespace EtdCrm.Doctor
{
    public class DoctorAppService : CrudAppService<Domain.Etd.Doctor, DoctorDto, long, PagedAndSortedResultRequestDto, DoctorDto>, IDoctorAppService
    {
        public DoctorAppService(IRepository<Domain.Etd.Doctor, long> repository) : base(repository)
        {
        }


        public override Task<DoctorDto> CreateAsync(DoctorDto input)
        {
            return base.CreateAsync(input);
        }


        public override Task<DoctorDto> UpdateAsync(long id, DoctorDto input)
        {
            return base.UpdateAsync(id, input);
        }


        public override Task DeleteAsync(long id)
        {
            return base.DeleteAsync(id);
        }

        public override Task<DoctorDto> GetAsync(long id)
        {

            //using (CurrentTenant.Change(Guid.Parse("6AAAA84A-B748-64F8-FAC4-3A035F7CB16A")))

            return base.GetAsync(id);

        }
    }
}
