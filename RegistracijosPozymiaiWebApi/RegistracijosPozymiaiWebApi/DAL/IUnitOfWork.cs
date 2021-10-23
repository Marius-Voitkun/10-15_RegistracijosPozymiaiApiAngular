using RegistracijosPozymiaiWebApi.DAL.IRepositories;
using RegistracijosPozymiaiWebApi.Models;
using System;
using System.Threading.Tasks;

namespace RegistracijosPozymiaiWebApi.DAL
{
    public interface IUnitOfWork : IAsyncDisposable
    {
        IRepository<Feature> Features { get; }
        IRepository<DropDownOption> DropDownOptions { get; }
        IRepository<SelectedValue> SelectedValues { get; }

        Task<int> SaveAsync();
    }
}
