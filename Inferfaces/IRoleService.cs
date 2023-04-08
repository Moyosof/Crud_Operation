namespace CRUD_Operation.Inferfaces
{
    public interface IRoleService
    {
        Task<string> CreateRole(string roleName);

        Task<string> AddUserToRole(string user,string roleName);
    }
}
