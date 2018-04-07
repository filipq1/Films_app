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
    /// Interaction logic for Okno_dodaj.xaml
    /// </summary>
    public partial class Okno_dodaj : Window
    {
        Film film;
        /// <summary>
        /// Inicjalizuje puste okno do dodawania filmów
        /// </summary>
        public Okno_dodaj()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Używany przy zmienianiu danych o filmie, inicjalizuje okno z danymi wybranego filmu
        /// </summary>
        /// <param name="film_dod">Film, którego informacje chcemy zmienić</param>
        public Okno_dodaj(Film film_dod):this()
        {
            try
            {
                this.film = film_dod;
                textBox_tytul.Text = this.film.Nazwa;
                textBox_gat.Text = this.film.Gatunek;
                textBox_kraj.Text = this.film.Kraj_produkcji;
                textBox_rokprod.Text = this.film.Rok_produkcji;
                textBox_opis.Text = this.film.Opis;
            }
            catch (NullReferenceException)
            {
                MessageBox.Show("Nie zaznaczono obiektu");
                
            }
        }

        private void button_OK_Click(object sender, RoutedEventArgs e)
        {
            if (textBox_tytul.Text == "" || textBox_gat.Text == "" || textBox_opis.Text == "" || textBox_rokprod.Text == "" || textBox_kraj.Text == "")
            {
                MessageBox.Show("Złe dane!");
                return;
            }
            this.film.Nazwa = textBox_tytul.Text;
            this.film.Gatunek = textBox_gat.Text;
            this.film.Kraj_produkcji = textBox_kraj.Text;
            this.film.Rok_produkcji = textBox_rokprod.Text;
            this.film.Opis = textBox_opis.Text;
            DialogResult = true;
            this.Close();
        }

        private void button_rez_Click(object sender, RoutedEventArgs e)
        {
            if(this.film.Rezyser != null)
            {
                Okno_rezyser nr = new Okno_rezyser(this.film.Rezyser);
                nr.ShowDialog();
                this.film.Rezyser = this.film.Rezyser;
            }
            else
            {
                Rezyser r = new Rezyser();
                Okno_rezyser nr = new Okno_rezyser(r);
                nr.ShowDialog();
                this.film.Rezyser = r;
            }
        }

        private void button_anuluj_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            this.Close();
        }
    }
}
