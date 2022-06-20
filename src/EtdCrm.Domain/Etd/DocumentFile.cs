using System;
using EtdCrm.Etd.Enum;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;

namespace EtdCrm.Domain.Etd
{
    public class DocumentFile : FullAuditedAggregateRoot<long>, IMultiTenant
    {
        public Guid? TenantId { get; set; }

        public long DocumentId { get; set; }

        public string UrlPath { get; set; }

        public int OrderId { get; set; }

        public EnmFileExtension FileExtension { get; set; }

        public Document Document { get; set; }

    }

}

