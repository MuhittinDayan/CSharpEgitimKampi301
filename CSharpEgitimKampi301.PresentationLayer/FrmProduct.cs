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
    
    public partial class FrmProduct : Form
    {
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;
        public FrmProduct()
        {
            InitializeComponent();
            _productService = new ProductManager(new EFProductDal());
            _categoryService = new CategoryManager(new EFCategoryDal());
        }
        // 1. adım yeni nesne üretmek
        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void FrmProduct_Load(object sender, EventArgs e)
        {
            var values = _categoryService.TGetAll();
            cmbCategory.DataSource = values; // veritabanından gelen verileri comboboxa atıyoruz
            cmbCategory.DisplayMember = "CategoryName"; // comboboxda görünen isim
            cmbCategory.ValueMember = "CategoryId"; // veritabanındaki karşılık gelen değer
            // comboboxa veri atıyoruz
        }


        //2. adım listele butonunun görevini yazmak
        private void btnList_Click(object sender, EventArgs e)
        {
            var values = _productService.TGetAll(); // tüm verileri çektik veritabanından
            dataGridView1.DataSource = values; // verileri ekranda listeleme

        }

        private void btnList2_Click(object sender, EventArgs e)
        {
            var values =_productService.TGetProductsWithCatgory();
            dataGridView1.DataSource = values;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtProductId.Text);
            var value = _productService.TGetById(id);
            _productService.TDelete(value);
            MessageBox.Show("Silme işlemi başarılı");
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Product product = new Product();
            product.CategoryId = int.Parse(cmbCategory.SelectedValue.ToString());
            product.ProductPrice = (int)decimal.Parse(txtProductPrice.Text);
            product.ProductName = txtProductName.Text;
            product.ProductStock = int.Parse(txtProductStock.Text);
            product.ProductDescription = txtDescription.Text;
            _productService.TInsert(product);
            MessageBox.Show("Ekleme işlemi yapıldı");
        }

        private void btnGetById_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtProductId.Text);
            var value = _productService.TGetById(id);
            dataGridView1.DataSource = value;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtProductId.Text);
            var value = _productService.TGetById(id);
            value.ProductId = int.Parse(cmbCategory.SelectedItem.ToString());
            value.ProductDescription = txtDescription.Text;
            value.ProductName = txtProductName.Text;
            value.ProductPrice = (int)decimal.Parse(txtProductPrice.Text);
            value.ProductStock = int.Parse(txtProductStock.Text);
            _productService.TUpdate(value);
            MessageBox.Show("Güncelleme işlemi başarılı");

        }
    }
}
