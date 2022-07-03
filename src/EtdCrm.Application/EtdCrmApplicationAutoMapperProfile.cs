using AutoMapper;
using EtdCrm.Etd;
using EtdCrm.Etd.Dto.Document.CreateOrUpdate;
using EtdCrm.Etd.Dto.Treatment.Crud;
using EtdCrm.Etd.Dto.DocumentFile.Crud;
using EtdCrm.Etd.Dto.Doctor.Crud;
using EtdCrm.Etd.Dto.RequestForm.Operation;
using System.Collections.Generic;
using System.Linq;

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
        CreateMap<Domain.Etd.Document, GetDoctorDocumentDto>().ForMember(x => x.Files, opt => opt.MapFrom(src => src.DocumentFiles));
        CreateMap<Domain.Etd.DocumentFile, GetDoctorDocumentFileDto>();
        CreateMap<Domain.Etd.Doctor, GetDoctorDto>().ForMember(x => x.GetDoctorDocuments, opt => opt.MapFrom(src => src.Documents));

        CreateMap<RequestFormDto, Domain.Etd.RequestForm>();
        CreateMap<Domain.Etd.RequestForm, RequestFormDto>();
    }
}
