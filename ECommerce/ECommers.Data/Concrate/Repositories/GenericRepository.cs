using ECommers.Data.Abstrack;
using ECommers.Data.Concrate.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ECommers.Data.Concrate.Repositories
{

    public class GenericRepository<T> : IGenericRepository<T> where T : class // TÜM ORTAK HEDEFLER BURADA YAZILIR CRAT İŞLEMLERİ GİBİ. T : SADECE CLASS OLMASINI İSTEDİGİNİZİ BELİRTTİK. ENTİTYLERİMİN KARŞILIĞI YANİ.
    {
        private readonly ECommerceDbContext _context;
        private readonly DbSet<T> _dbSet;

        public GenericRepository(ECommerceDbContext context)
        {
            _context = context;   
            _dbSet = context.Set<T>();  // Contextim içindeki DbSetlerim.
        }

        public async Task<T> AddAsync(T entity)
        {
            //  _context.Set<T>().Add(entity);  // t'ye hangi categoryim(product ....) gelirse 
            await _dbSet.AddAsync(entity); // dbcontexime gir hangi context lazımsa gidip onu al  DbSet<Basket> gibi.
            return entity; // ef core takip edicek
        }
        
        public async Task<int> CountAsync()
        {
            return await _dbSet.CountAsync();
        }


        //x=>x.CategoryId==1
        //x=>x.Price>=100 && x.Price<=200
        public async Task<int> CountAsync(Expression<Func<T, bool>> pridacate) // x=>x.Price>100  x.price<=200 (pridacate) sorgu,koşul,where'e karşılık gelen
        {
            return await _dbSet.CountAsync(pridacate);
            //return await _dbSet.Where(pridacate).CountAsync();

        }

        public void Delete(T entity)
        {
            _dbSet.Remove(entity);
            //_dbSet.Entry(entity).State = EntityState.Deleted;
        }

        public async Task<bool> ExistsAsync(Expression<Func<T, bool>> pridacate) // verdiğin şarta göre kayıt bool döner.
        {
            return await _dbSet.AnyAsync(pridacate);
        }


        //x=>x.Price==56 && x.IsActive==true && x.CreatedDate==DateTime.Now
        //findascyn= sadece ıd' ile firtlemek . firstordefault ise ise herşeyi arayabilirsin.(name,phone)
        public async Task<T> FindAsync(Expression<Func<T, bool>> pridacate) // arama yapmak istenilen metod
        {
            return await _dbSet.FirstOrDefaultAsync(pridacate); // null döndürme ihtimali varise firstordefault kullanılır default değeri neyse onu döndürür.
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        //_context.Products.where(x=>x.ıd==1) = pradicate,
        //_context.Products.where(x=>x.ıd==1).ınculud(x=>x.Category).OrderBy(x=>x.price)
        //IEnumerable= Listin atası
        public async Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>>? pradicate = null, Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null, params Expression<Func<T, object>>[] includes)
        {
            IQueryable<T> query = _dbSet; // context.products
            if (pradicate != null) // boş değilse pradicate girer
            {
                query = query.Where(pradicate); // _context.product.where(x=>x.category.ıd==1)
            }
            if (includes != null) //incl boş değilse ,incl dizi oldugu için foreach
            {
                foreach (var include in includes) // incl. birden fazla olma ihtimali oldugu için.
                {
                    query = query.Include(include); //_context.product.where(x=>x.category.ıd==1).include(x=>x.category.ınclude(x=>x.supplier)
                }
            }
            if (orderBy != null) // boş değilse
            {
                query = orderBy(query); // _context.product.where(x=>x.category.ıd==1).include(x=>x.category.ınclude(x=>x.supplier).OrderBy(x=>x.Price)
            }

            return await query.ToListAsync();// IEnumerable oldu bundan önce IQuerabledı.(ex olmadan öneceki hali IQuerable.)
        }

        public async Task<T> GetAsync(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includes)
        {
            IQueryable<T> query = _dbSet;
            if (predicate!=null)
            {
                query = query.Where(predicate);
            }
            if(includes != null)
            {
                foreach (var inculude in includes)
                {
                    query = query.Include(inculude);
                }
            }
            return query.FirstOrDefault(); // tek kayıt.
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _dbSet.FindAsync(id);   // return await _dbset.where(x=>x.ıd==id).firstordefault();
                                                //return await _dbset.firstordefault(x=>x.ıd==id);. seçenekler
        }

        public void Update(T entity)
        {
            _dbSet.Update(entity);
            // _dbset.entry(entity).state = entitystate.modifed;
        }
    }
}
