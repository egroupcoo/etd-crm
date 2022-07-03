using System;
using System.Collections.Generic;
using EtdCrm.Etd.Enum;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;

namespace EtdCrm.Domain.Etd
{
    public class Doctor : FullAuditedAggregateRoot<long>, IMultiTenant
    {
        public Guid? TenantId { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public DateTime BirthDay { get; set; }

        public EnmGender Gender { get; set; }

        public virtual ICollection<Document> Documents { get; set; }

        public void SetTenantId(Guid? tenantId)
        {
            TenantId = tenantId;
        }
    }
}

