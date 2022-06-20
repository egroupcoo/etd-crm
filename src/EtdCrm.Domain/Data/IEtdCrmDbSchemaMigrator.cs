using System.Threading.Tasks;

namespace EtdCrm.Data;

public interface IEtdCrmDbSchemaMigrator
{
    Task MigrateAsync();
}
