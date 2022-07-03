using System;
using System.Collections.Generic;
using EtdCrm.Etd.Enum;

namespace EtdCrm.Etd.Dto.Doctor.Crud
{
    public class GetDoctorDto
    {

        public string Name { get; set; }

        public string Surname { get; set; }

        public DateTime BirthDay { get; set; }

        public EnmGender Gender { get; set; }

        public List<GetDoctorDocumentDto> GetDoctorDocuments { get; set; }
    }

    public class GetDoctorDocumentDto
    {
        public long Id { get; set; }
        public List<GetDoctorDocumentFileDto> Files { get; set; }
    }

    public class GetDoctorDocumentFileDto
    {
        public long Id { get; set; }
        public string UrlPath { get; set; }

    }
}

