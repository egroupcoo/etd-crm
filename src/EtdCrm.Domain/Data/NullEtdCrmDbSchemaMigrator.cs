using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace EtdCrm.Data;

/* This is used if database provider does't define
 * IEtdCrmDbSchemaMigrator implementation.
 */
public class NullEtdCrmDbSchemaMigrator : IEtdCrmDbSchemaMigrator, ITransientDependency
{
    public Task MigrateAsync()
    {
        return Task.CompletedTask;
    }
}
