using İl_İlçe_Ekleme_Şeysi.Models;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace İl_İlçe_Ekleme_Şeysi.Views
{
    /// <summary>
    /// Interaction logic for İlEkle.xaml
    /// </summary>
    public partial class İlEkle : Page
    {
        İl seciliİl;
        public İlEkle()
        {
            InitializeComponent();
            BtnİlKaydet.Click += BtnİlKaydet_Click;
            BtnResimEkle.Click += BtnResimEkle_Click;

            #region ComboBox doldur
            CbPlaka.ItemsSource = Enumerable.Range(1, 81);
            #endregion

            #region Preview olayları
            TbİlSec.PreviewTextInput += TbİlSec_PreviewTextInput;
            TbİlNüfus.PreviewTextInput += TbİlNüfus_PreviewTextInput;
            TbYüzÖlcümü.PreviewTextInput += TbYüzÖlcümü_PreviewTextInput;

            TbİlSec.PreviewKeyDown += TbİlSec_PreviewKeyDown;
            TbİlNüfus.PreviewKeyDown += TbİlNüfus_PreviewKeyDown;
            TbYüzÖlcümü.PreviewKeyDown += TbYüzÖlcümü_PreviewKeyDown;
            #endregion

        }
        public İlEkle(İl ilİşlem) : this()
        {
          //  İl seçilenİl = (İl)lbiller.selectedItem;
            if (ilİşlem != null)
            {
                seciliİl = ilİşlem;
                TbİlSec.Text = ilİşlem.İlAdı;
                CbPlaka.SelectedItem = ilİşlem.PlakaKodu;
               // long.TryParse(TbİlNüfus.Text, out long İlNüfuss);
                TbİlNüfus.Text = ilİşlem.İlNüfusu.ToString();
                TbYüzÖlcümü.Text = ilİşlem.YüzÖlçümü.ToString();
                ImgResim.Source = ilİşlem.Harita;
                ImgResim.Visibility = Visibility.Visible;
            }
        }
        #region Preview Kodları
        private void TbYüzÖlcümü_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            e.Handled = e.Key == Key.Space;
        }

        private void TbİlNüfus_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            e.Handled = e.Key == Key.Space;
        }

        private void TbİlSec_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            e.Handled = e.Key == Key.Space;
        }

        private void TbYüzÖlcümü_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = Regex.IsMatch(e.Text, "[^0-9]+");
        }

        private void TbİlNüfus_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = Regex.IsMatch(e.Text, "[^0-9]+");
        }

        private void TbİlSec_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = Regex.IsMatch(e.Text, "[^a-z]+");
        }
        #endregion

        #region Resim Ekle
        private void BtnResimEkle_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog()
            {
                FileName = "Resim Seç",
                Filter = "Resim Dosyaları(*.png;*.jpg;*.jpeg)|*.png;*.jpg;*.jpeg"
            };

            if (ofd.ShowDialog() == true)
            {
                ImgResim.Source = new BitmapImage(new Uri(ofd.FileName));
                ImgResim.Visibility = Visibility.Visible;
            }
        }
        #endregion

        #region Kaydet
        private void BtnİlKaydet_Click(object sender, RoutedEventArgs e)
        {
            #region HataKontrol
            string hataMesajı = null;

            if (string.IsNullOrWhiteSpace(TbİlSec.Text))
                hataMesajı += "İl bilgisi girmelisiniz \n";
            if (CbPlaka.SelectedItem == null)
                hataMesajı += "Plaka seçmelisiniz \n";
            if (string.IsNullOrWhiteSpace(TbİlNüfus.Text))
                hataMesajı += "Nüfus bilgisi girmelisiniz \n";
            if (string.IsNullOrWhiteSpace(TbYüzÖlcümü.Text))
                hataMesajı += "Yüz Ölçümü bilgisi girmelisiniz \n";
            if (ImgResim.Visibility != Visibility.Visible)
                hataMesajı += "Harita fotoğrafı eklemelisiniz \n";

            if (hataMesajı != null)
            {
                MessageBox.Show(hataMesajı, "UYARI", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            #endregion

            #region Kaydet
            if (seciliİl == null)
            {
                seciliİl = new İl();
                Veri.İller.Add(seciliİl);
            }

            seciliİl.İlAdı = TbİlSec.Text;
            seciliİl.PlakaKodu = (int)CbPlaka.SelectedItem;
            seciliİl.İlNüfusu = int.Parse(TbİlNüfus.Text);
            seciliİl.YüzÖlçümü = double.Parse(TbYüzÖlcümü.Text);
            seciliİl.Harita = ImgResim.Source as BitmapImage;
            #endregion

            NavigationService.Content = new Listele();
        }
        #endregion
    }
}
