using Volo.Abp.Modularity;

namespace EtdCrm;

[DependsOn(
    typeof(EtdCrmApplicationModule),
    typeof(EtdCrmDomainTestModule)
    )]
public class EtdCrmApplicationTestModule : AbpModule
{

}
