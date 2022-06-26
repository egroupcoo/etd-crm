namespace EtdCrm.Permissions;

public static class EtdCrmPermissions
{
    public const string GroupName = "EtdCrm";

    //Add your own permission names. Example:
    public const string Treatment = GroupName + ".Treatment_Management";
    public const string TreatmentCreate = GroupName + ".Treatment_Management.TreatmentCreate_Management";
    public const string TreatmentUpdate = GroupName + ".Treatment_Management.TreatmentUpdate_Management";
    public const string TreatmentDelete = GroupName + ".Treatment_Management.TreatmentDelete_Management";
    public const string TreatmentList = GroupName + ".Treatment_Management.TreatmentList_Management";
    public const string TreatmentGet = GroupName + ".Treatment_Management.TreatmentGet_Management";



    public const string Doctor = GroupName + ".Doctor_Management";
    public const string DoctorCreate = GroupName + ".Doctor_Management.DoctorCreate_Management";
    public const string DoctorUpdate = GroupName + ".Doctor_Management.DoctorUpdate_Management";
    public const string DoctorDelete = GroupName + ".Doctor_Management.DoctorDelete_Management";
    public const string DoctorList = GroupName + ".Doctor_Management.DoctorList_Management";
    public const string DoctorGet = GroupName + ".Doctor_Management.DoctorGet_Management";
}
