using System;
using System.Collections.Generic;
using System.Text;
using EtdCrm.Localization;
using Volo.Abp.Application.Services;

namespace EtdCrm;

/* Inherit your application services from this class.
 */
public abstract class EtdCrmAppService : ApplicationService
{
    protected EtdCrmAppService()
    {
        LocalizationResource = typeof(EtdCrmResource);
    }
}
