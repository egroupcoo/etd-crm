using AutoMapper;
using EtdCrm.Etd;
using EtdCrm.Etd.Dto.Document.CreateOrUpdate;
using EtdCrm.Etd.Dto.Treatment.Crud;
using EtdCrm.Etd.Dto.DocumentFile.Crud;
using EtdCrm.Etd.Dto.Doctor.Crud;
using EtdCrm.Etd.Dto.RequestForm.Operation;
using System.Collections.Generic;
using System.Linq;
using Volo.Abp.Account;
using EtdCrm.Etd.Dto.ExtendProfile;

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
        CreateMap<Domain.Etd.Doctor, GetDoctorDto>().ForMember(x => x.Documents, opt => opt.MapFrom(src => src.Documents));

        CreateMap<Domain.Etd.Doctor, ListDoctorDto>().ForMember(x => x.PhotoUrl, opt => opt.MapFrom(src => src.Documents
                                                                                                              .FirstOrDefault(a => a.Type == Etd.Enum.EnmDocumentType.ProfilePhoto)
                                                                                                              .DocumentFiles.FirstOrDefault().UrlPath
                                                                                                              ));

        CreateMap<RequestFormDto, Domain.Etd.RequestForm>();
        CreateMap<Domain.Etd.RequestForm, RequestFormDto>();


        CreateMap<Domain.Etd.RequestFormTreatment, RequestFormTreatmentDto>();
        CreateMap<Domain.Etd.RequestForm, GetRequestFormDto>();

        CreateMap<Volo.Abp.Identity.IdentityUser, ExtendProfileDto>();

    }
}
