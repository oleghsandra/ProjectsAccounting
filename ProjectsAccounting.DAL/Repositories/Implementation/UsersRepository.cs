using ProjectsAccounting.Common.Models;
using ProjectsAccounting.DAL.DB;
using ProjectsAccounting.DAL.Mappers;
using System.Collections.Generic;
using System.Linq;

namespace ProjectsAccounting.DAL.Repositories
{
    public class UsersRepository : RepositoryBase<ProjectsAccountingEntities>, IUsersRepository
    {
        public List<UserModel> GetAll()
        {
            return this.Context.Users.ToList()
                .Select(p => UserMapper.ToUserModel(p)).ToList();
        }

        public void Insert(UserModel model)
        {
            var rate = UserMapper.ToDBUser(model);
            this.Context.Users.Add(rate);
            this.Save();
        }

        public void ChangeInternalRate(int userId, double internalRate)
        {
            var user = this.Context.Users.FirstOrDefault(u => u.UserId == userId);
            user.InternalRate = internalRate;
            this.Save();
        }
    }
}
