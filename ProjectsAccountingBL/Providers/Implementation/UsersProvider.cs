using System.Collections.Generic;
using System.Linq;
using ProjectsAccounting.DAL.Repositories;
using ProjectsAccounting.TFS.Repositories;
using ProjectsAccounting.Common.Models;
using ProjectsAccountingBL.Providers.Abstract;

namespace ProjectAccountingBL.Providers.Implementation
{
    public class UsersProvider : IUsersProvider
    {
        public UsersProvider(IUsersRepository userRepository, ITFSUsersRepository tfsUsersRepository)
        {
            this._userRepository = userRepository;
            this._tfsUsersRepository = tfsUsersRepository;
        }

        private IUsersRepository _userRepository { get; set; }

        private ITFSUsersRepository _tfsUsersRepository { get; set; }

        public List<UserModel> GetAll()
        {
            return this._userRepository.GetAll();
        }

        public void ChangeInternalRate(int userId, double internalRate)
        {
            this._userRepository.ChangeInternalRate(userId, internalRate);
        }

        /// <summary>
        /// Synhronize users from DB wit tfs users
        /// </summary>
        public void Synhronize()
        {
            var ownUsers = this._userRepository.GetAll();
            var tfsUsers = this._tfsUsersRepository.GetAll();

            foreach (var tfsUser in tfsUsers)
            {
                if (!ownUsers.Any(p => p.PMCID == tfsUser.PMCID))
                {
                    this._userRepository.Insert(tfsUser);
                }
            }
        }
    }
}