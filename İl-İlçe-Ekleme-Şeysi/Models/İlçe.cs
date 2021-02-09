using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace İl_İlçe_Ekleme_Şeysi.Models
{
    public class İlçe
    {
        public string İlçeAdı { get; set; }
        public long İlçeNüfusu { get; set; }
        public İl İlAd { get; set; }

        public override string ToString()
        {
            return $"{İlAd} - {İlçeAdı} - {İlçeNüfusu} ";
        }
    }
}
