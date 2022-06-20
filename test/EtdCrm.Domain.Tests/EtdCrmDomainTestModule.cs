using EtdCrm.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace EtdCrm;

[DependsOn(
    typeof(EtdCrmEntityFrameworkCoreTestModule)
    )]
public class EtdCrmDomainTestModule : AbpModule
{

}
