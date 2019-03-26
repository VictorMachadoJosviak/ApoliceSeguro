using Apolice.Domain.Interfaces.Repositories;
using Apolice.Domain.Interfaces.Services;
using Apolice.Domain.Services;
using Apolice.Infra.Persistence;
using Apolice.Infra.Repositories;
using Apolice.Infra.Repositories.Base;
using Apolice.Infra.Transactions;
using Microsoft.Practices.Unity;
using prmToolkit.NotificationPattern;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apolice.IoC.Unity
{
    public static class DependencyResolver
    {
        public static void Resolve(UnityContainer container)
        {
            container.RegisterType<DbContext, DataContext>(new HierarchicalLifetimeManager());

            container.RegisterType<IUnitOfWork, UnitOfWork>(new HierarchicalLifetimeManager());
            container.RegisterType<INotifiable, Notifiable>(new HierarchicalLifetimeManager());

            container.RegisterType<ISeguroService, SeguroService>(new HierarchicalLifetimeManager());

            container.RegisterType(typeof(IRepositoryBase<,>), typeof(RepositoryBase<,>));

            container.RegisterType<ISeguroRepository, SeguroRepository>(new HierarchicalLifetimeManager());
        }
    }
}