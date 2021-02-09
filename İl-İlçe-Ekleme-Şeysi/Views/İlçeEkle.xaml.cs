using İl_İlçe_Ekleme_Şeysi.Models;
using System;
using System.Collections.Generic;
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
    /// Interaction logic for İlçeEkle.xaml
    /// </summary>
    public partial class İlçeEkle : Page
    {
        İlçe seçiliİlçe;

        public İlçeEkle()
        {
            InitializeComponent();
            Cbİller.ItemsSource = Veri.İller;

            BtnİlceKaydet.Click += BtnİlceKaydet_Click;

            #region Preview olayları
            Tbİlce.PreviewKeyDown += Tbİlce_PreviewKeyDown;
            TbİlceNüfusu.PreviewKeyDown += TbİlceNüfusu_PreviewKeyDown;
            Tbİlce.PreviewTextInput += Tbİlce_PreviewTextInput;
            TbİlceNüfusu.PreviewTextInput += TbİlceNüfusu_PreviewTextInput;
            #endregion
        }

        public İlçeEkle(İlçe ilçeİşlem) : this()
        {
            if (ilçeİşlem != null)
            {
                seçiliİlçe = ilçeİşlem;
                Cbİller.SelectedItem = ilçeİşlem.İlAd;
                Tbİlce.Text = ilçeİşlem.İlçeAdı;
                TbİlceNüfusu.Text = ilçeİşlem.İlçeNüfusu.ToString();
            }
        }

        #region Preview komutları
        private void TbİlceNüfusu_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = Regex.IsMatch(e.Text, "[^0-9]+");
        }

        private void Tbİlce_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = Regex.IsMatch(e.Text, "[^a-z]+");
        }

        private void TbİlceNüfusu_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            e.Handled = e.Key == Key.Space;
        }

        private void Tbİlce_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            e.Handled = e.Key == Key.Space;
        }
        #endregion

        private void BtnİlceKaydet_Click(object sender, RoutedEventArgs e)
        {
            #region Hata Kontrol
            string hataMesajı = null;

            if (Cbİller.SelectedItem==null)
                hataMesajı += "İl seçmeliniz \n";
            if (string.IsNullOrWhiteSpace(Tbİlce.Text))
                hataMesajı += "İlçe girmelisiniz \n";
            if (string.IsNullOrWhiteSpace(TbİlceNüfusu.Text))
                hataMesajı += "Nüfus bilgisi girmelisiniz \n";

            if (hataMesajı!=null)
            {
                MessageBox.Show(hataMesajı,"UYARI",MessageBoxButton.OK,MessageBoxImage.Warning);
                return;
            }
            #endregion

            #region Kaydet
            if (seçiliİlçe==null)
            {
                seçiliİlçe = new İlçe();
                Veri.İlçeler.Add(seçiliİlçe);
            }

            seçiliİlçe.İlAd = Cbİller.SelectedItem as İl;
            seçiliİlçe.İlçeAdı = Tbİlce.Text;
            seçiliİlçe.İlçeNüfusu = int.Parse(TbİlceNüfusu.Text);

            #endregion

            NavigationService.Source=new Uri($"Views/Listele.xaml",UriKind.Relative);
            //NavigationService.Content = new Listele(); böyle de gidiyor hiçbir fark yok 
        }
    }
}
