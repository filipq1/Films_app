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
using System.Windows.Shapes;

namespace Projekt_filmy
{
    /// <summary>
    /// Logika interakcji dla klasy ZapisWindow.xaml
    /// </summary>
    public partial class ZapisWindow : Window
    {
        public ZapisWindow()
        {
            InitializeComponent();
        }

        private void button_nie_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            this.Close();
        }

        private void button_tak_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
            this.Close();
        }
    }

}
