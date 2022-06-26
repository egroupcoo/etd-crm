using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using EtdCrm.Document;
using EtdCrm.DocumentFile;
using EtdCrm.DocumentFile.YandexDisk;
using EtdCrm.Etd.Dto.DocumentFile.Crud;
using Microsoft.Extensions.Hosting;
using EtdCrm.Etd.Dto.Doctor.Crud;
using EtdCrm.Etd.Dto.Document.CreateOrUpdate;
using EtdCrm.Etd.Enum;
using Microsoft.AspNetCore.Authorization;
using EtdCrm.Permissions;

namespace EtdCrm.Doctor
{

    [Authorize(EtdCrmPermissions.Doctor)]
    public class DoctorAppService : CrudAppService<Domain.Etd.Doctor, DoctorDto, long, PagedAndSortedResultRequestDto, DoctorDto>, IDoctorAppService
    {
        private readonly IRepository<Domain.Etd.Doctor, long> _doctorRepository;
        private readonly IHostEnvironment _hostEnvironment;
        private readonly IDocumentAppService _documentAppService;
        private readonly IDocumentFileAppService _documentFileAppService;
        private readonly YandexDiskService _yandexDiskService;



        public DoctorAppService(IHostEnvironment hostEnvironment, IRepository<Domain.Etd.Doctor, long> repository,
                                IDocumentAppService documentAppService, IDocumentFileAppService documentFileAppService,
                                YandexDiskService yandexDiskService) : base(repository)
        {
            _hostEnvironment = hostEnvironment;
            _documentAppService = documentAppService;
            _documentFileAppService = documentFileAppService;
            _yandexDiskService = yandexDiskService;
        }



        [Authorize(EtdCrmPermissions.DoctorCreate)]
        public override async Task<DoctorDto> CreateAsync([FromForm] DoctorDto input)
        {
            var environmentName = _hostEnvironment.EnvironmentName;

            var doctorEntity = ObjectMapper.Map<DoctorDto, Domain.Etd.Doctor>(input);

            try
            {

                var instert = _doctorRepository.InsertAsync(doctorEntity, autoSave: true);
                await CreateDocument(environmentName, instert.Id, input.Files, "Doctor");
            }
            catch (Exception ex)
            {
                var test = ex;
            }




            return input;
        }


        [Authorize(EtdCrmPermissions.DoctorUpdate)]
        public override Task<DoctorDto> UpdateAsync(long id, DoctorDto input)
        {
            return base.UpdateAsync(id, input);
        }

        [Authorize(EtdCrmPermissions.DoctorDelete)]
        public override Task DeleteAsync(long id)
        {
            return base.DeleteAsync(id);
        }


        [Authorize(EtdCrmPermissions.DoctorGet)]
        public override Task<DoctorDto> GetAsync(long id)
        {

            //using (CurrentTenant.Change(Guid.Parse("6AAAA84A-B748-64F8-FAC4-3A035F7CB16A")))

            return base.GetAsync(id);

        }



        private async Task CreateDocument(string environmentName, long doctorId, List<IFormFile> files, string operationName)
        {
            if (files != null && files.Count > 0)
            {
                foreach (var file in files)
                {
                    var filepath = $"{environmentName}/{operationName}/{DateTime.Now.ToString("yyyy-MM-dd")}";
                    await _yandexDiskService.CreateFolder(filepath);
                    await _yandexDiskService.CreateFolder($"{filepath}/{doctorId}");
                    await _yandexDiskService.UploadFile($"{filepath}/{doctorId}", file.FileName, file.OpenReadStream());

                    var document = new DocumentDto(EnmDocumentName.RequestForm.ToString(), EnmStorageProvider.YandexDisk, doctorId);

                    await _documentAppService.CreateAsync(document);

                    var documentFile = new DocumentFileDto(document.Id, "", files.IndexOf(file), EnmFileExtension.Pdf);

                    await _documentFileAppService.CreateAsync(documentFile);
                }

            }

        }
    }
}
