using CSharpEgitimKampi301.BusinessLayer.Abstract;
using CSharpEgitimKampi301.DataAccessLayer.Abstract;
using CSharpEgitimKampi301.EntitiyLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpEgitimKampi301.BusinessLayer.Concrete
{
    public class CategoryManager : ICategoryService
    {
        private readonly ICategoryDal _categoryDal; // readonly sadece constructor içinde set edilebilir.

        public CategoryManager(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
            // yapıcı metodu oluşturduk. Bu sayede CategoryManager sınıfı oluşturulduğunda ICategoryDal türünden bir nesne almak zorunda.
        }

        public void TDelete(Category entity)
        {
            _categoryDal.Delete(entity);
        }

        public List<Category> TGetAll()
        {
            return _categoryDal.GetAll();
            // _categoryDal nesnesi üzerinden GetAll metodunu çağırıp geriye döndürdük.
        }

        public Category TGetById(int id)
        {
            return _categoryDal.GetById(id);   
        }

        public void TInsert(Category entity)
        {
            _categoryDal.Insert(entity);
        }

        public void TUpdate(Category entity)
        {
            _categoryDal.Update(entity);
        }
    }
}
// dataaccesslayer ve businesslayer arasında bir bağlantı kurduk.
// dataaccesslayer'da tanımladığımız metotları burada kullanıyoruz.
// bu sayede dataaccesslayer'da tanımladığımız metotları burada kullanarak işlemlerimizi gerçekleştirebiliyoruz.