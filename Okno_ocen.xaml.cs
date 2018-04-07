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
    /// Interaction logic for Okno_ocen.xaml
    /// </summary>
    public partial class Okno_ocen : Window
    {
        Film film;
        /// <summary>
        /// Inicjalizuje puste okno do oceniania filmów
        /// </summary>
        public Okno_ocen()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Inicjalizuje okno do oceny wybranego filmu, z jego tytułem
        /// </summary>
        /// <param name="f">Film, który chcemy ocenić</param>
        public Okno_ocen(Film f):this()
        {
            try
            {
                this.film = f;
                textBox_tytul.Text = this.film.Nazwa;
                
            }
            catch(Exception)
            {
                MessageBox.Show("Nie zaznaczono filmu do ocenienia");
            }
        }

        private void button_zatwierdz_Click(object sender, RoutedEventArgs e)
        {
            int ocena;
            if(int.TryParse(textBox_ocena.Text, out ocena))
            {
                if((ocena <= 10) && (ocena > 0))
                {
                    this.film.Ocen(ocena);
                    DialogResult = true;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Podano niewłaściwą ocenę");
                }

            }
            else
            {
                MessageBox.Show("Podano niewłaściwą ocenę");
            }
        }

        private void button_anuluj_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            this.Close();
        }
    }
}
