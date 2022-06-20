using AutoMapper;
using EtdCrm.Etd;
using EtdCrm.Etd.Dto.Document.CreateOrUpdate;
using EtdCrm.Etd.Dto.Treatment.Crud;
using EtdCrm.Etd.Dto.DocumentFile.Crud;
using EtdCrm.Etd.Dto.Doctor.Crud;
using EtdCrm.Etd.Dto.RequestForm.Operation;

namespace EtdCrm;

public class EtdCrmApplicationAutoMapperProfile : Profile
{
    public EtdCrmApplicationAutoMapperProfile()
    {
        CreateMap<DocumentDto, Domain.Etd.Document>();
        CreateMap<Domain.Etd.Document, DocumentDto>();

        CreateMap<TreatmentDto, Domain.Etd.Treatment>();
        CreateMap<Domain.Etd.Treatment, TreatmentDto>();

        CreateMap<DocumentFileDto, Domain.Etd.DocumentFile>();
        CreateMap<Domain.Etd.DocumentFile, DocumentFileDto>();

        CreateMap<DoctorDto, Domain.Etd.Doctor>();
        CreateMap<Domain.Etd.Doctor, DoctorDto>();

        CreateMap<RequestFormDto, Domain.Etd.RequestForm>();
        CreateMap<Domain.Etd.RequestForm, RequestFormDto>();
    }
}
