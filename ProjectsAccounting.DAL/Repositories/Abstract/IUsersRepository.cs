using ProjectsAccounting.Common.Models;
using System.Collections.Generic;

namespace ProjectsAccounting.DAL.Repositories
{
    public interface IUsersRepository
    {
        List<UserModel> GetAll();

        void Insert(UserModel model);

        void ChangeInternalRate(int userId, double internalRate);
    }
}
