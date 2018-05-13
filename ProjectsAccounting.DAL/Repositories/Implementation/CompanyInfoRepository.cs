using ProjectsAccounting.Common.Models;
using ProjectsAccounting.DAL.DB;
using ProjectsAccounting.DAL.Mappers;
using System.Linq;

namespace ProjectsAccounting.DAL.Repositories
{
    public class CompanyInfoRepository : RepositoryBase<ProjectsAccountingEntities>, ICompanyInfoRepository
    {
        public CompanyInfoModel GetCompanyInfo()
        {
            return this.Context.CompanyInfo.ToList()
                .Select(i => CompanyInfoMapper.ToCompanyInfoModel(i)).FirstOrDefault();
        }
    }
}
