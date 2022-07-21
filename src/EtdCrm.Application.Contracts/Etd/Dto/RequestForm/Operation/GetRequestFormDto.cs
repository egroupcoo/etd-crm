using System;
using System.Collections.Generic;
using EtdCrm.Etd.Dto.Doctor.Crud;
using EtdCrm.Etd.Dto.Treatment.Crud;
using EtdCrm.Etd.Enum;

namespace EtdCrm.Etd.Dto.RequestForm.Operation
{
    public class GetRequestFormDto
    {
        public string Name { get; set; }

        public string Surname { get; set; }

        public string Description { get; set; }

        public string PhoneCode1 { get; set; }

        public string Phone1 { get; set; }

        public string Email1 { get; set; }

        public string Url { get; set; }

        public List<RequestFormTreatmentDto> Treatments { get; set; }
    }

    public class RequestFormTreatmentDto
    {
        public long Id { get; set; }
        public TreatmentDto Treatment { get; set; }
    }


}

