using EtdCrm.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace EtdCrm.Permissions;

public class EtdCrmPermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var myGroup = context.AddGroup(EtdCrmPermissions.GroupName);

        #region Treatment
        var treatmentPermission = myGroup.AddPermission(EtdCrmPermissions.Treatment, L("Treatment"));
        treatmentPermission.AddChild(EtdCrmPermissions.TreatmentCreate, L("Create"));
        treatmentPermission.AddChild(EtdCrmPermissions.TreatmentUpdate, L("Update"));
        treatmentPermission.AddChild(EtdCrmPermissions.TreatmentDelete, L("Delete"));
        treatmentPermission.AddChild(EtdCrmPermissions.TreatmentGet, L("Get"));
        treatmentPermission.AddChild(EtdCrmPermissions.TreatmentList, L("List"));
        #endregion Treatment

    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<EtdCrmResource>(name);
    }
}
