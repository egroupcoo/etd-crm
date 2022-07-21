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
using Microsoft.EntityFrameworkCore;
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

        public RequestFormService(IRepository<Domain.Etd.RequestForm, long> requestFormRepository,
                                  IRepository<Domain.Etd.RequestFormTreatment, long> requestFormreatmentRepository,
                                  IRepository<Domain.Etd.Treatment, long> treatmentRepository,
                                  IDocumentAppService documentAppService, IDocumentFileAppService documentFileAppService)
        {
            _requestFormRepository = requestFormRepository;
            _requestFormreatmentRepository = requestFormreatmentRepository;
            _documentAppService = documentAppService;
            _documentFileAppService = documentFileAppService;
            _treatmentRepository = treatmentRepository;
        }

        public async Task<GetRequestFormDto> GetFullGetAsync(long id)
        {
            var iQueryable = await _requestFormRepository.GetQueryableAsync();
            var requestFormEntity = await iQueryable.Include(x => x.Treatments).ThenInclude(a => a.Treatment).FirstOrDefaultAsync(x => x.Id == id);

            var requestForm = ObjectMapper.Map<Domain.Etd.RequestForm, GetRequestFormDto>(requestFormEntity);

            return requestForm;
        }

        public async Task<bool> SaveForm([FromForm] RequestFormDto dto)
        {

            var requestForm = ObjectMapper.Map<RequestFormDto, Domain.Etd.RequestForm>(dto);
            await _requestFormRepository.InsertAsync(requestForm, autoSave: true);


            if (dto.Treatments.Count == 0)
            {
                var treatment = await _treatmentRepository.FindAsync(x => x.Name == "Unkown");
                dto.Treatments = new List<long>() { treatment.Id };
            }

            var requestFormTreatments = dto.Treatments.Select(a => new Domain.Etd.RequestFormTreatment(requestForm.Id, a)).ToList();

            foreach (var itemRequestFormTreatment in requestFormTreatments)
            {
                await _requestFormreatmentRepository.InsertAsync(itemRequestFormTreatment, autoSave: true);
            }


            if (dto.Files != null && dto.Files.Count > 0)
            {

                var document = new DocumentDto(EnmDocumentType.RequestForm.ToString(), EnmDocumentType.RequestForm, EnmStorageProvider.YandexDisk, requestFormTreatments.FirstOrDefault().Id, doctorId: null);

                document = await _documentAppService.CreateAsync(document);

                foreach (var file in dto.Files)
                {

                    var documentFile = new DocumentFileDto() { DocumentId = document.Id, File = file };

                    await _documentFileAppService.CreateAsync(documentFile);
                }

            }


            return true;
        }



    }
}

