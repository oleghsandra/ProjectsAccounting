using System.Collections.Generic;
using ProjectsAccounting.TFS.Repositories;
using ProjectsAccounting.Common.Models;
using ProjectsAccountingBL.Providers.Abstract;

namespace ProjectAccountingBL.Providers.Implementation
{
    public class IterationsProvider : IIterationsProvider
    {
        public IterationsProvider(ITFSIterationsRepository tfsIterationsRepository)
        {
            this._tfsIterationsRepository = tfsIterationsRepository;
        }

        private ITFSIterationsRepository _tfsIterationsRepository { get; set; }

        public List<IterationModel> GetAll(string projectTFCid)
        {
            return this._tfsIterationsRepository.GetAll(projectTFCid);
        }
    }
}