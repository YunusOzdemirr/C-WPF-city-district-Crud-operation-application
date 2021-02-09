using İl_İlçe_Ekleme_Şeysi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
    /// Interaction logic for Listele.xaml
    /// </summary>
    public partial class Listele : Page
    {
        public Listele()
        {
            InitializeComponent();
            Lbİller.ItemsSource = Veri.İller;
            Lbİlçeler.ItemsSource = Veri.İlçeler;

            #region Rapor
            int ilSayac = 0;
            for (int i = 0; i < Veri.İller.Count; i++)
            {
                ilSayac++;
            }
            İllerRapor.Text = $"{ilSayac}";

            int ilçeSayac = 0;
            for (int i = 0; i < Veri.İlçeler.Count; i++)
            {
                ilçeSayac++;
            }
            İlçelerRapor.Text = $"{ilçeSayac}";
            #endregion
        }
        #region Selekşınçenç SelectionChanged
        private void Lb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Lbİller.SelectedItem != null)
            {
                İl seçilenİl = (İl)Lbİller.SelectedItem;
                Lbİlçeler.ItemsSource = seçilenİl.İlçeler;

                //Lbİlçeler.Items.Add(seçilen.İlçeler);
                // Veri.İlçeler.Add((seçilen.İlçeler.Add(Lbİlçeler.Items.Add(seçilen.İlçeler))));
            }
            if (Lbİlçeler.SelectedItem != null)
            {
                İlçe seçilenİlçe = (İlçe)Lbİlçeler.SelectedItem;
                // Lbİller.ItemsSource = Veri.İller(Lbİlçeler.SelectedItem);
            }
        }
        #endregion

        #region Listbox Ara
        private void TbAraİlçe_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TbİlçeAra.Text))
            {
                Lbİlçeler.ItemsSource = Veri.İlçeler;
            }
            else
            {
                Lbİlçeler.ItemsSource = Veri.İlçeler.Where(a => a.İlçeAdı.StartsWith(TbİlçeAra.Text, StringComparison.CurrentCultureIgnoreCase) || a.İlAd.İlAdı.StartsWith(TbİlçeAra.Text, StringComparison.CurrentCultureIgnoreCase));
            }
        }

        private void TbAraİl_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TbİlAra.Text))
            {
                Lbİller.ItemsSource = Veri.İller;
            }
            else
            {
                Lbİller.ItemsSource = Veri.İller.Where(a => a.İlAdı.StartsWith(TbİlAra.Text, StringComparison.CurrentCultureIgnoreCase) || a.PlakaKodu.ToString().StartsWith(TbİlAra.Text, StringComparison.CurrentCultureIgnoreCase));
            }
        }

        #endregion

        #region Düzenle
        private void MiDuzenle(object sender, RoutedEventArgs e)
        {
            if (Lbİller.SelectedItem != null)
            {
                İl bilgiGonder = (İl)Lbİller.SelectedItem;
                NavigationService.Content = new İlEkle(bilgiGonder);
            }

            if (Lbİlçeler.SelectedItem != null)
            {
                İlçe bilgiGonder = (İlçe)Lbİlçeler.SelectedItem;
                NavigationService.Content = new İlçeEkle(bilgiGonder);
            }
        }
        #endregion

        #region Sil
        private void MiSil(object sender, RoutedEventArgs e)
        {
            İlçe seciliİlçe = (İlçe)Lbİlçeler.SelectedItem;
            if (seciliİlçe != null)
            {
                var cevap = MessageBox.Show("Seçili ilçe bilgisi silinsin mi?", "Siliyom he", MessageBoxButton.YesNo, MessageBoxImage.Asterisk);
                if (cevap == MessageBoxResult.Yes)
                {
                    Veri.İlçeler.Remove(seciliİlçe);
                    İl seciliİll = (İl)Lbİller.SelectedItem;
                    seciliİll = null;
                }
                else
                {
                    MessageBox.Show("Silmiyom he", "Silinmiyo", MessageBoxButton.OK, MessageBoxImage.Exclamation);

                }
            }


            İl seciliİl = (İl)Lbİller.SelectedItem;
            if (seciliİl != null)
            {
                var cevap = MessageBox.Show("Seçili il bilgisi silinsin mi?", "Siliyom he", MessageBoxButton.YesNo, MessageBoxImage.Asterisk);
                if (cevap == MessageBoxResult.Yes)
                {
                    Veri.İller.Remove(seciliİl);
                }
                else
                {
                    MessageBox.Show("Silmiyom he", "Silinmiyo", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                }
            }
        }

        #endregion


    }
}
