using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Volo.Abp.Application.Dtos;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Guids;
using Volo.Abp.Identity;
using Volo.Abp.Settings;
using Volo.Abp.Threading;

namespace EtdCrm.Admin
{

    [Dependency(ReplaceServices = true)]
    [ExposeServices(typeof(IIdentityUserAppService), typeof(IdentityUserAppService), typeof(MyIdentityUserAppService))]
    public class MyIdentityUserAppService : IdentityUserAppService
    {
        //...
        public MyIdentityUserAppService(
            IdentityUserManager userManager,
            IIdentityUserRepository userRepository,
            IIdentityRoleRepository roleRepository, IOptions<Microsoft.AspNetCore.Identity.IdentityOptions> identityOptions
        ) : base(
            userManager,
            userRepository,
            roleRepository,
            identityOptions)
        {
        }


        public override Task<PagedResultDto<IdentityUserDto>> GetListAsync(GetIdentityUsersInput input)
        {
            //Super Authorize daki sorun için yapıldı eğer connect doğru şekilde yapılırsa yapılmayacak
            //using (CurrentTenant.Change(null))
            //{
                return base.GetListAsync(input);
            //}
      
        }

        public async override Task<IdentityUserDto> CreateAsync(IdentityUserCreateDto input)
        {

            return await base.CreateAsync(input);
        }
    }

}




//return base.GetListAsync(input);