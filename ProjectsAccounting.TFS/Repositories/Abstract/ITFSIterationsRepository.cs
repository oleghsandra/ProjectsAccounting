using System.Collections.Generic;
using ProjectsAccounting.Common.Models;

namespace ProjectsAccounting.TFS.Repositories
{
    public interface ITFSIterationsRepository
    {
        List<IterationModel> GetAll(string projectTFCid);
    }
}

