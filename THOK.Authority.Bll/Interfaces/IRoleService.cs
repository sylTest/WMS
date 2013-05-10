﻿using THOK.Authority.DbModel;

namespace THOK.Authority.Bll.Interfaces
{
    public interface IRoleService : IService<AUTH_ROLE>
    {
        object GetDetails(int page, int rows, string roleName, string description, string status);

        bool Add(string roleName, string description, bool status);        

        bool Delete(string roleID);

        bool Save(string roleID, string roleName, string description, bool status);

        string FindRolesForFunction(string strFunctionID);

        object GetRoleUser(string roleID);

        object GetUserInfo(string roleID);

        bool DeleteRoleUser(string roleUserIdStr);

        bool AddRoleUser(string roleID, string userIDStr);
    }
}
