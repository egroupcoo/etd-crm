using System;
using System.IO;
using System.Threading.Tasks;
using Refit;
using Volo.Abp.DependencyInjection;

namespace EtdCrm.DocumentFile.YandexDisk
{
	public class YandexDiskService : ITransientDependency
	{

		public  async Task<bool> CreateFolder(string path)
        {
			var yandexApi = RestService.For<IYandexDiskService>("https://cloud-api.yandex.net");

			var token = "OAuth AQAAAABhH5G7AAfltNGyp6-ZtU60mOqUX3HXrLM";

			await yandexApi.PutCreateFolder(token, path);

			return true;
		}

        public async Task<bool> UploadFile(string path, string file, Stream stream)
        {
			var yandexApi = RestService.For<IYandexDiskService>("https://cloud-api.yandex.net");

			var token = "OAuth AQAAAABhH5G7AAfltNGyp6-ZtU60mOqUX3HXrLM";

			var uploadFileUrl = await yandexApi.UploadFileUrl(token, path, file);

     		using (MemoryStream ms = new MemoryStream())
			{
 			 stream.CopyTo(ms);

			 var data = new ByteArrayPart(ms.ToArray(), file);

			 yandexApi = RestService.For<IYandexDiskService>(uploadFileUrl.Url);

			 await yandexApi.UploadFile(data);
			}

			return true;
		}
    }


}

