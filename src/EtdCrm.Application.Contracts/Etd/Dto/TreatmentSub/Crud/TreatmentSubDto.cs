using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace EtdCrm.Etd.Dto.TreatmentSub.Crud
{
    public class TreatmentSubDto : EntityDto<long>
    {
       

        public long TreatmentId { get; set; }

        public int OrderId { get; set; }

        public string Name { get; set; }
    }
}
