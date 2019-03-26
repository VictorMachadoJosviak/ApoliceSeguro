using Apolice.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apolice.Domain.Interfaces.Repositories
{
    public interface ISeguroRepository : IRepositoryBase<Seguro, Guid>
    {
    }
}