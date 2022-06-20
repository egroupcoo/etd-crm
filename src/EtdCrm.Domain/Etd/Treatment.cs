using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;

namespace EtdCrm.Domain.Etd
{
	public class Treatment : FullAuditedAggregateRoot<long>, IMultiTenant
	{
        public Guid? TenantId { get; set; }

        public int OrderId { get; set; }

        public string Name { get; set; }

        public ICollection<TreatmentSub> TreatmentSub { get; set; }

        public Treatment()
        {
            TreatmentSub = new Collection<TreatmentSub>();
        }
    }
}

