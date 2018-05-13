using System.Collections.Generic;
using ProjectsAccounting.Common.Models;

namespace ProjectsAccounting.TFS.Repositories
{
    public interface ITFSUsersRepository
    {
        List<UserModel> GetAll();
    }
}

