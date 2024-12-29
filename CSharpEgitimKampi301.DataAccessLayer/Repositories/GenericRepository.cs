using CSharpEgitimKampi301.DataAccessLayer.Abstract;
using CSharpEgitimKampi301.DataAccessLayer.Context;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpEgitimKampi301.DataAccessLayer.Repositories
{
    public class GenericRepository<T> : IGenericDal<T> where T : class
    {
        KampContext context = new KampContext();
        private readonly DbSet<T> _object ;
        // private bir değer ve sadece okunur hale getirdik.

        // ctor yazarak aşağıdaki ifadeyi oluşturuyoruz.
        public GenericRepository()
        {
            _object = context.Set<T>();
            // _object değerine context.Set<T>() değerini atadık.
        }
        public void Delete( T entity)
        {
            var deletedEntity = context.Entry(entity);
            deletedEntity.State = EntityState.Deleted;
            // EntityState : ekleme silme güncelleme vb. işlemlere izin veren kod bloğu.
            context.SaveChanges();
            // değişiklikleri kaydettik.
        }

        public List<T> GetAll()
        {
            return _object.ToList();
            // burada EntityState üzerinde işlem yapmıyoruz.
            // Listeleme işlemi yapacağamız için kullanmaya gerek yok.
            // ToList() ile verileri listeliyoruz.
        }

        public T GetById(int id)
        {
            return _object.Find(id);
            // burada ise id'ye göre veriyi bulup getiriyoruz.
        }

        public void Insert(T entity)
        {
            var addedEntity = context.Entry(entity);
            // eklenecek olan entity'i context'e ekliyoruz.
            addedEntity.State = EntityState.Added; // EntityState.Added ile ekleme işlemi yapıyoruz.
            context.SaveChanges(); // değişiklikleri kaydediyoruz.
        }

        public void Update(T entity)
        {
            var updatedEntity = context.Entry(entity);
            updatedEntity.State = EntityState.Modified;
            // EntityState.Modified ile güncelleme işlemi yapıyoruz.
            context.SaveChanges();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
