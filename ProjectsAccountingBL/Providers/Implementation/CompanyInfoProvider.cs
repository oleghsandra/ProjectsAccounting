using System.Collections.Generic;
using System.Linq;
using ProjectsAccounting.DAL.Repositories;
using ProjectsAccounting.TFS.Repositories;
using ProjectsAccounting.Common.Models;
using ProjectsAccountingBL.Providers.Abstract;

namespace ProjectAccountingBL.Providers.Implementation
{
    public class CompanyInfoProvider : ICompanyInfoProvider
    {
        public CompanyInfoProvider(ICompanyInfoRepository companyInfoRepository)
        {
            this._companyInfoRepository = companyInfoRepository;
        }

        private ICompanyInfoRepository _companyInfoRepository { get; set; }

        public CompanyInfoModel GetCompanyInfo()
        {
            return this._companyInfoRepository.GetCompanyInfo();
        }
    }
}