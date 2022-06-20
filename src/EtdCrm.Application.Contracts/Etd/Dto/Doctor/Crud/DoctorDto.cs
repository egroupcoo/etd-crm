using EtdCrm.Etd.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace EtdCrm.Etd.Dto.Doctor.Crud
{
    public class DoctorDto :EntityDto<long>
    {
        public string Name { get; set; }

        public string Surname { get; set; }
        
        [Range(typeof(DateTime), "1/1/1920", "1/1/2010", ErrorMessage = "Value for {0} must be between {1} and {2}")]
        public DateTime BirthDay { get; set; }

        public EnmGender Gender { get; set; }
    }
}
