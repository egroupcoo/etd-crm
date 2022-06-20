using System;
using System.Collections.Generic;
using EtdCrm.Etd.Enum;
using Microsoft.AspNetCore.Http;

namespace EtdCrm.Etd.Dto.RequestForm.Operation
{
	public class RequestFormDto
	{

        public RequestFormDto()
        {
            Treatments = new List<long>();
        }

        public string Name { get; set; }

        public string Surname { get; set; }

        public string Description { get; set; }

        public string PhoneCode1 { get; set; }

        public string Phone1 { get; set; }

        public string Email1 { get; set; }

        public string Url { get; set; }

        public List<long> Treatments { get; set; }

        public List<IFormFile> Files { get; set; }  
    }

}

