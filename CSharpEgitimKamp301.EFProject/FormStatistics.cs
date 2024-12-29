using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSharpEgitimKamp301.EFProject
{
    public partial class FormStatistics : Form
    {
        public FormStatistics()
        {
            InitializeComponent();
        }

        EgitimKampiEFTravelDBEntities db = new EgitimKampiEFTravelDBEntities();
        private void FormStatistics_Load(object sender, EventArgs e)
        {
            lblLocationCount.Text = db.Location.Count().ToString(); // Toplam Lokasyon Sayısı 
            
            lblSumCapacity.Text = db.Location.Sum (x=> x.Capacity).ToString(); // Toplam Kapasite
            
            lblGuideCount.Text = db.Location.Count().ToString(); // Toplam Rehber Sayısı
            
            lblAvarageCapacity.Text = db.Location.Average(x=>x.Capacity)?.ToString("0.00"); // Ortalama Kapasite
            
            lblAvarageTourPrice.Text = db.Location.Average(x=>x.Price)?.ToString("0.00")+ "TL"; // Ortalama Tur Fiyatı
            
            int lastCountryId = db.Location.Max(x => x.LocationId); // En yüksek id'ye sahip ülkeyi bulduk.
            lblLastCountryName.Text = db.Location.Where(x=>x.LocationId == lastCountryId).Select(y=>y.Country).FirstOrDefault();
            // En son eklenen ülkeyi şartları sağlatarak lblLastCountryName'ye aktardık.
            
            lblCapadociaLocationCapacity.Text = db.Location.Where(x => x.City == "Kapadokya").Select(y=>y.Capacity).FirstOrDefault().ToString();
            // Kapadokya'ya ait kapasite verisini önce şehir bilgisini bulup daha sonra kapasitesini seçerek formda yazdırdık.
            
            lblTurkeyCapacityAvarage.Text = db.Location.Where(x=>x.Country == "Türkiye").Average(y =>y.Capacity).ToString();
            // Türkiye'ye ait turların kapasitesinin ortalamasını istenilen koşulları yazarak ele aldık.

            var romeGuideId = db.Location.Where(x => x.City == "Roma Turistik").Select(y => y.GuideId).FirstOrDefault();
            // burada roma gezisine ait turun rebher id'sini bulduk ve değişkenimize atadık. 
            lblRomaGuideName.Text = db.Guide.Where (x=>x.GuideId == romeGuideId).Select(y => y.GuideName + " " + y.GuideSurname ).FirstOrDefault().ToString();

            // daha sonra bu id'yi kullanarak rehberin adını ve soyadını bulduk ve formda yazdırdık.

            var maxCapacity = db.Location.Max(x=>x.Capacity); // max kapasite sayısını bulduk.

            lblMaxCapacityLocation.Text = db.Location.Where(x=>x.Capacity == maxCapacity).Select(y =>y.City).FirstOrDefault().ToString();
           // daha sonra bu kapasiteye sahip olan şehri bulduk ve formda yazdırdık.

            var maxPrice = db.Location.Max(x => x.Price); // max fiyatı bulduk.

            lblMaxTourPrice.Text = db.Location.Where(x=>x.Price == maxPrice).Select(y => y.City).FirstOrDefault().ToString();

            // daha sonra bu fiyata sahip olan şehri bulduk ve formda yazdırdık.

            var guideIdByNameAysegulCinar = db.Guide.Where(x=>x.GuideName == "Ayşegül" && x.GuideSurname == "Çınar").Select(y => y.GuideId).FirstOrDefault();
            // Ayşegül Çınar isimli rehberin id'sini bulduk.

            lblAysegulCinarLocationCount.Text = db.Location.Where(x => x.GuideId == guideIdByNameAysegulCinar).Count().ToString();
            // bu id'ye sahip olan kişiye ait turların toplam sayısını bulduk ve formda yazdırdık.



        }
    }
}
