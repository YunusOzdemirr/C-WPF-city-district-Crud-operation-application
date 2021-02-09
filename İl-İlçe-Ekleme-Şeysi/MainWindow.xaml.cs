using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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

namespace İl_İlçe_Ekleme_Şeysi
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            #region ölesine açılış
            Frm.Source = new Uri($"Views/Açılış.xaml", UriKind.Relative);
            #endregion
        }

        private void MiNavigasyon(object sender, RoutedEventArgs e)
        {
            MenuItem mi = (MenuItem)sender;
            Frm.Source = new Uri($"Views/{mi.Tag}.xaml",UriKind.Relative);

        }
    }
}
