using System;
using System.Threading.Tasks;
using EtdCrm.Etd.Dto.ExtendProfile;
using Volo.Abp.Account;

namespace EtdCrm.ExtendProfile
{
    public interface IExtendProfileAppService : IProfileAppService
    {
        Task<ExtendProfileDto> GetProfile();
    }
}

