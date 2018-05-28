using System;
using System.Threading.Tasks;
using TechAche.Persistance;

namespace TechAche.Persistance
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly TechAcheDbContext context;
        public UnitOfWork(TechAcheDbContext context)
        {
            this.context = context;

        }
        public async Task CompleteAsync()
        {
            await context.SaveChangesAsync();
        }
    }
}