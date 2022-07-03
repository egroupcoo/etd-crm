using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using EtdCrm.Document;
using EtdCrm.DocumentFile;
using EtdCrm.DocumentFile.YandexDisk;
using EtdCrm.Etd.Dto.Document.CreateOrUpdate;
using EtdCrm.Etd.Dto.DocumentFile.Crud;
using EtdCrm.Etd.Dto.RequestForm.Operation;
using EtdCrm.Etd.Enum;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Uow;

namespace EtdCrm.RequestForm
{
    public class RequestFormService : ApplicationService, IRequestFormService
    {
        private readonly IRepository<Domain.Etd.RequestForm, long> _requestFormRepository;
        private readonly IRepository<Domain.Etd.RequestFormTreatment, long> _requestFormreatmentRepository;
        private readonly IRepository<Domain.Etd.Treatment, long> _treatmentRepository;
        private readonly IDocumentAppService _documentAppService;
        private readonly IDocumentFileAppService _documentFileAppService;
        private readonly YandexDiskService _yandexDiskService;

        public RequestFormService(IRepository<Domain.Etd.RequestForm, long> requestFormRepository,
                                  IRepository<Domain.Etd.RequestFormTreatment, long> requestFormreatmentRepository,
                                    IRepository<Domain.Etd.Treatment, long> treatmentRepository,
                                  IDocumentAppService documentAppService, IDocumentFileAppService documentFileAppService,
                                  YandexDiskService yandexDiskService)
        {
            _requestFormRepository = requestFormRepository;
            _requestFormreatmentRepository = requestFormreatmentRepository;
            _documentAppService = documentAppService;
            _documentFileAppService = documentFileAppService;
            _yandexDiskService = yandexDiskService;
            _treatmentRepository = treatmentRepository;
        }


        public async Task<bool> SaveForm([FromForm] RequestFormDto dto)
        {

            var requestForm = ObjectMapper.Map<RequestFormDto, Domain.Etd.RequestForm>(dto);
            requestForm.SetTenantId(CurrentTenant.Id);
            var test = await _requestFormRepository.InsertAsync(requestForm, autoSave: true);


            if (dto.Treatments.Count == 0)
            {
                var treatment = _treatmentRepository.FindAsync(x => x.Name == "Unkown");
                dto.Treatments = new List<long>() { treatment.Id };
            }

            var requestFormTreatment = dto.Treatments.Select(a => new Domain.Etd.RequestFormTreatment(requestForm.Id, a));
            await _requestFormreatmentRepository.InsertManyAsync(requestFormTreatment, autoSave: true);



            if (dto.Files != null && dto.Files.Count > 0)
            {
                foreach (var file in dto.Files)
                {
                    var filepath = $"RequestForm/{DateTime.Now.ToString("yyyy-MM-dd")}";
                    await _yandexDiskService.CreateFolder(filepath);
                    await _yandexDiskService.CreateFolder($"{filepath}/{requestForm.Id}");
                    await _yandexDiskService.UploadFile($"{filepath}/{requestForm.Id}", file.FileName, file.OpenReadStream());




                    var document = new DocumentDto(EnmDocumentName.RequestForm.ToString(), EnmStorageProvider.YandexDisk, requestFormTreatment.FirstOrDefault().Id, doctorId: null);

                    await _documentAppService.CreateAsync(document);

                    var documentFile = new DocumentFileDto(document.Id, "", dto.Files.IndexOf(file), EnmFileExtension.Pdf);

                    await _documentFileAppService.CreateAsync(documentFile);
                }

            }


            return false;
        }



    }
}

