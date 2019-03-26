using Apolice.Domain.Entity;
using Apolice.Domain.Interfaces.Repositories;
using Apolice.Infra.Persistence;
using Apolice.Infra.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apolice.Infra.Repositories
{
    public class SeguroRepository : RepositoryBase<Seguro, Guid>, ISeguroRepository
    {
        protected readonly DataContext _context;

        public SeguroRepository(DataContext context) : base(context)
        {
            _context = context;
        }
    }
}