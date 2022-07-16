using EtdCrm.Etd.Enum;
using Volo.Abp.Application.Dtos;


namespace EtdCrm.Etd.Dto.Document.CreateOrUpdate
{
    public class DocumentDto : EntityDto<long>
    {
        public string Name { get; set; }

        public EnmDocumentType Type { get; set; }

        public EnmStorageProvider StorageProvider { get; set; }

        public long? RequestFormTreatmentId { get; set; }

        public long? DoctorId { get; set; }

        public DocumentDto(string name, EnmStorageProvider storageProvider, long? requestFormTreatmentId, long? doctorId)
        {
            Name = name;
            StorageProvider = storageProvider;
            RequestFormTreatmentId = requestFormTreatmentId;
            DoctorId = doctorId;
        }
    }
}

