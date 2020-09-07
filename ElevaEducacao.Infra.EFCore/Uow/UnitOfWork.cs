using ElevaEducacao.Domain.Core.Interfaces;
using ElevaEducacao.Infra.EFCore.Context;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ElevaEducacao.Infra.EFCore.Uow
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> CommitAsync()
        {
            var changes = await _context.SaveChangesAsync();
            return changes > 0;
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
