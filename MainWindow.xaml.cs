using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace Projekt_filmy
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private int zmiana = 0;
        BazaFilmow filmy = new BazaFilmow();
        ObservableCollection<Film> lista;
        /// <summary>
        /// Konstruktor inicjalizujący okno główne WPF
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
            lista = new ObservableCollection<Film>();
            listBox_baza.ItemsSource = lista;
             
        }

        private void MenuOtworz_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
            Nullable<bool> result = dlg.ShowDialog();
            if (result == true)
            {
                string filename = dlg.FileName;
                filmy = BazaFilmow.OdczytajXML(filename);
                lista = new ObservableCollection<Film>(filmy.Baza);
                listBox_baza.ItemsSource = lista;

            }
        }

        private void MenuZapisz_Click(object sender, RoutedEventArgs e)
        {
                Microsoft.Win32.SaveFileDialog dlg = new Microsoft.Win32.SaveFileDialog();
                Nullable<bool> result = dlg.ShowDialog();
                if (result == true)
                {
                    string filename = dlg.FileName;
                    zmiana = 0;
                    filmy.ZapiszXML(filename);
                    filmy.ZapiszDoBazy();
            }
           
        }

        private void MenuWyjdz_Click(object sender, RoutedEventArgs e)
        {

            if (zmiana != 0)
            {
                ZapisWindow zw = new ZapisWindow();
                zw.ShowDialog();
                if (zw.DialogResult == true)
                {
                    Microsoft.Win32.SaveFileDialog dlg = new Microsoft.Win32.SaveFileDialog();
                    Nullable<bool> result = dlg.ShowDialog();
                    if (result == true)
                    {
                        string filename = dlg.FileName;
                        filmy.ZapiszXML(filename);
                        this.Close();
                    }
                }
                else this.Close();
            }
            else this.Close();
        }


        private void button_dodaj_Click(object sender, RoutedEventArgs e)
        {
            Film nowy = new Film();
            Okno_dodaj od = new Okno_dodaj(nowy);
            od.ShowDialog();
            if (od.DialogResult == true)
            {
                filmy.Dodaj(nowy);
                lista.Add(nowy);
                zmiana++;
            }
        }

        private void button_usun_Click(object sender, RoutedEventArgs e)
        {
            int zaznaczony = listBox_baza.SelectedIndex;

            try
            {
                lista.RemoveAt(zaznaczony);
                filmy.Baza.RemoveAt(zaznaczony);
                zmiana++;

            }
            catch (ArgumentOutOfRangeException)
            {
                MessageBox.Show("Nie wybrano filmu do usunięcia");
            }
        }

        private void button_zmien_Click(object sender, RoutedEventArgs e)
        {
            int zaznaczony = listBox_baza.SelectedIndex;


            if (zaznaczony >= 0)
            { 

                Film f = (Film)listBox_baza.SelectedItem;
                Okno_dodaj ok = new Okno_dodaj(f);
                ok.ShowDialog();
                if (ok.DialogResult == true)
                {
                    lista.RemoveAt(zaznaczony);
                    lista.Insert(zaznaczony, f);
                    filmy.Baza.RemoveAt(zaznaczony);
                    filmy.Baza.Insert(zaznaczony, f);
                    zmiana++;
                }
            }
                else
            {
                MessageBox.Show("Nie wybrano filmu");
            }     
        }

        private void listBox_baza_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void button_sortuj_Click(object sender, RoutedEventArgs e)
        {
            filmy.Sortuj();
            lista = new ObservableCollection<Film>(filmy.Baza);
            listBox_baza.ItemsSource = lista;
        }
        private void button_ocen_Click(object sender, RoutedEventArgs e)
        {


            int zaznaczony = listBox_baza.SelectedIndex;
            if (zaznaczony >= 0)
            {
                
                Film f = (Film)listBox_baza.SelectedItem;
                    Okno_ocen ok = new Okno_ocen(f);
                    ok.ShowDialog();
                    if (ok.DialogResult == true)
                    {
                        lista.RemoveAt(zaznaczony);
                        lista.Insert(zaznaczony, f);
                        zmiana++;
                    }
                
            }
            else
            {
                MessageBox.Show("Nie wybrano filmu");
            }
            

        }

        private void button_informacje_Click(object sender, RoutedEventArgs e)
        {
            int zaznaczony = listBox_baza.SelectedIndex;
            if (zaznaczony >=0 )
            {
                    Film f = (Film)listBox_baza.SelectedItem;
                    MessageBox.Show(f.Wypisz_Info());
            }

            else
                {
                    MessageBox.Show("Nie wybrano filmu");
                }
        }
    }
}
