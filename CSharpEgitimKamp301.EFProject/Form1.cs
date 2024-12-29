using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSharpEgitimKamp301.EFProject
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        EgitimKampiEFTravelDBEntities db = new EgitimKampiEFTravelDBEntities();

        private void btnList_Click(object sender, EventArgs e)
        {
            var values = db.Guide.ToList();
            dataGridView1.DataSource = values; // verileri datagridview'e aktarıyoruz.
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
           Guide guide = new Guide();
            guide.GuideName = txtName.Text;
            guide.GuideSurname = txtSurname.Text;
            db.Guide.Add(guide); // Add() metodu veritabanına ekleme işlemini gerçekleştirir.
            // name ve surname bilgilerini kaydedeceğiz. 
            db.SaveChanges(); // SaveChanges() methodu veritabanına kaydetme işlemini gerçekleştirir.
            MessageBox.Show("Rehber Başarıyla Eklendi");
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            // ad ve soyad aynı değerleri alabilir bu yüzden bize benzersiz bir değer gerekli
            // bu yüzden id değerini alıp silme işlemi yapacağız.

            int id = int.Parse(txtId.Text); // id değerini alıyoruz.
            // int.Parse() metodu string ifadeyi kabul eder. Bu yüzden dönüşüm yaptık.

            var removeValue = db.Guide.Find(id); // id değerine göre silme işlemi yapacağız.
            // Find() metodu id'ye göre değeri bulur. 
            db.Guide.Remove(removeValue); // Remove() metodu veritabanından silme işlemini gerçekleştirir.
            db.SaveChanges();
            MessageBox.Show("Rehber Başarıyla Silindi");
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtId.Text); // id değerini buluyoruz.
            var updateValue = db.Guide.Find(id);
            updateValue.GuideName = txtName.Text;
            updateValue.GuideSurname = txtSurname.Text;
            db.SaveChanges();
            MessageBox.Show("Rehber Başarıyla Güncellendi","Uyarı",MessageBoxButtons.OK,MessageBoxIcon.Warning); 
        }

        private void btnGetById_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtId.Text);
            var values = db.Guide.Where(x=> x.GuideId == id).ToList();
            // sadece şartı sağlayan değerleri getirir
            dataGridView1.DataSource = values;
        }
    }
}
