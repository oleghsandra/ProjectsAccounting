using ProjectsAccounting.Common.Models;
using System.Collections.Generic;

namespace ProjectsAccountingBL.Providers.Abstract
{
    public interface IIterationsProvider
    {
        List<IterationModel> GetAll(string projectTFCid);
    }
}
