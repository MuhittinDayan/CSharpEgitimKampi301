using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpEgitimKampi301.EntitiyLayer.Concrete
{
    public class Category
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }

        public bool CategoryStatus { get; set; }

        public List<Product> Products { get; set; }

    }
}
/*
 Field-Variable-Property
sınıfın içinde tanımlama field 
get ve set komutları ile kullanılırsa property
metodun içinde tanımlanırsa variable
!! önemli
 */
/*
 int x; --> field
*/
/*
public int y {get;set} --> property
*/
/*
void test()
{
    int z
}

bu şekilde tanımlanırsa değişken(variable)
*/


