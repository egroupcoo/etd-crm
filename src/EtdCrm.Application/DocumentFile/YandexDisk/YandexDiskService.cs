using System;
using System.IO;
using System.Threading.Tasks;
using EtdCrm.Etd.Dto.DocumentFile.YandexDisk;
using Refit;
using Volo.Abp.DependencyInjection;

namespace EtdCrm.DocumentFile.YandexDisk
{
    public class YandexDiskService : ITransientDependency
    {

        public async Task<bool> CreateFolder(string path)
        {
            try
            {
                var yandexApi = RestService.For<IYandexDiskService>("https://cloud-api.yandex.net");


                var token = "OAuth AQAAAABhH5G7AAfltNGyp6-ZtU60mOqUX3HXrLM";

                await yandexApi.PutCreateFolder(token, path);

                return true;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public async Task<bool> UploadFile(string path, string file, Stream stream)
        {
            try
            {
                var yandexApi = RestService.For<IYandexDiskService>("https://cloud-api.yandex.net");

                var token = "OAuth AQAAAABhH5G7AAfltNGyp6-ZtU60mOqUX3HXrLM";

                var uploadFileUrl = await yandexApi.UploadFileUrl(token, path, file);

                using (MemoryStream ms = new MemoryStream())
                {
                    stream.CopyTo(ms);

                    var data = new ByteArrayPart(ms.ToArray(), file);

                    yandexApi = RestService.For<IYandexDiskService>(uploadFileUrl.href);

                    await yandexApi.UploadFile(data);
                }

                return true;

            }
            catch (Exception ex)
            {
                return false;
            }


        }

        public async Task<PublishUrlResDto> PublishUrl(string path, string file)
        {
            var yandexApi = RestService.For<IYandexDiskService>("https://cloud-api.yandex.net");

            var token = "OAuth AQAAAABhH5G7AAfltNGyp6-ZtU60mOqUX3HXrLM";

            var uploadFileUrl = await yandexApi.PublishUrl(token, path, file);

            return uploadFileUrl;

        }




    }


}

