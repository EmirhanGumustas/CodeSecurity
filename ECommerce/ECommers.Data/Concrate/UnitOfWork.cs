using ECommers.Data.Abstrack;
using ECommers.Data.Concrate.Contexts;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommers.Data.Concrate
{
    public class UnitOfWork : IUnitOfWork // istedigim zaman savechange yapabilecek // repositlerimi merkezi yerden almama yarayacak.
    {
        private readonly ECommerceDbContext _context;
        private readonly IServiceProvider _serviceProvider; //programcste yazdıgımızı çekebilnemiz için 
                                                            // IServiceProvider = programcs'teki service.builder ile yazıdıgmız elamanarı getirmek için kullanıyoruz

        public UnitOfWork(IServiceProvider serviceProvider,ECommerceDbContext eCommerceDbContext)
        {
            _serviceProvider = serviceProvider;
            _context = eCommerceDbContext;
        }

        public void Dispose() // her iş bittiginde dispose edicek öldürme işlemi yapmaktadır.
        {
           _context.Dispose();
        }

        public IGenericRepository<T> GetRepository<T>() where T : class // merkezi dediğimiz yer.
        {
            //_serviceProvider. == programcs'teki servislerimi çağirirken nokta yazdıgımızda hangisini çağirmak istersek onu kullanacagımız metod.
            return _serviceProvider.GetRequiredService<IGenericRepository<T>>();
        }

        public async Task<int> SaveChangeAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
