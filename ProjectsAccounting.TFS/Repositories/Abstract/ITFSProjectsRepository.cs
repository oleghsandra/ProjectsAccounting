using System.Collections.Generic;
using ProjectsAccounting.Common.Models;

namespace ProjectsAccounting.TFS.Repositories
{
    public interface ITFSProjectsRepository
    {
        List<ProjectModel> GetAll();
    }
}

