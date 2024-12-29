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
    public class ProductManager : IProductService
    {
        private readonly IProductDal _productdal;
        public ProductManager(IProductDal productdal)
        {
            _productdal = productdal;
        }

        public void TDelete(Product entity)
        {
            _productdal.Delete(entity);
        }

        public List<Product> TGetAll()
        {
            return _productdal.GetAll();
        }

        public Product TGetById(int id)
        {
            return _productdal.GetById(id);
        }

        public void TInsert(Product entity)
        {
            _productdal.Insert(entity);
        }

        public void TUpdate(Product entity)
        {
            _productdal.Update(entity);
        }
    }
}
