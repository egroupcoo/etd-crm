using System.Threading.Tasks;
using EtdCrm.Localization;
using Volo.Abp.Account;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.DependencyInjection;

namespace EtdCrm.Controllers;

/* Inherit your controllers from this class.
 */
public abstract class EtdCrmController : AbpControllerBase
{
    protected EtdCrmController()
    {
        LocalizationResource = typeof(EtdCrmResource);
    }

    [Dependency(ReplaceServices = true)]
    [ExposeServices(typeof(AccountController))]
    public class MyAccountController : AccountController
    {
        public MyAccountController(IAccountAppService accountAppService)
            : base(accountAppService)
        {

        }
    }
}
