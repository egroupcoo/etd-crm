using EtdCrm.Etd.Enum;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace EtdCrm.Etd.Dto.Doctor.Crud
{
    public class DoctorDto : EntityDto<long>
    {
        public string Name { get; set; }

        public string Surname { get; set; }

        public DateTime BirthDay { get; set; }

        public EnmGender Gender { get; set; }

        public List<IFormFile> Files { get; set; }
    }
}
