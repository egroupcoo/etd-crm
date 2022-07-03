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
using System.Threading;
using Volo.Abp.EntityFrameworkCore;
using EtdCrm.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;

namespace EtdCrm.Doctor
{

    //[Authorize(EtdCrmPermissions.Doctor)]
    public class DoctorAppService : CrudAppService<Domain.Etd.Doctor, DoctorDto, long, PagedAndSortedResultRequestDto, DoctorDto>, IDoctorAppService
    {
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


        //[Authorize(EtdCrmPermissions.DoctorCreate)]
        public override async Task<DoctorDto> CreateAsync([FromForm] DoctorDto input)
        {
            var environmentName = _hostEnvironment.EnvironmentName;

            var doctorEntity = await base.MapToEntityAsync(input);
            base.TryToSetTenantId(doctorEntity);
            await Repository.InsertAsync(doctorEntity, autoSave: true, CancellationToken.None);

            await CreateDocument(environmentName, doctorEntity.Id, input.Files, "Doctor");

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


        //[Authorize(EtdCrmPermissions.DoctorGet)]
        public async Task<GetDoctorDto> GetFullGetAsync(long id)
        {
            var iQueryable = await Repository.GetQueryableAsync();
            var doctorEntity = await iQueryable.Include(x => x.Documents)
                                               .ThenInclude(y => y.DocumentFiles).FirstOrDefaultAsync(x => x.Id == id);

            var doctor = ObjectMapper.Map<Domain.Etd.Doctor, GetDoctorDto>(doctorEntity);

            return doctor;
        }



        private async Task CreateDocument(string environmentName, long doctorId, List<IFormFile> files, string operationName)
        {
            if (files != null && files.Count > 0)
            {
                await _yandexDiskService.CreateFolder(environmentName);
                await _yandexDiskService.CreateFolder($"{environmentName}/{operationName}");
                await _yandexDiskService.CreateFolder($"{environmentName}/{operationName}/{doctorId}");
                await _yandexDiskService.CreateFolder($"{environmentName}/{operationName}/{doctorId}/{DateTime.Now.ToString("yyyy-MM-dd")}");

                foreach (var file in files)
                {

                    var fileName = $"{DateTime.Now.Hour}-{DateTime.Now.Minute}-{DateTime.Now.Second}-{file.FileName}";
                    var filepath = $"{environmentName}/{operationName}/{doctorId}/{DateTime.Now.ToString("yyyy-MM-dd")}";
                    await _yandexDiskService.UploadFile(filepath, fileName, file.OpenReadStream());

                    var publishUrl = (await _yandexDiskService.PublishUrl(filepath, fileName)).file;

                    var document = new DocumentDto(EnmDocumentName.RequestForm.ToString(), EnmStorageProvider.YandexDisk, requestFormTreatmentId: null, doctorId: doctorId);

                    var entityDocument = await _documentAppService.CreateAsync(document);

                    var documentFile = new DocumentFileDto(entityDocument.Id, publishUrl, files.IndexOf(file), EnmFileExtension.Png);

                    await _documentFileAppService.CreateAsync(documentFile);
                }

            }

        }
    }



}
