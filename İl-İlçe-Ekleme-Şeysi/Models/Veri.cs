using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace İl_İlçe_Ekleme_Şeysi.Models
{
    public static class Veri
    {
        public static ObservableCollection<İl> İller = new ObservableCollection<İl>();
        public static ObservableCollection<İlçe> İlçeler = new ObservableCollection<İlçe>();

        static Veri()
        {
            #region İl ekle
            İller.Add(new İl()
            {
                İlAdı = "İstanbul",
                PlakaKodu = 34,
                İlNüfusu = 18_547_654,
                YüzÖlçümü = 5_461,
                Harita = new BitmapImage(new Uri("/Images/İstanbulNufusfot.jpg", UriKind.Relative))
            });

            İller.Add(new İl()
            {
                İlAdı = "Kastamonu",
                PlakaKodu = 37,
                İlNüfusu = 383_373,
                YüzÖlçümü = 3_461,
                Harita = new BitmapImage(new Uri("/Images/kastamınu.jpg", UriKind.Relative))
            });

            İller.Add(new İl()
            {
                İlAdı = "Ankara",
                PlakaKodu = 06,
                İlNüfusu = 5_503_985,
                YüzÖlçümü = 6_461,
                Harita = new BitmapImage(new Uri("/Images/Angara.jpg", UriKind.Relative))
            });

            İller.Add(new İl()
            {
                İlAdı = "İzmir",
                PlakaKodu = 35,
                İlNüfusu = 4_320_519,
                YüzÖlçümü = 5_461,
                Harita = new BitmapImage(new Uri("/Images/izmiiiiiiiiiiiiiir.jpg", UriKind.Relative))
            });

            İller.Add(new İl()
            {
                İlAdı = "Antalya",
                PlakaKodu = 07,
                İlNüfusu = 2_426_356,
                YüzÖlçümü = 4_461,
                Harita = new BitmapImage(new Uri("/Images/antalya.png", UriKind.Relative))
            });
            #endregion

            #region İlçe Ekle
            //Istanbul
            İlçeler.Add(new İlçe()
            {
                İlçeAdı="Kağıthane",
                İlçeNüfusu=437_036,
                İlAd = İller[0]
            });

            İlçeler.Add(new İlçe()
            {
                İlçeAdı = "Şişli",
                İlçeNüfusu = 560_850,
                İlAd = İller[0]
            });

            İlçeler.Add(new İlçe()
            {
                İlçeAdı = "Sarıyer",
                İlçeNüfusu = 342_503,
                İlAd = İller[0]
            });

            //Kastamonu
            İlçeler.Add(new İlçe()
            {
                İlçeAdı = "Tosya",
                İlçeNüfusu = 15_568,
                İlAd = İller[1]
            });

            İlçeler.Add(new İlçe()
            {
                İlçeAdı = "Cide",
                İlçeNüfusu = 20_454,
                İlAd = İller[1]
            });
            //Ankara
            İlçeler.Add(new İlçe()
            {
                İlçeAdı = "Keçiören",
                İlçeNüfusu = 909_897,
                İlAd = İller[2]
            });

            İlçeler.Add(new İlçe()
            {
                İlçeAdı = "Çankaya",
                İlçeNüfusu = 920_890,
                İlAd = İller[2]
            });

            İlçeler.Add(new İlçe()
            {
                İlçeAdı = "Kızılcahamam",
                İlçeNüfusu = 32_980,
                İlAd = İller[2]
            });
            
            //İzmir
            İlçeler.Add(new İlçe()
            {
                İlçeAdı = "Şirince",
                İlçeNüfusu = 10_548,
                İlAd = İller[3]
            });

            İlçeler.Add(new İlçe()
            {
                İlçeAdı = "Karşıyaka",
                İlçeNüfusu = 344_487,
                İlAd = İller[3]
            });

            İlçeler.Add(new İlçe()
            {
                İlçeAdı = "Bornova",
                İlçeNüfusu = 250_748,
                İlAd = İller[3]
            });
            #endregion

            #region Gereksiz
            //Ekleme
            //İller[0].İlçeler.Add(İlçeler[0]);
            //İller[0].İlçeler.Add(İlçeler[1]);
            //İller[0].İlçeler.Add(İlçeler[2]);
            //İller[1].İlçeler.Add(İlçeler[3]); gereg yoog
            //İller[1].İlçeler.Add(İlçeler[4]);  he ya aq furkanı
            //İller[1].İlçeler.Add(İlçeler[5]);
            //İller[2].İlçeler.Add(İlçeler[6]);
            //İller[2].İlçeler.Add(İlçeler[7]);
            //İller[2].İlçeler.Add(İlçeler[8]);
            #endregion
        }
    }
}
