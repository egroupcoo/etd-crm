using System;
using System.Collections.Generic;
using EtdCrm.Etd.Enum;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;

namespace EtdCrm.Domain.Etd
{
    public class RequestForm : FullAuditedAggregateRoot<long>, IMultiTenant
	{
        public Guid? TenantId { get; protected set; }

        public EnmRequestFormStatus Status { get; set; }

        public EnmRequestFormType Type { get; set; }

        public  string Description { get; set; }

        public string IpAddress { get; set; }

        public string IpLocation { get; set; }

        public EnmLanguage Language { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public EnmGender Gender { get; set; }

        public string PhoneCode1 { get; set; }

        public string Phone1 { get; set; }

        public string PhoneCode2 { get; set; }

        public string Phone2 { get; set; }

        public string Email1 { get; set; }

        public string Email2 { get; set; }

        public string SocialMediaUrl1 { get; set; }

        public string SocialMediaUrl2 { get; set; }

        public string Address1 { get; set; }

        public string Address2 { get; set; }

        public string Iban1 { get; set; }

        public string Iban2 { get; set; }

        public string Url { get; set; }



        protected RequestForm()
        {

        }

        public RequestForm(EnmRequestFormStatus status, EnmRequestFormType type, Guid? tenantId = null)
        {
            TenantId = tenantId;
            Status = status;
            Type = type;
        }

        public void SetTenantId(Guid? tenantId)
        {
            TenantId = tenantId;
        }
    }
}

