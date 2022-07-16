using System;
using System.Linq;
using System.Threading.Tasks;
using EtdCrm.Document;
using EtdCrm.DocumentFile.YandexDisk;
using EtdCrm.Etd.Dto.DocumentFile.Crud;
using EtdCrm.Etd.Enum;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace EtdCrm.DocumentFile
{
    public class DocumentFileAppService : CrudAppService<Domain.Etd.DocumentFile, DocumentFileDto, long, PagedAndSortedResultRequestDto, DocumentFileDto>, IDocumentFileAppService
    {
        private readonly YandexDiskService _yandexDiskService;
        private readonly IHostEnvironment _hostEnvironment;
        private readonly IDocumentAppService _documentAppService;


        public DocumentFileAppService(IDocumentAppService documentAppService, IHostEnvironment hostEnvironment, IRepository<Domain.Etd.DocumentFile, long> repository, YandexDiskService yandexDiskService) : base(repository)
        {
            _yandexDiskService = yandexDiskService;
            _hostEnvironment = hostEnvironment;
            _documentAppService = documentAppService;
        }


        public override async Task<DocumentFileDto> CreateAsync([FromForm] DocumentFileDto input)
        {
            var countOrderId = (await Repository.GetQueryableAsync()).Where(x => x.DocumentId == input.DocumentId).Count();

            if (countOrderId == 0)
                input.OrderId = 1;
            else
            {
                var iQueryable = await Repository.GetQueryableAsync();
                var MaxOrderId = iQueryable.Where(x => x.DocumentId == input.DocumentId).Max(t => t.OrderId);
                input.OrderId = MaxOrderId + 1;
            }

            var entity = base.MapToEntity(input);
            base.TryToSetTenantId(entity);
            entity.UrlPath = string.Empty;
            entity.FilePath = string.Empty;
            await Repository.InsertAsync(entity, true);


            var document = await _documentAppService.GetAsync(input.DocumentId);

            string operationName = string.Empty;
            if (document.DoctorId != null)
                operationName = "Doctor";
            else if (document.RequestFormTreatmentId != null)
                operationName = "RequestFormTreatment";
            else
                operationName = "Empty";

            var environmentName = _hostEnvironment.EnvironmentName;
            var yandexFile = await YandexSaveFile(environmentName, entity.Id, input.File, operationName);

            entity.UrlPath = yandexFile.Item1;
            entity.FilePath = yandexFile.Item2;

            entity.FileExtension = GetExtension(input.File.ContentType.ToLowerInvariant());
            await Repository.UpdateAsync(entity, true);

            return input;
        }

        public override async Task DeleteAsync(long id)
        {
            var documentFile = await base.GetAsync(id);

            await _yandexDiskService.DeleteFile(documentFile.FilePath);

            await base.DeleteAsync(id);
        }

        public override Task<DocumentFileDto> GetAsync(long id)
        {
            return base.GetAsync(id);
        }

        private async Task<(string, string)> YandexSaveFile(string environmentName, long id, IFormFile file, string operationName)
        {

            await _yandexDiskService.CreateFolder(environmentName);
            await _yandexDiskService.CreateFolder($"{environmentName}/{operationName}");
            await _yandexDiskService.CreateFolder($"{environmentName}/{operationName}/{id}");
            await _yandexDiskService.CreateFolder($"{environmentName}/{operationName}/{id}/{DateTime.Now.ToString("yyyy-MM-dd")}");

            var fileName = $"{DateTime.Now.Hour}-{DateTime.Now.Minute}-{DateTime.Now.Second}-{file.FileName}";
            var filepath = $"{environmentName}/{operationName}/{id}/{DateTime.Now.ToString("yyyy-MM-dd")}";
            await _yandexDiskService.UploadFile(filepath, fileName, file.OpenReadStream());

            var publishUrl = (await _yandexDiskService.PublishUrl(filepath, fileName)).file;

            return (publishUrl, filepath + "/" + fileName);
        }

        private static EnmFileExtension GetExtension(string contentType)
        {
            switch (contentType)
            {
                case "jpg":
                case "jpeg":
                    return EnmFileExtension.Jpg;
                case "png":
                    return EnmFileExtension.Png;
                case "doc":
                    return EnmFileExtension.Doc;
                case "docx":
                    return EnmFileExtension.Docx;
                case "pdf":
                    return EnmFileExtension.Pdf;

            }


            return 0;
        }
    }
}
