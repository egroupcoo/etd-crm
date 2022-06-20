using EtdCrm.Etd.Dto.Doctor.Crud;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace EtdCrm.Doctor
{
    interface  IDoctorAppService : ICrudAppService<DoctorDto, long, PagedAndSortedResultRequestDto, DoctorDto>
    {
    }
}
