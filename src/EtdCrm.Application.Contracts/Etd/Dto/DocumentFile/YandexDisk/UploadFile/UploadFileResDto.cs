using System;
using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace EtdCrm.Etd.Dto.DocumentFile.YandexDisk.UploadFile
{
	public class UploadFileResDto
	{
        [JsonPropertyName("href")]
        public string Url { get; set; }
    }
}

