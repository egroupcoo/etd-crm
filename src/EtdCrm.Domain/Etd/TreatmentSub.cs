using System;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;

namespace EtdCrm.Domain.Etd
{
	public class TreatmentSub : FullAuditedAggregateRoot<long>, IMultiTenant
	{
		public Guid? TenantId { get; set; }

		public long TreatmentId { get; set; }

		public int OrderId { get; set; }

		public string Name { get; set; }

        public Treatment Treatment { get; set; }
    }
}