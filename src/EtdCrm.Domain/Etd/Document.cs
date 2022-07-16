using System;
using System.Collections.Generic;
using EtdCrm.Etd.Enum;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;

namespace EtdCrm.Domain.Etd
{
    public class Document : FullAuditedAggregateRoot<long>, IMultiTenant
    {
        public Guid? TenantId { get; set; }

        public string Name { get; set; }

        public EnmDocumentType Type { get; set; }

        public EnmStorageProvider StorageProvider { get; set; }

        public ICollection<DocumentFile> DocumentFiles { get; set; }

        public long? RequestFormTreatmentId { get; set; }

        public RequestFormTreatment RequestFormTreatment { get; set; }

        public long? DoctorId { get; set; }

        public Doctor Doctor { get; set; }

    }
}

