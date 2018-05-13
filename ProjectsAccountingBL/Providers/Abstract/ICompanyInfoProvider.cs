using ProjectsAccounting.Common.Models;

namespace ProjectsAccountingBL.Providers.Abstract
{
    public interface ICompanyInfoProvider
    {
        CompanyInfoModel GetCompanyInfo();
    }
}
