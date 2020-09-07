using ElevaEducacao.Domain;
using ElevaEducacao.Domain.Interfaces.Repository;
using ElevaEducacao.Infra.EFCore.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace ElevaEducacao.Infra.EFCore.Repositories
{
    public class UFRepository : RepositoryBase<UF>, IUFRepository
    {
        public UFRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
