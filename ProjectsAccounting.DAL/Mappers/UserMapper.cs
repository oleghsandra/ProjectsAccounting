using ProjectsAccounting.Common.Models;
using ProjectsAccounting.DAL.DB;

namespace ProjectsAccounting.DAL.Mappers
{
    class UserMapper
    {
        public static UserModel ToUserModel(Users dbModel)
        {
            return new UserModel()
            {
                UserId = dbModel.UserId,
                UserName = dbModel.UserName,
                FullName = dbModel.FullName,
                PMCID = dbModel.PMCID,
                InternalRate = dbModel.InternalRate ?? 0,
            };
        }

        public static Users ToDBUser(UserModel model)
        {
            return new Users()
            {
                UserId = model.UserId,
                UserName = model.UserName,
                FullName = model.FullName,
                PMCID = model.PMCID,
                InternalRate = model.InternalRate
            };
        }
    }
}