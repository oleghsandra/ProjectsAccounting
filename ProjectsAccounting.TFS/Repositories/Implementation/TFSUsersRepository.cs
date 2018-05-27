using ProjectsAccounting.TFS.TFSDB;
using System.Collections.Generic;
using System.Linq;
using ProjectsAccounting.Common.Models;

namespace ProjectsAccounting.TFS.Repositories
{
    public class TFSUsersRepository : RepositoryBase<Tfs_DefaultCollectionEntities>, ITFSUsersRepository
    {
        /// <summary>
        /// Get all users
        /// </summary>
        public List<UserModel> GetAll()
        {
            var result = from grp in this.Context.ADObjects
                         join om in this.Context.ADObjectMemberships on grp.ObjectSID equals om.ObjectSID
                         join member in this.Context.ADObjects on om.MemberObjectSID equals member.ObjectSID
                         where (grp.SamAccountName == "Team Foundation Administrators" && member.ObjectCategory == (byte)2)
                         select new { member };

            return result.ToList().Select(u => new UserModel()
            {
                PMCID = u.member.TeamFoundationId.ToString(),
                FullName = u.member.DisplayName,
                UserName = u.member.SamAccountName
            }).ToList();
        }
    }
}