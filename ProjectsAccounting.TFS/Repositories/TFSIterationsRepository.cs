using ProjectsAccounting.TFS.TFSDB;
using System.Collections.Generic;
using System.Linq;
using ProjectsAccounting.Common;
using ProjectsAccounting.Common.Models;
using System;

namespace ProjectsAccounting.TFS.Repositories
{
    public class TFSIterationsRepository : RepositoryBase<Tfs_DefaultCollectionEntities>
    {
        public List<IterationModel> GetAll(string projectTFCid)
        {
            var projectId = Int32.Parse(projectTFCid.Trim());

            var result = from i in this.Context.tbl_Iteration
                         join p in this.Context.tbl_Project on i.ProjectUri equals p.ProjectUri
                         where projectId == p.ProjectId && i.Iteration.Contains("\\")
                         select new { i };

            return result.ToList().Select(i => new IterationModel()
            {
                PMCID = i.i.IterationId.ToString(),
                Name =  i.i.Iteration.Split('\\')[1]
            }).ToList();
        }
    }
}

