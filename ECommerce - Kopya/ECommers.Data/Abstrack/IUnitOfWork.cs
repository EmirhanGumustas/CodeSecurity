using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommers.Data.Abstrack
{
    public interface IUnitOfWork : IDisposable // bellekten yoketme diposable . IDisposable kendimiz yok etme
    {
        IGenericRepository<T> GetRepository<T>() where T : class;
        Task<int> SaveChangeAsync(); // kayıt ekleme int sebebide 1 kayıt tamamlandı gibi.
    }
}
