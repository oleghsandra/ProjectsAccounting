using ProjectsAccounting.TFS.TFSDB;
using System;
using System.Collections.Generic;
using System.Linq;
using ProjectsAccounting.Common;
using ProjectsAccounting.Common.Models;
using ProjectsAccounting.DAL.Mappers;

namespace ProjectsAccounting.TFS.Repositories
{
    public class TFSProjectsRepository : RepositoryBase<Tfs_DefaultCollectionEntities>
    {
        public List<ProjectModel> GetAll()
        {
            return Context.tbl_Project.ToList().Select(p => ProjectMapper.ToProjectModel(p)).ToList();
        }
    }
}
