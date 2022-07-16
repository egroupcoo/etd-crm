using System;
using System.Threading.Tasks;
using EtdCrm.Etd.Dto.DocumentFile.YandexDisk;
using Refit;

namespace EtdCrm.DocumentFile.YandexDisk
{
    public interface IYandexDiskService
    {
        [Put("/v1/disk/resources?path={path}")]
        Task<ApiResponse<dynamic>> PutCreateFolder([Header("Authorization")] string authorization, string path);

        [Get("/v1/disk/resources/upload?path={path}/{file}")]
        Task<UploadFileResDto> UploadFileUrl([Header("Authorization")] string authorization, string path, string file);

        [Multipart]
        [Put("")]
        Task UploadFile([AliasAs("file")] ByteArrayPart bytes);

        [Get("/v1/disk/resources?path={path}/{file}")]
        Task<PublishUrlResDto> PublishUrl([Header("Authorization")] string authorization, string path, string file);

        [Delete("/v1/disk/resources?path={filePath}&permanently=true")]
        Task DeleteFile([Header("Authorization")] string authorization, string filePath);
    }
}

