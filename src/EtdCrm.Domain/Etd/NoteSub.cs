using System;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;

namespace EtdCrm.Domain.Etd
{
	public class NoteSub : FullAuditedAggregateRoot<long>, IMultiTenant
	{

		public Guid? TenantId { get; set; }

		public long NoteId { get; set; }

        public string Description { get; set; }

        public Note Note { get; set; }
	}
}

