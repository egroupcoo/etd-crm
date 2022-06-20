using System;
using System.Collections.Generic;
using EtdCrm.Domain.Etd;
using Volo.Abp.Domain.Entities.Auditing;

namespace EtdCrm.Domain.Etd
{
	public class RequestFormTreatment : FullAuditedAggregateRoot<long>
	{

        public RequestFormTreatment(long requestFormId,long treatmentId)
        {
			RequestFormId = requestFormId;
			TreatmentId = treatmentId;
        }

		public long RequestFormId { get; set; }

		public long TreatmentId { get; set; }


        public RequestForm RequestForm { get; set; }

		public Treatment Treatment { get; set; }

		public ICollection<Document> Documents { get; set; }

		public ICollection<Note> Notes { get; set; }
	}
}

