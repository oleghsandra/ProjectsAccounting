using ProjectsAccounting.Common.Models;
using System.Collections.Generic;

namespace ProjectsAccountingBL.Providers.Abstract
{
    public interface IUsersProvider
    {
        List<UserModel> GetAll();

        void Synhronize();

        void ChangeInternalRate(int userId, double internalRate);
    }
}
