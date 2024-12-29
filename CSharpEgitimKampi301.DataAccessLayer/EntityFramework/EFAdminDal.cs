using CSharpEgitimKampi301.DataAccessLayer.Abstract;
using CSharpEgitimKampi301.DataAccessLayer.Repositories;
using CSharpEgitimKampi301.EntitiyLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpEgitimKampi301.DataAccessLayer.EntityFramework
{
    public class EFAdminDal : GenericRepository<Admin> , IAdminDal
    {

    }
}
/*
 Ekle , Sil, Güncelle Listele ve Idye göre getir : entity'ye özgü değil

içinde a harfi geçmeyen kullanıcıları listele : entity'ye özgü

 */

