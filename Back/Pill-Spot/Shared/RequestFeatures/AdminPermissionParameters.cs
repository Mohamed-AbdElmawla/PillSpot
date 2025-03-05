namespace Shared.RequestFeatures
{
    public class AdminPermissionParameters : RequestParameters
    {
        public AdminPermissionParameters() => OrderBy = "Permission.Name";
    }
}