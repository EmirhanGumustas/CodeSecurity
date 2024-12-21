using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ECommers.Data.Abstrack
{
    // metod imzalarını düzgünce görebilmek içib hazırladık.
    public interface IGenericRepository<T> where T : class      //generic yani heryerde kullanacagımız için <T> yazdık                                   // ortak olan data işlemlerimizi burada yaparız.
    {                                                       // T'LERİN CLASS OLMASINI İSTEDİK List<Product>. product entitylerimin classı
        Task<T> GetByIdAsync(int id); //T : yerine product,user . çünkü generic bir yapı yaptık t yerine ne yazılacaksa onun id ile ne istediysek onu geri döndürmek isteriz.
        Task<T> GetAsync(Expression<Func<T,bool>> predicated,params Expression<Func<T,object>>[] includes);  // categories.where(x=>x.ıd==4) /x=>x.ıd= predicated= koşul //x.=>x.4= bool. 
                                                                                                             //ikinci parametre olarak inculudlarımı yazabilirim. GETASYNC(X=>X.ID==İD,SOURCE=>SOURCE.INCULUDE(X=>X.CATEGORY)) // VİRDÜLDEN SONRAKİ YAZDIGIMIZ METODUN İNC. TARAFINA DENK GELİR.
/* Expression<Func<T, bool>> predicate: categories.where(x=>x.ıd==4), params Expression<Func<T,object>>[] includes : İnclude yaptıgımız yer */
/*Categories.Where(x=>x.ıd==4).ınclude(x=>x.Produuct)*/

        Task<IEnumerable<T>> GetAllAsync(); // sadece index alamayız 0. idexi getir gibi. ICollection entitylerin içinde yazılır.

        /* tüm verileri getirir. [Context.Categories.tolist()] */

        Task<IEnumerable<T>> GetAllAsync(Expression<Func<T,bool>>? pradicate = null, // categories.where(x=>x.ısactive)
                                                                Func<IQueryable<T>,IOrderedQueryable<T>>? orderBy=null, // SIRALAMAK İÇİN KULLANULIR . product.OrderBy(x=x.Name)
                                                                params Expression<Func<T, object>>[] includes           // .inculude(x=>x.Product) içindeki ilişkiyi getir.
                                                                ); //QUERTABLE ex etmeden önceki hali

        Task<T> FindAsync(Expression<Func<T,bool>> pridacate);//category.where(x=>x.Name=="Emirhan")
        // 

        Task<bool> ExistsAsync(Expression<Func<T, bool>> pridacate);// varlığını kontrol ediyorum geriye bool dönüyor.

        Task<T> AddAsync(T entity); // T: CATEGORy.... gibi
        void Update(T entity); // asc olması gerektirmez.
        void Delete(T entity);
        Task<int> CountAsync();

        Task<int> CountAsync(Expression<Func<T, bool>> pridacate); // count sayısını kontrol ediyorum geriye int olarak değer dönuyor.


    }   
}
