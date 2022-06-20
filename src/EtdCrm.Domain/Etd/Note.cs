using System;
using System.Collections.Generic;
using EtdCrm.Etd.Enum;
using Microsoft.AspNetCore.Identity;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;

namespace EtdCrm.Domain.Etd
{
	public class Note : FullAuditedAggregateRoot<long>, IMultiTenant
    {
        public Guid? TenantId { get; set; }

        public Guid? AbpUserId { get; set; }// Foreign key referenceing the Appuser 

        public string Name { get; set; }

        public EnmNoteType Type { get; set; }

        public virtual IdentityUser AbpUser { get; set; }

        public ICollection<NoteSub> NoteSubs { get; set; }

        public long? RequestFormTreatmentId { get; set; }

        public RequestFormTreatment RequestFormTreatment { get; set; }

        public Note()
		{
		}
	}
}

