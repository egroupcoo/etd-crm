using EtdCrm.Etd.Enum;
using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace EtdCrm.Etd.Dto.DocumentFile.Crud
{
    public class DocumentFileDto : EntityDto<long>
    {
        public long DocumentId { get; set; }

        public string UrlPath { get; set; }

        public int OrderId { get; set; }

        public EnmFileExtension FileExtension { get; set; }

        public DocumentFileDto(long documentId, string urlPath, int orderId, EnmFileExtension enmFileExtension)
        {

            DocumentId = documentId;
            UrlPath = urlPath;
            OrderId = orderId;
            FileExtension = enmFileExtension;
        }

    }
}
