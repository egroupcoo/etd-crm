using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EtdCrm.Etd.Dto.ExtendProfile;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Volo.Abp.Account;
using Volo.Abp.Application.Services;
using Volo.Abp.Identity;
using Volo.Abp.PermissionManagement;
using Volo.Abp.Users;

namespace EtdCrm.ExtendProfile
{
    public class ExtendProfileAppService : ProfileAppService, IExtendProfileAppService
    {
        private readonly ICurrentUser _currentUser;
        private readonly IdentityUserManager _userManager;
        private readonly IPermissionManager _permissionManager;

        public ExtendProfileAppService(ICurrentUser currentUser, IPermissionManager permissionManager, IdentityUserManager userManager, IOptions<IdentityOptions> identityOptions) : base(userManager, identityOptions)
        {
            _currentUser = currentUser;
            _userManager = userManager;
            _permissionManager = permissionManager;
        }


        public async Task<ExtendProfileDto> GetProfile()
        {
            var user = await _userManager.GetByIdAsync(_currentUser.Id.Value);

            var userDto = ObjectMapper.Map<Volo.Abp.Identity.IdentityUser, ExtendProfileDto>(user);
            userDto.Roles = _currentUser.Roles;

            var permissions = await _permissionManager.GetAllForUserAsync(_currentUser.Id.Value);

            foreach (var permission in permissions)
            {
                userDto.Permissions.Add(permission.Name, permission.IsGranted);
            }


            return userDto;
        }
    }
}



