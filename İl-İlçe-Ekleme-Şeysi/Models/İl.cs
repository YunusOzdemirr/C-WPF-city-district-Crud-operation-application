using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace İl_İlçe_Ekleme_Şeysi.Models
{
    public class İl
    {
        public string İlAdı { get; set; }
        public int PlakaKodu { get; set; }
        public double YüzÖlçümü { get; set; }
        public long İlNüfusu { get; set; }
        public double NüfusYoğunluğu { get { return İlNüfusu / YüzÖlçümü; } } //get sadece okunabilir demek return e ihtiyac duyar.
        public BitmapImage Harita { get; set; }

        //public ObservableCollection<İlçe> İlçeler = new ObservableCollection<İlçe>(); gereg yog

        public List<İlçe> İlçeler { get { return Veri.İlçeler.Where(i => i.İlAd == this).ToList(); } }

        public override string ToString()
        {
            return $"{İlAdı}";
        }
    }
}
