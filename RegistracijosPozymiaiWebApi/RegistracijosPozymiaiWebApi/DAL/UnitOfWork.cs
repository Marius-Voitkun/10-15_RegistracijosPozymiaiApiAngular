using RegistracijosPozymiaiWebApi.DAL.IRepositories;
using RegistracijosPozymiaiWebApi.DAL.Repositories;
using RegistracijosPozymiaiWebApi.Models;
using System.Threading.Tasks;

namespace RegistracijosPozymiaiWebApi.DAL
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DataContext _context;

        public IRepository<Feature> Features { get; }
        public IRepository<DropDownOption> DropDownOptions { get; }
        public IRepository<SelectedValue> SelectedValues { get; }

        public UnitOfWork(DataContext context)
        {
            _context = context;
            Features = new Repository<Feature>(_context);
            DropDownOptions = new Repository<DropDownOption>(_context);
            SelectedValues = new Repository<SelectedValue>(_context);
        }

        public async Task<int> SaveAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public async ValueTask DisposeAsync()
        {
            await _context.DisposeAsync();      // is this correct?
        }
    }
}
