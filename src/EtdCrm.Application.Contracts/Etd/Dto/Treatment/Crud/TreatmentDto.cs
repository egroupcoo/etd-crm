using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace EtdCrm.Etd.Dto.Treatment.Crud
{
    public class TreatmentDto : EntityDto<long>
    {
        public int OrderId { get; set; }

        public string Name { get; set; }
    }
}
