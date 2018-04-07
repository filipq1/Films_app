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
    /// Interaction logic for Okno_rezyser.xaml
    /// </summary>
    public partial class Okno_rezyser : Window
    {
        Rezyser rezyser;
        /// <summary>
        /// Inicjalizuje puste okno do dodania nowego reżysera
        /// </summary>
        public Okno_rezyser()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Inicjalizuje okno z danymi reżysera, które chcemy zmienić
        /// </summary>
        /// <param name="rez">Reżyser, którego dane chcemy zmienić</param>
        public Okno_rezyser(Rezyser rez):this()
        {
            this.rezyser = rez;
            textBox_dataur.Text = this.rezyser.Data_ur.ToShortDateString();
            textBox_imie.Text = this.rezyser.Imie;
            textBox_nazwisko.Text = this.rezyser.Nazwisko;
            textBox_kraj.Text = this.rezyser.Kraj_ur;
        }

        private void button_OK_Click(object sender, RoutedEventArgs e)
        {
            if (textBox_imie.Text == "" || textBox_nazwisko.Text == "" || textBox_kraj.Text == "" || textBox_dataur.Text == "")
            {
                MessageBox.Show("Złe dane!");
                return;
            }
            this.rezyser.Imie = textBox_imie.Text;
            this.rezyser.Nazwisko = textBox_nazwisko.Text;
            this.rezyser.Kraj_ur = textBox_kraj.Text;
            try
            {
                this.rezyser.Data_ur = DateTime.Parse(textBox_dataur.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
            this.Close();
        }

        private void button_anuluj_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

      
    }
}
