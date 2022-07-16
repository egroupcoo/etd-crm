using System;
using System.Collections.Generic;
using Volo.Abp.Account;

namespace EtdCrm.Etd.Dto.ExtendProfile
{
    public class ExtendProfileDto : ProfileDto
    {
        public ExtendProfileDto()
        {
            Permissions = new Dictionary<string, bool>();
        }

        public string[] Roles { get; set; }

        public Dictionary<string, bool> Permissions { get; set; }



    }
}

