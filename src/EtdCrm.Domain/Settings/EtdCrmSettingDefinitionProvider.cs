using Volo.Abp.Settings;

namespace EtdCrm.Settings;

public class EtdCrmSettingDefinitionProvider : SettingDefinitionProvider
{
    public override void Define(ISettingDefinitionContext context)
    {
        //Define your own settings here. Example:
        //context.Add(new SettingDefinition(EtdCrmSettings.MySetting1));
    }
}
