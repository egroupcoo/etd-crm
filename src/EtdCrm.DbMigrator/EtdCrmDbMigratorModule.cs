using EtdCrm.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.BackgroundJobs;
using Volo.Abp.Modularity;

namespace EtdCrm.DbMigrator;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(EtdCrmEntityFrameworkCoreModule),
    typeof(EtdCrmApplicationContractsModule)
    )]
public class EtdCrmDbMigratorModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpBackgroundJobOptions>(options => options.IsJobExecutionEnabled = false);
    }
}
