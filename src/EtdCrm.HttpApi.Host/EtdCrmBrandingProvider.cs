using Volo.Abp.DependencyInjection;
using Volo.Abp.Ui.Branding;

namespace EtdCrm;

[Dependency(ReplaceServices = true)]
public class EtdCrmBrandingProvider : DefaultBrandingProvider
{
    public override string AppName => "EtdCrm";
}
