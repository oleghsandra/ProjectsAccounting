using ProjectsAccounting.Common.Models;
using ProjectsAccounting.DAL.DB;

namespace ProjectsAccounting.DAL.Mappers
{
    class CompanyInfoMapper
    {
        public static CompanyInfoModel ToCompanyInfoModel(CompanyInfo dbModel)
        {
            return new CompanyInfoModel()
            {
                CompanyId = dbModel.CompanyId,
                CompanyName = dbModel.CompanyName,
                MainAccpuntantName = dbModel.MainAccpuntantName,
                OwnerName = dbModel.OwnerName,
                LocationAddress = dbModel.LocationAddress,
                Fax = dbModel.Fax,
                Phone = dbModel.Phone,
                OfficeRate = dbModel.OfficeRate ?? 0,
                TaxRate = dbModel.TaxRate ?? 0
            };
        }

        public static CompanyInfo ToDBCompanyInfo(CompanyInfoModel model)
        {
            return new CompanyInfo()
            {
                CompanyId = model.CompanyId,
                CompanyName = model.CompanyName,
                MainAccpuntantName = model.MainAccpuntantName,
                OwnerName = model.OwnerName,
                LocationAddress = model.LocationAddress,
                Fax = model.Fax,
                Phone = model.Phone,
                OfficeRate = model.OfficeRate,
                TaxRate = model.TaxRate
            };
        }
    }
}
