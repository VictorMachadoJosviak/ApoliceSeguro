﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apolice.Infra.Transactions
{
    public interface IUnitOfWork
    {
        void Commit();
    }
}