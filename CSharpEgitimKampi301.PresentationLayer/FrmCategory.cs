using CSharpEgitimKampi301.BusinessLayer.Abstract;
using CSharpEgitimKampi301.BusinessLayer.Concrete;
using CSharpEgitimKampi301.DataAccessLayer.EntityFramework;
using CSharpEgitimKampi301.EntitiyLayer.Concrete;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSharpEgitimKampi301.PresentationLayer
{
    public partial class FrmCategory : Form
    {
        private readonly ICategoryService _categoryService;
        public FrmCategory()
        {
            _categoryService = new CategoryManager(new EFCategoryDal());
            InitializeComponent();
        }

        
        private void btnList_Click(object sender, EventArgs e)
        {
            var categoryValues = _categoryService.TGetAll();
            dataGridView1.DataSource = categoryValues;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Category category = new Category(); // Category sınıfından bir nesne oluşturduk.
            category.CategoryName = txtCategoryName.Text; // Kategori adı textbox'tan alınır.
            category.CategoryStatus = true; // Kategori durumu aktif olarak eklenir.
            _categoryService.TInsert(category); // _categoryService üzerinden TInsert metodunu çağırdık.
            MessageBox.Show("Kategori Ekleme Başarılı");

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtCategoryId.Text); // Kategori id'si textbox'tan alınır.
            var deletedValues = _categoryService.TGetById(id); // _categoryService üzerinden TGetById metodunu çağırdık. id'ye ulaşırız.
            _categoryService.TDelete(deletedValues); // _categoryService üzerinden TDelete işlemi uygulayarak (id baz alınıyor) silme işlemi yapılır.
            MessageBox.Show("Kategori Silme Başarılı");
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            int updatedId = int.Parse(txtCategoryId.Text); // Kategori id'si textbox'tan alınır.
            var updatedValue = _categoryService.TGetById(updatedId); // _categoryService üzerinden TGetById metodunu çağırdık. id'ye ulaşırız.
            updatedValue.CategoryName = txtCategoryName.Text; // Kategori adı textbox'tan alınır.
            updatedValue.CategoryStatus = true; // Kategori durumu aktif olarak güncellenir.
            _categoryService.TUpdate(updatedValue); // _categoryService üzerinden TUpdate metodunu çağırdık.
        }

        private void btnGetById_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtCategoryId.Text); // Kategori id'si textbox'tan alınır. dönüşüm yapılır.
            var values = _categoryService.TGetById(id); // _categoryService üzerinden TGetById metodunu çağırdık. id'ye ulaşırız.
            dataGridView1.DataSource = values; // values değerini datagridview'e yansıttık.

        }
    }
}
